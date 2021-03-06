using Dapper.Contrib.Extensions;

using FagronTech.Infrastructure.Domain.Entity;

using System;

namespace FagronTech.Domain.Entities
{
    [Table("Cliente")]
    public class Cliente : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ProfissaoId { get; set; }
        
        [Computed]
        public virtual Profissao Profissao {get;set;}
    }
}
