using System;
using Apiario.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apiario.Context
{
    public class AtendimentoContext : DbContext
    {
        public DbSet<Atendimento> Atendimentos { get; set; }
    }
}