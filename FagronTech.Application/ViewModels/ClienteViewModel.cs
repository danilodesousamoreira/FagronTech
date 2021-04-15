using System;

namespace FagronTech.Application.ViewModels
{
    [Serializable]
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public ProfissaoViewModel Profissao { get; set; }
    }
}
