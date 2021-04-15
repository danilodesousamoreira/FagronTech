using FagronTech.Infrastructure.Domain.Entity;

namespace FagronTech.Domain.Entities
{
    public class Profissao : BaseEntity
    {
        public int Id { get; set; }
        public string NomeProfissao { get; set; }
    }
}
