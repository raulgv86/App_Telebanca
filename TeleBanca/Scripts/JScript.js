// JScript File
var Cadena = "";

function AsignarIrSiguiente( pWebUserControl, pComponentId)
{
   var tempcad = Cadena;
   
   var comp = document.getElementById(pWebUserControl + pComponentId);
    Cadena = comp.value + ut;
    ut = '';

 if(Cadena.length >= arguments[2]){
        document.getElementById(pWebUserControl + arguments[3]).focus();
      }
      
 if(Cadena.length > arguments[2]){
        comp.value = Cadena.substring(0,arguments[2]); 
      }else{
      comp.value = Cadena;
      }
      
    Cadena = tempcad;

}

var ut;

function AsignarIrSiguientePAN(pWebUserControl, pComponentId) {
    var tempcad = Cadena;
    var ut

    var comp = document.getElementById(pWebUserControl + pComponentId);
    Cadena = comp.value + ut;
    ut = '';

    if (Cadena.length >= arguments[2]) {
        document.getElementById(pWebUserControl + arguments[3]).focus();
    }

    if (Cadena.length > arguments[2]) {
        comp.value = Cadena.substring(0, arguments[2]);
    } else {
        comp.value = Cadena;
    }

    Cadena = tempcad;

}

function SoloNumeros()
{
ut = event.keyCode;
event.keyCode = null;
switch (ut) 
 {
   case 48:ut='0';break;
   case 49:ut='1';break;
   case 50:ut='2';break;
   case 51:ut='3';break;
   case 52:ut='4';break;
   case 53:ut='5';break;
   case 54:ut='6';break;
   case 55:ut='7';break;
   case 56:ut='8';break;
   case 57:ut='9';break;
   default : ut = '';
 }
}

function RectComponente( pWebUserControl, pComponentId)
{
    if(Cadena != "")
      document.getElementById(pWebUserControl + pComponentId).value = Cadena;
    Cadena = "";
}

var PopURL="";
var PopWin=null;
var openpopwin=null;

function openWindow(url,width,height)
{
    width -= 12;
    height -= 31;
    PopURL=url;
    if(!PopWin || PopWin.closed)
    {
        PopWin=PopWinOpen(width,height);
    }
    else 
    {
        PopWin.close();
        PopWin=null;
        PopWin=PopWinOpen(width,height);
    }
}

function PopWinOpen(width,height)
{
    var x =(screen.availWidth-width)/2;
    var y =(screen.availHeight-height)/2;
    var winfeatures="width="+width+",height="+height+",top="+y+",left="+x+",menubar=yes,scrollbars=yes, resizable";
    openpopwin=null;
    openpopwin=window.open(PopURL,"remote",winfeatures);
    return openpopwin;
}

function DesactivarBoton(pWebUserControl, pComponentId)
{
      document.getElementById(pWebUserControl + pComponentId).Enabled = false;
}

function MensajeBienvenida()
{
    today = new Date()
    if(today.getMinutes() < 10){
    pad = "0"}
    else
    pad = "";
    document.write ;if((today.getHours() >=6) && (today.getHours() <=9)){
    document.write("<small><font color='Black' face='Arial'size='2'>" + "¡Buen Día! ")
    }
    if((today.getHours() >=10) && (today.getHours() <=11)){
    document.write("<small><font color='Black' face='Arial'size='2'>" + "¡Buen Día! ")
    }
    if((today.getHours() >=12) && (today.getHours() <=19)){
    document.write("<small><font color='Black' face='Arial'size='2'>" + "¡Buenas Tardes! ")
    }
    if((today.getHours() >=20) && (today.getHours() <=23)){
    document.write("<small><font color='Black' face='Arial'size='2'>" + "¡Buenas Noches! ")
    }
    if((today.getHours() >=0) && (today.getHours() <=3)){
    document.write("<small><font color='Black' face='Arial'size='2'>" + "¡Buenas Noches! ")
    }
    if((today.getHours() >=4) && (today.getHours() <=5)){
    document.write("<small><font color='Black' face='Arial'size='2'>" + "¡Buenas Noches! ")
    }
 
    var mydate = new Date()
    var year = mydate.getYear()
    if (year < 1000)
    year += 1900
    var day = mydate.getDay()
    var month = mydate.getMonth()
    var daym = mydate.getDate()
    if (daym == 1)
    daym = daym + "ro" 
    var dayarray = new Array("Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado")
    var montharray = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre")
    document.write("<small><font color='Black' face='Arial'size='2'>" + "Hoy es "+ dayarray[day] + " " + daym + " de " + montharray[month] + " de " + year + "</font></small>")
  }  
  
  function updateClock ()
  {
  var currentTime = new Date ();

  var currentHours = currentTime.getHours ( );
  var currentMinutes = currentTime.getMinutes ( );
  var currentSeconds = currentTime.getSeconds ( );

  // Pad the minutes and seconds with leading zeros, if required
  currentMinutes = ( currentMinutes < 10 ? "0" : "" ) + currentMinutes;
  currentSeconds = ( currentSeconds < 10 ? "0" : "" ) + currentSeconds;

  // Choose either "AM" or "PM" as appropriate
  var timeOfDay = ( currentHours < 12 ) ? "AM" : "PM";

  // Convert the hours component to 12-hour format if needed
  currentHours = ( currentHours > 12 ) ? currentHours - 12 : currentHours;

  // Convert an hours component of "0" to "12"
  currentHours = ( currentHours == 0 ) ? 12 : currentHours;

  // Compose the string for display
  var currentTimeString = currentHours + ":" + currentMinutes + ":" + currentSeconds + " " + timeOfDay;

  // Update the time display
  document.getElementById("clock").firstChild.nodeValue = currentTimeString;
 }
function Money(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true; //tecla backspace y delete porque el delete lo asume con el código 8
    if (tecla == 9) return true; //tecla tabular horizontal
    if (tecla == 46) return true; //tecla punto (.)
    if (tecla == 127) return true; //tecla delete    
    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}
//Solo Números
function LP_data(e)
 {
     tecla = (document.all) ? e.keyCode : e.which;
     if (tecla == 8) return true; //tecla backspace
     if (tecla == 9) return true; //tecla tabular horizontal
     if (tecla == 127) return true; //tecla delete    
     patron = /[0-9]/;
     te = String.fromCharCode(tecla);
     return patron.test(te);
 }