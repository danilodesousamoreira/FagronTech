using FagronTech.Infrastructure.Domain.Entity;

using System.ComponentModel.DataAnnotations.Schema;

namespace FagronTech.Domain.Entities
{
    [Table("Profissao")]
    public class Profissao : BaseEntity
    {
        public int Id { get; set; }
        public string NomeProfissao { get; set; }
    }
}
