using Apiario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apiario.Context
{
    public class DadosCaixaContext : DbContext
    {
        public DbSet<DadosCaixa> DadosCaixa { get; set; }
    }
}