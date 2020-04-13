var estados = [];

document.getElementById('id-caixa_erro').style.display = 'none';
estados.push({key : '0', value:'Selecione'});    
estados.push({key :'1', value:'AC'});
estados.push({key :'2', value:'AL'});
estados.push({key :'3', value:'AP'});
estados.push({key :'4', value:'AM'});
estados.push({key :'5', value:'BA'});
estados.push({key :'6', value:'CE'});
estados.push({key :'7', value:'DF'});
estados.push({key :'8', value:'ES'});
estados.push({key :'9', value:'GO'});
estados.push({key :'10', value:'MA'});
estados.push({key :'11', value:'MT'});
estados.push({key :'12', value:'MS'});
estados.push({key :'13', value:'MG'});
estados.push({key :'14', value:'PA'});
estados.push({key :'15', value:'PB'});
estados.push({key :'16', value:'PR'});
estados.push({key :'17', value:'PE'});
estados.push({key :'18', value:'PI'});
estados.push({key :'19', value:'RJ'});
estados.push({key :'20', value:'RN'});
estados.push({key :'21', value:'RS'});
estados.push({key :'22', value:'RO'});
estados.push({key :'23', value:'RR'});
estados.push({key :'24', value:'SC'});
estados.push({key :'25', value:'SP'});
estados.push({key :'26', value:'SE'});
estados.push({key :'27', value:'TO'});

preencherSelect(document.getElementById('idEstado'),estados);

var erros = [];

document.getElementById('idCadastrar').addEventListener( 'click', cadastrarCliente);
document.getElementById('idDataNascimento').addEventListener('keypress', function(event) { mascaraData(event, this);  })
document.getElementById('idIdade').addEventListener('keypress', function(event) { somenteNumerosInteiros(event);  })
document.getElementById('idDdd').addEventListener('keypress', function(event) { somenteNumerosInteiros(event);  })
document.getElementById('idFone').addEventListener('keypress', function(event) { somenteNumerosInteiros(event);  })
document.getElementById('idCep').addEventListener('keypress', function(event) { somenteNumerosInteiros(event);  })
document.getElementById('idSalario').addEventListener('keypress', function(event) { moeda(event) });
document.getElementById('idSalario').addEventListener('blur', function(event) { this.value = mreais(this.value) });
document.getElementById('idConsultarCep').addEventListener('click', consultarCep );
document.getElementById('idApagar').addEventListener('click', apagar );
document.getElementById('idConsultar').addEventListener('click', consultarCliente );
document.getElementById('id_span_erro_x').addEventListener('click', fecharMensagensErros );

function cadastrarCliente() {
    erros = [];
    removerMsgErros()
    validarDados();

    if(erros.length == 0)   
        enviarDadosCadastrarCliente();
    else
    {
        document.getElementById('id-caixa_erro').style.display = 'block';
        executarMsgErro();
        toastr.error("Não foi possível enviar os dados para cadastro, verifique as informações");
    }         
}

function apagar() {
    
    erros = [];
    removerMsgErros()
    if(document.getElementById('idCpfCnpj').value == '')
    {
        toastr.error("Necessário digitar o cpfcnpj ou consultar!");
        document.getElementById('idCpfCnpj').focus();
        return;
    }
    apagarDados();
}

function executarMsgErro()
{
    let msg = ''
    for (let index = 0; index < erros.length; index++) {
        addMsgErro(erros[index]);
    } 
}

function consultarCep()
{
    if(!validarCampoPreenchido(document.getElementById('idCep').value, 8))
    {
        toastr.error('Cep inválido!')
        return
    }

    xhr = new XMLHttpRequest();
    let url =''; //serviço de endereço tipo correios
    url = 'https://viacep.com.br/ws/'+ document.getElementById('idCep').value +'/json/';
    xhr.open("GET", url, true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.onreadystatechange = function () {

        if (xhr.readyState == 4) {

            if (xhr.status == 200) {
                let retorno = JSON.parse(xhr.response);
                document.getElementById('idLogradouro').value = retorno.logradouro;                        
                document.getElementById('idBairro').value = retorno.bairro;
                document.getElementById('idCidade').value = retorno.localidade;
                   
                marcarEstado(retorno.uf);
            }
        }

    }
        
    xhr.send();
}

function enviarDadosCadastrarCliente()
{
    xhr = new XMLHttpRequest();
    let url =''; 
    url = 'https://localhost:44367/api/cliente/incluir';
    xhr.open("POST", url, true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.onreadystatechange = function () {

        if (xhr.readyState == 4) {
            if (xhr.status == 201) {
                toastr.success('Operação realizado com sucesso!')
            }
            else
            {
                toastr.error("Falha ao realizar Operação");
                let dadosErro = JSON.parse(xhr.response);
                    
                let msg = ''
                for (let index = 0; index < dadosErro.errors.length; index++) {
                    erros.push(dadosErro.errors[index].mensagem);
                        
                } 
                    
                executarMsgErro();
            }
        }
    }

    let objCliente = new Object();

    objCliente.Nome = document.getElementById('idNome').value,
    objCliente.CpfCnpj = document.getElementById('idCpfCnpj').value,
    objCliente.Sexo = document.getElementById('idMasculino').checked ? 0 : 1,
    objCliente.EstadoCivil = parseInt(document.getElementById('idEstadoCivil').value),
    objCliente.Rg = document.getElementById('idRg').value,
    objCliente.DataNascimento = FormatarDataParaEnvio(document.getElementById('idDataNascimento').value),
    objCliente.Idade = parseInt(document.getElementById('idIdade').value),
    objCliente.Salario = convertRealToFloat(document.getElementById('idSalario').value),
    objCliente.Email = document.getElementById('idEmail').value,
    objCliente.Ddd = document.getElementById('idDdd').value,
    objCliente.Fone = document.getElementById('idFone').value,
    objCliente.Logradouro = document.getElementById('idLogradouro').value,
    objCliente.Numero = document.getElementById('idNumero').value,
    objCliente.Complemento = document.getElementById('idComplemento').value,
    objCliente.Bairro = document.getElementById('idBairro').value,
    objCliente.Cidade = document.getElementById('idCidade').value ,
    objCliente.Estado = document.getElementById('idEstado').options[document.getElementById('idEstado').selectedIndex].text,
    objCliente.Cep = document.getElementById('idCep').value,
    objCliente.Termo = document.getElementById('idTermo').checked,
    objCliente.Observacao = document.getElementById('idObservacao').value,
    objCliente.Senha = document.getElementById('idSenha').value,
    objCliente.ConfirmaSenha = document.getElementById('idConfirmaSenha').value

    xhr.send(JSON.stringify(objCliente));
}

function apagarDados()
{
        xhr = new XMLHttpRequest();
        let url =''; 
        url = 'https://localhost:44367/api/cliente/apagar?cpfcnpj=' + document.getElementById('idCpfCnpj').value;
        xhr.open("DELETE", url, true);
        xhr.setRequestHeader("Content-type", "application/json");
        xhr.onreadystatechange = function () {

            if (xhr.readyState == 4) {

                if (xhr.status == 200) {
                    
                    toastr.success('Operação realizado com sucesso!');

                    document.getElementById('idNome').value = ''; 
                    document.getElementById('idCpfCnpj').value = '';
                    document.getElementById('idEstadoCivil').value = 0;
                    document.getElementById('idRg').value = '';
                    document.getElementById('idDataNascimento').value = '';
                    document.getElementById('idIdade').value = '';
                    document.getElementById('idSalario').value = '0,0';
                    document.getElementById('idEmail').value = '';
                    document.getElementById('idDdd').value = '';
                    document.getElementById('idFone').value = '';
                    document.getElementById('idLogradouro').value = '';
                    document.getElementById('idNumero').value = '';
                    document.getElementById('idComplemento').value =  '';
                    document.getElementById('idBairro').value = '';
                    document.getElementById('idCidade').value = '';
                    document.getElementById('idCep').value =  '';
                    document.getElementById('idTermo').checked = false;
                    document.getElementById('idObservacao').value = '';
                    document.getElementById('idEstado').value = 0
                    
                }
                else
                {
                    toastr.error("Falha ao realizar Operação");
                    let dadosErro = JSON.parse(xhr.response);
                    
                    let msg = ''
                    for (let index = 0; index < dadosErro.errors.length; index++) {
                        erros.push(dadosErro.errors[index].mensagem);
                        
                    } 
                    
                    executarMsgErro();
                    
            
                }
            }

        }

        xhr.send();
}


function consultarCliente()
{
    removerMsgErros();
    xhr = new XMLHttpRequest();
    let url =''; 
    url = 'https://localhost:44367/api/cliente/obter-por-cpfcnpj?cpfcnpj=' + document.getElementById('idConsutarCpfCnpj').value;
    xhr.open("GET", url, true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.onreadystatechange = function () {

        if (xhr.readyState == 4) {

            if (xhr.status == 200) {
                
                let objCliente = JSON.parse(xhr.response).data;

                if(objCliente == null)
                {
                    toastr.error('Nenhum resultado encontrado!');
                    return;
                }

                toastr.success('Operação realizado com sucesso!');

                document.getElementById('idNome').value = objCliente.nome; 
                document.getElementById('idCpfCnpj').value = objCliente.cpfCnpj;
                document.getElementById('idMasculino').checked = objCliente.sexo ===  0; 
                document.getElementById('idFeminino').checked = objCliente.sexo ===  1;
                document.getElementById('idEstadoCivil').value = objCliente.estadoCivil;
                document.getElementById('idRg').value = objCliente.rg;
                document.getElementById('idDataNascimento').value = FormatarDataParaVisualizacao(objCliente.dataNascimento.toString());
                document.getElementById('idIdade').value = objCliente.idade;
                document.getElementById('idSalario').value = mreais(objCliente.salario.toString());
                document.getElementById('idEmail').value = objCliente.email;
                document.getElementById('idDdd').value = objCliente.ddd;
                document.getElementById('idFone').value = objCliente.fone;
                document.getElementById('idLogradouro').value = objCliente.logradouro;
                document.getElementById('idNumero').value = objCliente.numero;
                document.getElementById('idComplemento').value =  objCliente.complemento;
                document.getElementById('idBairro').value = objCliente.bairro;
                document.getElementById('idCidade').value = objCliente.cidade;
                document.getElementById('idCep').value =  objCliente.cep;
                document.getElementById('idTermo').checked = objCliente.termo;
                document.getElementById('idObservacao').value = objCliente.observacao;

                marcarEstado(objCliente.estado);

            }
            else
            {
                toastr.error("Falha ao realizar Operação");
                let dadosErro = JSON.parse(xhr.response);
                
                let msg = ''
                for (let index = 0; index < dadosErro.errors.length; index++) {
                    erros.push(dadosErro.errors[index].mensagem);
                    
                } 
                
                executarMsgErro();
            }
        }
    }

    xhr.send();
}

function validarDados()
{
    erros = [];
    if(!validarCampoPreenchido(document.getElementById('idNome').value, 5))
        erros.push('Nome inválido!');

    if(!validarCampoPreenchido(document.getElementById('idCpfCnpj').value, 1))
        erros.push('CpfCnpj deve ser preenchido!');

    if(!validaCpfCnpj(document.getElementById('idCpfCnpj').value))
        erros.push('CpfCnpj inválido!');        

    if(!validarCampoPreenchido(document.getElementById('idRg').value, 5))
        erros.push('Rg deve ser preenchido!');        

    if(document.getElementById('idMasculino').checked === document.getElementById('idFeminino').checked )
        erros.push('Sexo é obrigatório!');                

    if(document.getElementById('idEstadoCivil').value == 0)
        erros.push('Estado civil é obrigatório!');               

    if(!validarCampoPreenchido(document.getElementById('idDataNascimento').value, 10))
        erros.push('Data de nascimento é obrigatório!');            

    if(!validarCampoPreenchido(document.getElementById('idIdade').value, 1))
        erros.push('Idade é obrigatório!');            

    if(validarCampoPreenchido(document.getElementById('idDataNascimento').value, 10))
    {
        let dataNascimento = ajustarData(document.getElementById('idDataNascimento').value,'dd/MM/yyyy');
        let idade = calcularIdade(dataNascimento);
        if(idade != document.getElementById('idIdade').value)
            erros.push('Idade não corresponde a data de nascimento!');
    }

    if(!validarCampoPreenchido(document.getElementById('idSalario').value, 1))
        erros.push('Salário é obrigatório!');            

    if(!validarSalarioCompativel())
        erros.push('Salário incompatível!');  

    if(!validarCampoPreenchido(document.getElementById('idEmail').value, 1))
        erros.push('Email é obrigatório!');    
     
    if(!emailValido(document.getElementById('idEmail').value))
        erros.push('Email inválido!');            

    if(!validarCampoPreenchido(document.getElementById('idDdd').value, 1))
        erros.push('Ddd é obrigatório!');            

    if(!validarCampoPreenchido(document.getElementById('idFone').value, 1))
        erros.push('Fone é obrigatório!');            

    if(!validarCampoPreenchido(document.getElementById('idCep').value, 8))
        erros.push('Cep é obrigatório!'); 

    if(!validarCampoPreenchido(document.getElementById('idLogradouro').value, 1))
        erros.push('Logradouro é obrigatório!'); 

    if(!validarCampoPreenchido(document.getElementById('idNumero').value, 1))
        erros.push('Numero é obrigatório!'); 

   // if(!validarCampoPreenchido(document.getElementById('idComplemento').value, 1))
     //   erros.push('Complemento é obrigatório!'); 

    if(!validarCampoPreenchido(document.getElementById('idBairro').value, 1))
        erros.push('Bairro é obrigatório!'); 

    if(!validarCampoPreenchido(document.getElementById('idCidade').value, 1))
        erros.push('Cidade é obrigatório!'); 

    if(document.getElementById('idEstado').value == 0)
        erros.push('Estado é obrigatório!'); 

    if(!document.getElementById('idTermo').checked)
        erros.push('Termo é obrigatório!'); 

    if(!validarCampoPreenchido(document.getElementById('idSenha').value, 5))
        erros.push('Senha é obrigatório!'); 

    if((document.getElementById('idSenha').value) !== (document.getElementById('idConfirmaSenha').value))
        erros.push('Senha e confirma senha devem ser iguais!'); 

    if(document.getElementById('idObservacao').value !== '' )
    {
        if(validarCampoPreenchido(document.getElementById('idObservacao').value, 150))
            erros.push('Observação tem que ter no máximo 150 caracteres!'); 
    }
}

function validarSalarioCompativel()
{
	let salario = convertRealToFloat(document.getElementById('idSalario').value);
	return (salario - (salario * 0.06)) > 1500;
}

function marcarEstado(estado)
{
    let opts = document.getElementById('idEstado').options;
    for (let opt, j = 0; opt = opts[j]; j++) {
      if (  document.getElementById('idEstado').options[opt.value].textContent == estado) {
        document.getElementById('idEstado').selectedIndex = j;
        break;
      }
    }    
}


function addMsgErro(mensagem)
{
    var mylist = document.getElementById('id_ul_erros');
    mylist.insertAdjacentHTML('beforeend', '<li>' + mensagem+'</li>');
}

function removerMsgErros()
{
	let lista = document.getElementById('id_ul_erros');
	let itens = lista.getElementsByTagName('li');
	let qtd = itens.length
	for (let i = 0; i < qtd; i++) {
		lista.removeChild(itens[0])
	}
}

function fecharMensagensErros()
{
    removerMsgErros();
    document.getElementById('id-caixa_erro').style.display = 'none';
}