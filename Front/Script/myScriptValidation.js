

function validarCampoPreenchido(valor, quantidadePermitidaCaracteres)
{
    return valor.length >= quantidadePermitidaCaracteres;
}

function replaceAll(str, de, para){
    let pos = str.indexOf(de);
    while (pos > -1){
		str = str.replace(de, para);
		pos = str.indexOf(de);
	}
    return (str);
}

function validaCpfCnpj(valorCpfCnpj) {

    if(valorCpfCnpj == '')
        return false;

        let numberPattern = /\d+/g;

    let cpfcnpj = valorCpfCnpj.match( numberPattern ).join('');
    let cpfcnpjValidar = cpfcnpj.toString().split('');

    if(validaCpf(cpfcnpjValidar))
        return true;
    if(validaCnpj(cpfcnpjValidar))
        return true;

    return false;        
 }

 function validaCpf(cpf) {

    
    let v1 = 0;
    let v2 = 0;
    let aux = false;
    
    for (let i = 1; cpf.length > i; i++) {
        if (cpf[i - 1] != cpf[i]) {
            aux = true;   
        }
    } 
    
    if (aux == false) {
        return false; 
    } 
    
    for (let i = 0, p = 10; (cpf.length - 2) > i; i++, p--) {
        v1 += cpf[i] * p; 
    } 
    
    v1 = ((v1 * 10) % 11);
    
    if (v1 == 10) {
        v1 = 0; 
    }
    
    if (v1 != cpf[9]) {
        return false; 
    } 
    
    for (let i = 0, p = 11; (cpf.length - 1) > i; i++, p--) {
        v2 += cpf[i] * p; 
    } 
    
    v2 = ((v2 * 10) % 11);
    
    if (v2 == 10) {
        v2 = 0; 
    }
    
    if (v2 != cpf[10]) {
        return false; 
    } else {   
        return true; 
    }
 }


 function validaCnpj(cnpj) {
    let v1 = 0;
    let v2 = 0;
    let aux = false;
    
    for (let i = 1; cnpj.length > i; i++) {
        if (cnpj[i - 1] != cnpj[i]) {
            aux = true;   
        }
    } 
    
    if (aux == false) {
        return false; 
    } 
    
    for (let i = 0, p = 10; (cnpj.length - 2) > i; i++, p--) {
        v1 += cnpj[i] * p; 
    } 
    
    v1 = ((v1 * 10) % 11);
    
    if (v1 == 10) {
        v1 = 0; 
    }
    
    if (v1 != cnpj[9]) {
        return false; 
    } 
    
    for (let i = 0, p = 11; (cnpj.length - 1) > i; i++, p--) {
        v2 += cnpj[i] * p; 
    } 
    
    v2 = ((v2 * 10) % 11);
    
    if (v2 == 10) {
        v2 = 0; 
    }
    
    if (v2 != cnpj[10]) {
        return false; 
    } else {   
        return true; 
    }
 }


function emailValido (email) {
    if(email == '')
        return false;

    return new RegExp(/^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@\w+([-.]\w+)*\.\w+([-.]\w+)*/).exec(email) != null;
}

function convertRealToFloat(valor)
{
    valor = valor.replace('R$','');
    valor = valor.replace(' ','');
    valor = valor.replace('.','');
    valor = valor.replace(',','.');
    return parseFloat(valor);
}



function mascaraData(evento, objeto){
    let keypress=(window.event)?event.keyCode:evento.which;
	campo = eval (objeto);
	if (campo.value == '00/00/0000')
	{
		campo.value=""
	}
 
	caracteres = '0123456789';
	separacao1 = '/';
	separacao2 = ' ';
	separacao3 = ':';
	conjunto1 = 2;
	conjunto2 = 5;
	conjunto3 = 10;
	conjunto4 = 13;
	conjunto5 = 16;
	if ((caracteres.search(String.fromCharCode (keypress))!=-1) && campo.value.length < (19))
	{
		if (campo.value.length == conjunto1 )
	    	campo.value = campo.value + separacao1;
		else if (campo.value.length == conjunto2)
    		campo.value = campo.value + separacao1;
	}
	else
		event.returnValue = false;
    
}

function somenteNumerosInteiros(evt) {

    
    let theEvent = evt || window.event;
    let key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode( key );
    //let regex = /[0-9]|\./;
    let regex = /[0-9]/;
    if( !regex.test(key) ) {
      theEvent.returnValue = false;
      if(theEvent.preventDefault) theEvent.preventDefault();
    }
}



function moeda(evt) {
    let theEvent = evt || window.event;
    let key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode( key );
    let regex = /[0-9]|\,|\./;
   
    if( !regex.test(key) ) {
      theEvent.returnValue = false;
      if(theEvent.preventDefault) theEvent.preventDefault();
    }
}

function mreais(v){
    v=v.replace(/\D/g,"")                        
    v=v.replace(/(\d{2})$/,",$1")             
    v=v.replace(/(\d+)(\d{3},\d{2})$/g,"$1.$2")   
    return v
}



function FormatarDataParaEnvio(data) {
    let dia  = data.split("/")[0];
    let mes  = data.split("/")[1];
    let ano  = data.split("/")[2];
  
    return ano + '-' + ("0"+mes).slice(-2) + '-' + ("0"+dia).slice(-2);
    
  }

  function FormatarDataParaVisualizacao(data) {
    let dia  = data.split("-")[2].substring(0, 2);
    let mes  = data.split("-")[1];
    let ano  = data.split("-")[0];
  
    return ("0"+dia).slice(-2)  + '/' + ("0"+mes).slice(-2) + '/' + ano;
    // Utilizo o .slice(-2) para garantir o formato com 2 digitos.
  } 

function ajustarData (dataBr ,format) {
    let normalized = dataBr.replace(/[^a-zA-Z0-9]/g, '-');
    let normalizedFormat = format.toLowerCase().replace(/[^a-zA-Z0-9]/g, '-');
    let formatItems = normalizedFormat.split('-');
    let dateItems = normalized.split('-');

    let monthIndex = formatItems.indexOf("mm");
    let dayIndex = formatItems.indexOf("dd");
    let yearIndex = formatItems.indexOf("yyyy");
    let hourIndex = formatItems.indexOf("hh");
    let minutesIndex = formatItems.indexOf("ii");
    let secondsIndex = formatItems.indexOf("ss");

    let today = new Date();

    let year = yearIndex > -1 ? dateItems[yearIndex] : today.getFullYear();
    let month = monthIndex > -1 ? dateItems[monthIndex] - 1 : today.getMonth() - 1;
    let day = dayIndex > -1 ? dateItems[dayIndex] : today.getDate();

    let hour = hourIndex > -1 ? dateItems[hourIndex] : today.getHours();
    let minute = minutesIndex > -1 ? dateItems[minutesIndex] : today.getMinutes();
    let second = secondsIndex > -1 ? dateItems[secondsIndex] : today.getSeconds();

    return new Date(year, month, day, hour, minute, second);
}

function calcularIdade(dataNascimento) {
    let today = new Date();

    let age = today.getFullYear() - dataNascimento.getFullYear();
    let m = today.getMonth() - dataNascimento.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < dataNascimento.getDate())) {
        age--;
    }
    return age;
}


function preencherSelect(obj, dados) {
    let self = this;

    while (obj.length > 0) {
        obj.remove(0);
    }

    let qtditens = dados.length;

    for (index = 0; index < qtditens; index++) {
        let opt = document.createElement("option");
        opt.value = dados[index].key;
        opt.text = dados[index].value;
        obj.add(opt, obj.options[index]);
    }

    
}