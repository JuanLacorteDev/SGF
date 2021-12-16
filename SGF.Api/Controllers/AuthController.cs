using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SGF.Api.Extensions;
using SGF.Application.ViewModels.AuthEntidades;
using SGF.Domain.Interfaces.Notification;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : CustomController
    {
        private readonly SignInManager<IdentityUser> _signInManager; //faz o trabalho de realizar o signin (autenticação do usuário)
        private readonly UserManager<IdentityUser> _userManager; //responsável por criar o usuário e fazer suas manipulações
        private readonly AppSettings _appSettings;
        public AuthController(INotificador notificador,
                              UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              //IOptions serve para pegar dados que servem como parâmetros
                              IOptions<AppSettings> appSettings) : base(notificador)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email, //não obriga a passar o email como UserName, mas é melhor para o usuário não ter que lembrar de mais uma informação
                Email = registerUser.Email,
                EmailConfirmed = true //já garante que o e-mail está confirmado, pois não se trata de uma aplicação MVC
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password); //criando usuário
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false); //realiza o login do usuário, isPersistent = se desejo lembrar do usuário/gravar login dele
                return CustomResponse(await GerarJwt(user.Email));
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description); //caso exista algum erro, notifica o mesmo para o usuário
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //só dá o nome do usuário e a senha para realizar login
            //isPersistent = se desejo lembrar do usuário/gravar login dele
            //lockoutOnFailure = se o usuário tentar mais de 5 vezes com credenciais erradas, o sistema irá travar o login por um tempo definido, impossibilitando o login
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(loginUser.Email));
            }

            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            //SEMPRE dar o mínimo de informação possível, como dizer se somente a senha ou o usuário estão incorretos, por questões de segurança
            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        //gera o token
        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user); //obtem as claims do usuário
            var userRoles = await _userManager.GetRolesAsync(user);

            //adiciona as claims referentes ao token junto das claims do usuário
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                //adiciona as roles na coleção de claims
                claims.Add(new Claim("role", userRole));
            }

            //converte a coleção de claims para o tipo ClaimsIdentity
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identityClaims, //passando as claims para o token
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoEmHoras), //UtcNow => universal time clock (pois nunca sei de qual região o usuário é)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token); //serializa um JwtSecurityToken em um token Compact Serialization Token (para ficar compatível com padrão web)

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoEmHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        //converte a data para o formato UnixEpochDate
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
    }


}
