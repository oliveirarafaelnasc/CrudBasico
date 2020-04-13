using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Servidor.ApiService.ViewModel
{
    public class ClienteResultViewModel
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivil { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        // [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        private decimal Salario;
        public string salario
        {
                    set { this.Salario = decimal.Parse(value); }
                    get { return String.Format("{0:0.00}", Salario);  }
        }
        public string Email { get; set; }
        public string Ddd { get; set; }
        public string Fone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Observacao { get; set; }
        public bool Termo { get; set; }
        
    }
}
