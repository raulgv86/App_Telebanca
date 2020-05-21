using System;
using System.Web;
using System.Collections.Generic;

public class RolPersistente
{
    /// <summary>
    /// Lista de funcionalidades
    /// </summary>
    private List<string> funcionalidades;
    private List<string> nombreMenu;
    private List<int> valorMenu;
    private List<int> modulo;

    /// <summary>
    /// Nombre del Roll
    /// </summary>
    private string nombre;

    public RolPersistente()
    {
        funcionalidades = new List<string>();
        nombreMenu = new List<string>();
        valorMenu = new List<int>();
        modulo = new List<int>();
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }
    private string descripcion;

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public List<string> Funcionalidades
    {
        get
        {
            return funcionalidades;
        }
        set
        {
            funcionalidades = value;
        }
    }
    public List<string> NombreMenu
    {
        get
        {
            return nombreMenu;
        }
        set
        {
            nombreMenu = value;
        }
    }
    public List<int> ValorMenu
    {
        get
        {
            return valorMenu;
        }
        set
        {
            valorMenu = value;
        }
    }
    public List<int> Modulo
    {
        get
        {
            return modulo;
        }
        set
        {
            modulo = value;
        }
    }


}
