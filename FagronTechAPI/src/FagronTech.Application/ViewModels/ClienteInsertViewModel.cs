using System;

namespace FagronTech.Application.ViewModels
{
    [Serializable]
    public class ClienteInsertViewModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ProfissaoId { get; set; }
    }
}
