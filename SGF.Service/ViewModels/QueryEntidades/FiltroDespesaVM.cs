﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Application.ViewModels.QueryEntidades
{
    public class FiltroDespesaVM
    {
        public Guid UserId { get; set; }
        public int NumMes { get; set; }
        public int NumAno { get; set; }
        public DateTime? InicioPeriodo { get; set; }
        public DateTime? FimPeriodo { get; set; }
    }
}
