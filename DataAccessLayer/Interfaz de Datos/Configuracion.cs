using System;
using System.Web;
using System.Collections.Generic;


public class Configuracion
{
    private string direccServBD;
    private DateTime horaConciliaciones;
    private string direccServFTP;
    private string usuarioFTP;
    private string contraseñaFTP;
    private DateTime tiempoInactividad;
    private DateTime horaInicioPetic;
    private string direccSalvaBD;    
    private DateTime horaSalva;
    private string impresoraPin;
    private string impresoraTarjeta;

    //cambios nuevos Raul, agregadas estas 2 propiedades
    private string usuarioBD;
    private string contrasenaBD;

    

    
    

    public Configuracion() 
    {
        horaConciliaciones = new DateTime(1900, 1, 1, 20, 1, 1);
        HoraInicioPetic = new DateTime(1900, 1, 1, 20, 1, 1);
        horaSalva = new DateTime(1900, 1, 1, 20, 1, 1);
        tiempoInactividad = new DateTime(1900, 1, 1, 20, 1, 1);
    }
    public Configuracion(string direccServBD, DateTime horaConciliaciones, string direccServFTP,
        string usuarioFTP, string contraseñaFTP, DateTime tiempoInactividad, string direccSalvaBD, 
        DateTime horaInicioPetic, DateTime horaSalva, string imprPin, string imprTarj) // Raul- usuarioBD y ContrasenaBD agregados para poder copiar a la BD los ficheros servicios
    {
        this.tiempoInactividad = tiempoInactividad;
        this.direccSalvaBD = direccSalvaBD;
        this.direccServBD = direccServBD;
        this.direccServFTP = direccServFTP;
        this.horaConciliaciones = horaConciliaciones;
        this.usuarioFTP = usuarioFTP;
        this.contraseñaFTP = contraseñaFTP;
        this.horaInicioPetic = horaInicioPetic;
        this.horaSalva = horaSalva;
        this.ImpresoraPin = imprPin;
        this.ImpresoraTarjeta = imprTarj;
        //this.usuarioBD = usuarioBD;// Raul
        //this.contrasenaBD = contrasenaBD;//Raul

    }

    public string DireccServBD
    {
        get
        {
            return direccServBD;
        }
        set
        {
            direccServBD = value;
        }
    }

    public string UsuarioBD // Raul
    {
        get { return usuarioBD; }
        set { usuarioBD = value; }
    }

    public string ContrasenaBD // Raul
    {
        get { return contrasenaBD; }
        set { contrasenaBD = value; }
    }

    public DateTime HoraConciliaciones
    {
        get 
        {
            return horaConciliaciones;
        }
        set 
        {
            horaConciliaciones = value;
        }
    } 
    public string DireccionServidorFtp
    {
        get
        {
            return direccServFTP;
        }
        set
        {
            direccServFTP = value;
        }
    }
    public string UsuarioFTP 
    {
        get 
        {
            return usuarioFTP;
        }
        set 
        {
            usuarioFTP = value;
        }
    }
    public string ContraseñaFTP 
    {
        get 
        {
            return contraseñaFTP;
        }
        set 
        {
            contraseñaFTP = value;
        }
    }
    public DateTime TiempoInactividad
    {
        get 
        {
            return tiempoInactividad;
        }
        set
        {
            tiempoInactividad = value;
        } 
    }
    public string DireccSalvaBD
    {
        get
        {
            return direccSalvaBD;
        }
        set
        {
            direccSalvaBD = value;
        }
    }

    public DateTime HoraInicioPetic
    {
        get
        {
            return horaInicioPetic;
        }
        set
        {
            horaInicioPetic = value;
        }
    }

    public DateTime HoraSalva 
    {
        get 
        {
            return this.horaSalva;
        }
        set 
        {
            horaSalva = value;
        }    
    }
    public string ImpresoraTarjeta
    {
        get { return impresoraTarjeta; }
        set { impresoraTarjeta = value; }
    }
    public string ImpresoraPin
    {
        get { return impresoraPin; }
        set { impresoraPin = value; }
    }

}
