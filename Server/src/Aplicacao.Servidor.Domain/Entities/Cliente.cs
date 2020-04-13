using Aplicacao.Servidor.Domain.Core.Entities;
using Aplicacao.Servidor.Domain.Core.Validation;
using Aplicacao.Servidor.Domain.Entities.Validations;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;
using System;

namespace Aplicacao.Servidor.Domain.Entities
{
    public class Cliente : Entity<Cliente>
    {
        protected Cliente() { }
        public Cliente(string nome, string cpfCnpj, EnumSexo sexo, EnumEstadoCivil estadoCivil, string rg, DateTime dataNascimento, int idade, decimal salario, string email, string ddd, string fone, string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string cep, bool termo, string observacao, string senha)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            Rg = rg;
            DataNascimento = dataNascimento;
            Idade = idade;
            Salario = salario;
            Email = email;
            Ddd = ddd;
            Fone = fone;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Termo = termo;
            Senha = CriptografarSenha.CryptographyPass(senha);
            Observacao = observacao;
        }

        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public EnumSexo Sexo { get; private set; }
        public EnumEstadoCivil EstadoCivil { get; private set; }
        public string Rg { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade { get; private set; }
        public decimal Salario { get; private set; }
        public string Email { get; private set; }
        public string Ddd { get; private set; }
        public string Fone { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        public bool Termo { get; private set; }
        public string Observacao { get; private set; }
        public string Senha { get; private set; }

        public override ValidationResult ValidationResult { get; set; }
        public override bool IsValid
        {
            get
            {
                var Validardados = new ClienteValidValidation();
                ValidationResult = Validardados.Valid(this);
                return ValidationResult.IsValid;
            }
        }



        public static Cliente ClienteNullObject()
        {
            return new Cliente();
        }

        
    }
}
