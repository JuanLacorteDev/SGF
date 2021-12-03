using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGF.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGF.ApiAws.Controllers
{
    public class AuthController : CustomController
    {
        public AuthController(INotificador notificador) : base(notificador)
        {
        }
    }
}
