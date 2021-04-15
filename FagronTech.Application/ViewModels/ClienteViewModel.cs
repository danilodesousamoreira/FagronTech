using System;
using System.Collections.Generic;
using System.Text;

namespace FagronTech.Application.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }
    }
}
