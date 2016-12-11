using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apiario.Context
{
    public class ApiarioContext : DbContext
    {
        public DbSet<Apiario.Models.Apiario> Apiarios { get; set; }
    }
}