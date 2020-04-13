using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;
using Aplicacao.Servidor.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aplicacao.Servidor.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _nomeArquivo = DateTime.Now.ToString("ddMMyyyy");
        private readonly string _caminhoArquivo = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        private readonly string _arquivo;
        private StringBuilder _stringBuilder;

        public ClienteRepository()
        {
            _arquivo = _caminhoArquivo + _nomeArquivo;
            _stringBuilder = new StringBuilder();
        }
        public Cliente Adicionar(Cliente cliente)
        {
            _stringBuilder.Clear();

            PreencherItens(cliente);
            using (var sw = new StreamWriter(_arquivo, true))
            {
                sw.WriteLine(_stringBuilder);
            }

            return cliente;

        }

        public Cliente Alterar(Cliente cliente)
        {
            _stringBuilder.Clear();

            using (var sr = new StreamReader(_arquivo))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (string.IsNullOrEmpty(s))
                        continue;
                    var dados = s.Split(";");
                    if (dados[1].ToString().Equals(cliente.CpfCnpj))
                    {
                        PreencherItens(cliente);
                    }
                    else
                        _stringBuilder.AppendLine(s);
                }
            }

            using (var sw = new StreamWriter(_arquivo, false, System.Text.Encoding.Default))
            {
                sw.Write(_stringBuilder);
            }



            return cliente;
        }

        public void Apagar(string cpfCnpj)
        {
            _stringBuilder.Clear();

            using (var sr = new StreamReader(_arquivo))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (string.IsNullOrEmpty(s))
                        continue;
                    var dados = s.Split(";");
                    if (dados[1].ToString().Equals(cpfCnpj))
                    {
                        continue;
                    }
                    else
                        _stringBuilder.AppendLine(s);
                }
            }

            using (var sw = new StreamWriter(_arquivo, false))
            {
                sw.Write(_stringBuilder);
            }
        }


        public Cliente ObterPorCpfCnpj(string cpfCnpj)
        {
            if (!File.Exists(_arquivo))
                return Cliente.ClienteNullObject();

            using (var sr = new StreamReader(_arquivo))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (string.IsNullOrEmpty(s))
                        continue;
                    var dados = s.Split(";");
                    if (dados[1].ToString().Equals(cpfCnpj))
                    {
                        return PreencherCliente(dados);
                    }
                }
            }

            return Cliente.ClienteNullObject();


        }

        public IEnumerable<Cliente> ObterTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            if (!File.Exists(_arquivo))
                return clientes;


            using (var sr = new StreamReader(_arquivo))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (string.IsNullOrEmpty(s))
                        continue;
                    var dados = s.Split(";");
                    clientes.Add(PreencherCliente(dados));
                }
            }

            return clientes;
        }

        private Cliente PreencherCliente(string[] dadosCliente)
        {
            EnumSexo enumSexo;

            switch (dadosCliente[3].ToString())
            {
                case "0":
                case "Masculino":
                    enumSexo = EnumSexo.Masculino;
                    break;
                default:
                    enumSexo = EnumSexo.Feminino;
                    break;
            }

            EnumEstadoCivil enumEstadoCivil;

            switch (dadosCliente[4].ToString())
            {
                case "0":
                case "Solteiro":
                    enumEstadoCivil = EnumEstadoCivil.Solteiro;
                    break;
                case "1":
                case "Casado":
                    enumEstadoCivil = EnumEstadoCivil.Casado;
                    break;
                case "2":
                case "Viuvo":
                    enumEstadoCivil = EnumEstadoCivil.Viuvo;
                    break;
                default:
                    enumEstadoCivil = EnumEstadoCivil.Divorciado;
                    break;
            }


            return new Cliente(
                dadosCliente[2].ToString(),
                dadosCliente[1].ToString(),
                enumSexo,
                enumEstadoCivil,
                dadosCliente[5].ToString(),
                DateTime.Parse(dadosCliente[6].ToString()),
                int.Parse(dadosCliente[7].ToString()),
                decimal.Parse(dadosCliente[8].ToString()),
                dadosCliente[9].ToString(),
                dadosCliente[10].ToString(),
                dadosCliente[11].ToString(),
                dadosCliente[12].ToString(),
                dadosCliente[13].ToString(),
                dadosCliente[14].ToString(),
                dadosCliente[15].ToString(),
                dadosCliente[16].ToString(),
                dadosCliente[17].ToString(),
                dadosCliente[18].ToString(),
                bool.Parse(dadosCliente[19].ToString()),
                dadosCliente[20].ToString(),
                dadosCliente[21].ToString()
                
                );

        }

        public int SaveChanges() { return 1; }


        private void PreencherItens(Cliente cliente)
        {
            _stringBuilder.AppendLine(
                cliente.Id.ToString() + ";" +
                cliente.CpfCnpj + ";" +
                cliente.Nome + ";" +
                cliente.Sexo.ToString() + ";" +
                cliente.EstadoCivil.ToString() + ";" +
                cliente.Rg + ";" +
                cliente.DataNascimento.ToString("yyyy-MM-dd") + ";" +
                cliente.Idade + ";" +
                cliente.Salario.ToString() + ";" +
                cliente.Email + ";" +
                cliente.Ddd + ";" +
                cliente.Fone + ";" +
                cliente.Logradouro + ";" +
                cliente.Numero + ";" +
                cliente.Complemento + ";" +
                cliente.Bairro + ";" +
                cliente.Cidade + ";" +
                cliente.Estado + ";" +
                cliente.Cep + ";" +
                cliente.Termo.ToString() + ";" +
                cliente.Observacao + ";" +
                cliente.Senha.ToString()
                
                );
        }

        public void Dispose()
        {
            _stringBuilder = null;
        }


    }
}
