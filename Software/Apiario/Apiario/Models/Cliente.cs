//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apiario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Apiario = new HashSet<Apiario>();
            this.Atendimento = new HashSet<Atendimento>();
        }
    
        public int idCliente { get; set; }
        public string nomeUsuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public bool tipoUsuario { get; set; }
        public string telefone { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public int idade { get; set; }
    
        public virtual ICollection<Apiario> Apiario { get; set; }
        public virtual ICollection<Atendimento> Atendimento { get; set; }
    }
}
