using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;


/// <summary>
/// Summary description for ManipuladorFTP
/// </summary>
public class ManipuladorFTP
{
    private string remoteHost, remotePath, remoteUser, remotePass, remotePathBD, remoteUserBD, remotePassBD;
    private int remotePort;
    private int remotePortBD;
         
     private int bytes, bytes2;
     private Socket clientSocket;

     private Socket socket_escuchador;
     private Socket socket_paraBD;
    
     private int retValue;
     private Boolean logined;
     private string reply, mes, mes2;

     private static int BLOCK_SIZE = 512;

     Byte[] buffer = new Byte[BLOCK_SIZE];
     Byte[] buffer2 = new Byte[BLOCK_SIZE];
     Encoding ASCII = Encoding.ASCII;

        public Boolean isLogined()
        {
            return logined;
        }

     public ManipuladorFTP()
     {
       remotePath  = "/";
       remotePort  = 21;
       remotePortBD = 139;
       logined    = false;

     }

    public string DireccionServidor
    {
        get{return remoteHost;}
        set { remoteHost = value; }
    }

    #region Propiedades agregadas (Raul)
    //CAMBIO REALIZADO POR MI(RAUL) PARA PROBAR LA CARGA DEL FICHERO AL SERVIDOR BD
    public string DireccionServBD 
    {
        get { return remotePathBD; }
        set { remotePathBD = value; }
    }

    public string Usuario_BD 
    {
        get { return remoteUserBD; }
        set { remoteUserBD = value; }
    }

    public string Contrasena_BD 
    {
        get { return remotePassBD; }
        set { remotePassBD = value; }
    }

    #endregion

    public string DirectorioRemoto
    {
        get{return remotePath;}
        set { remotePath = value; }
    }
    
    public string  UsuarioFTP
    {
        get{return remoteUser;}
        set { remoteUser = value; }
    }
   
    public string ClaveUsuarioFTP
    {
         get{return remotePass;}
         set { remotePass = value; }
    }
   
    public int PuertoRemoto
    {
        get{return remotePort;}
        set { remotePort = value; }
    }

    

     ///
     /// Return a string array containing the remote directory's file list.
     ///
     ///
     ///
     public string[] DarListadoFicheros(string mask)
     {

       if(!logined)
       {
         Conectarse();
       }

       Socket cSocket = CrearSockerParaDatos();

      MandarComando("NLST " + mask);

       if(!(retValue == 150 || retValue == 125))
       {
         throw new IOException(reply.Substring(4));
       }

       mes = "";

       while(true)
       {

         int bytes = cSocket.Receive(buffer, buffer.Length, 0);
         mes += ASCII.GetString(buffer, 0, bytes);

         if(bytes < buffer.Length)
         {
           break;
         }
       }


         mes=mes.Replace("\r","");
         char[] seperator = { '\n' };
       string[] mess = mes.Split(seperator);

       cSocket.Close();

       LeerRespuesta();

       if(retValue != 226)
       {
         throw new IOException(reply.Substring(4));
       }
       return mess;

     }


  

     ///
     /// Return the size of a file in the server.
     ///
     public long DarTamañoFichero(string fileName)
     {

       if(!logined)
       {
         Conectarse();
       }

       MandarComando("SIZE " + fileName);
       long size=0;

         //213 Estado del fichero.
       if(retValue == 213)
       {
         size = Int64.Parse(reply.Substring(4));
       }
       else
       {
         throw new IOException(reply.Substring(4));
       }

       return size;

     }

     ///
     /// Login to the remote server.
     ///
    public void Conectarse()
     {

       clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
       IPEndPoint ep = new IPEndPoint(Dns.Resolve(remoteHost).AddressList[0], remotePort);
     
       try
       {
         clientSocket.Connect(ep);
       }
       catch(Exception)
       {
         throw new IOException("Couldn't connect to remote server");
       }

       LeerRespuesta();
       if(retValue != 220)
       {
         CerrarConeccion();
         throw new IOException(reply.Substring(4));
       }
       MandarComando("USER "+remoteUser);

       if( !(retValue == 331 || retValue == 230) )
       {
         Limpiar();
         throw new IOException(reply.Substring(4));
       }

       if( retValue != 230 )
       {
           MandarComando("PASS "+remotePass);
         if( !(retValue == 230 || retValue == 202) )
         {
           Limpiar();
           throw new IOException(reply.Substring(4));
         }
       }

       logined = true;

      CambiarDeDirectorioRemoto(remotePath);

     }


    public void Conectarse_BD()
    {
        
        socket_paraBD = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(Dns.Resolve(remotePathBD).AddressList[0], remotePortBD);
     
       try
       {
           socket_paraBD.Connect(ep);
           
       }
       catch(Exception)
       {
         throw new IOException("Couldn't connect to remote server");
       }

       LeerRespuesta2();
       if(retValue != 220)
       {
         CerrarConeccion();
         throw new IOException(reply.Substring(4));
       }
       MandarComando("USER "+remoteUser);

       if( !(retValue == 331 || retValue == 230) )
       {
         Limpiar();
         throw new IOException(reply.Substring(4));
       }

       if( retValue != 230 )
       {
           MandarComando("PASS "+remotePass);
         if( !(retValue == 230 || retValue == 202) )
         {
           Limpiar();
           throw new IOException(reply.Substring(4));
         }
       }

       logined = true;

      CambiarDeDirectorioRemoto(remotePath);
 
    }

     ///
     /// If the value of mode is true, set binary mode for downloads.
     /// Else, set Ascii mode.
     ///
     ///
     public void CambiarAModoBinario(Boolean mode)
     {

       if(mode)
       {
         MandarComando("TYPE I");
       }
       else
       {
         MandarComando("TYPE A");
       }
       if (retValue != 200)
       {
         throw new IOException(reply.Substring(4));
       }
     }

     ///
     /// Download a file to the Assembly's local directory,
     /// keeping the same file name.
     ///
     ///
     public void Descargar1(string remFileName)
     {
         Descargar4(remFileName, "", false);
     }

     ///
     /// Download a remote file to the Assembly's local directory,
     /// keeping the same file name, and set the resume flag.
     ///
     ///
     ///
    public void Descargar2(string remFileName, Boolean resume)
     {
         Descargar4(remFileName, "", resume);
     }

     ///
     /// Download a remote file to a local file name which can include
     /// a path. The local file name will be created or overwritten,
     /// but the path must exist.
     ///
     ///
     ///
    public void Descargar3(string remFileName, string locFileName)
     {
         Descargar4(remFileName, locFileName, false);
     }

     ///
     /// Download a remote file to a local file name which can include
     /// a path, and set the resume flag. The local file name will be
     /// created or overwritten, but the path must exist.
     ///
    public void Descargar4(string remFileName, string locFileName, Boolean resume)
     {
       if(!logined)
       {
         Conectarse();
       }

       CambiarAModoBinario(true);

      // Console.WriteLine("Downloading file "+remFileName+" from "+remoteHost + "/"+remotePath);

       if (locFileName.Equals(""))
       {
         locFileName = remFileName;
       }

       if(!File.Exists(locFileName))
       {
        
 Stream st = File.Create(locFileName);

 #region Modificado por Raul

 #endregion

 st.Close();
         
        
       }

       FileStream output = new FileStream(locFileName,FileMode.Open);

       Socket cSocket = CrearSockerParaDatos();

       long offset = 0;

       if(resume)
       {
         offset = output.Length;
         if(offset > 0 )
         {
           MandarComando("REST "+offset);
           if(retValue != 350)
           {
            throw new IOException(reply.Substring(4));
             //Some servers may not support resuming.
            }
         }

         if(offset > 0)
         {
          long npos = output.Seek(offset,SeekOrigin.Begin);
         }
       }

       MandarComando("RETR " + remFileName);

       if(!(retValue == 150 || retValue == 125))
       {
         throw new IOException(reply.Substring(4));
       }

       while(true)
       {

         bytes = cSocket.Receive(buffer, buffer.Length, 0);
         output.Write(buffer,0,bytes);

         if(bytes <= 0)
         {
           break;
         }
       }

       output.Close();
       if (cSocket.Connected)
       {
           cSocket.Close();
       }

       LeerRespuesta();

       if( !(retValue == 226 || retValue == 250) )
       {
         throw new IOException(reply.Substring(4));
       }

     }

     ///
     /// Upload a file.
     ///
     ///
     public void SubirAlServidor(string fileName)
     {
         SubirAlServidor(fileName, false);
     }

     ///
     /// Upload a file and set the resume flag.
     ///
     ///
     ///
    public void SubirAlServidor(string fileName, Boolean resume)
     {

       if(!logined)
       {
         Conectarse();
       }

       Socket cSocket = CrearSockerParaDatos();
       long offset=0;

       if(resume)
       {

         try
         {

           CambiarAModoBinario(true);
           offset = DarTamañoFichero(fileName);

         }
         catch(Exception)
         {
           offset = 0;
         }
       }

       if(offset > 0 )
       {
         MandarComando("REST " + offset);
         if(retValue != 350)
         {
           //throw new IOException(reply.Substring(4));
           //Remote server may not support resuming.
           offset = 0;
         }
       }
       //STOR crea el fichero en el servidor o lo sobre escribe
       MandarComando("STOR "+Path.GetFileName(fileName));
       
         //125 La conexión de datos ya está abierta; comenzando transferencia. 
       //  150 Conexion abierta.
       if( !(retValue == 125 || retValue == 150) )
       {
         throw new IOException(reply.Substring(4));
       }

       // open input stream to read source file
       FileStream input = new FileStream(fileName,FileMode.Open);

       if(offset != 0)
       {

      /*   if(debug)
         {
           Console.WriteLine("seeking to " + offset);
         }*/
         input.Seek(offset,SeekOrigin.Begin);
       }

     //  Console.WriteLine("Uploading file "+fileName+" to "+remotePath);

       while ((bytes = input.Read(buffer,0,buffer.Length)) > 0)
       {

         cSocket.Send(buffer, bytes, 0);

       }
       input.Close();


       if (cSocket.Connected)
       {
           cSocket.Close();
       }

       LeerRespuesta();
       // 226 Cerrando la conexión de datos. La acción sobre fichero requerida ha sido correcta (por ejemplo, una transferencia o interrupción). 
       //250 La acción sobre fichero solicitado finalizó correctamente
         if( !(retValue == 226 || retValue == 250) )
       {
         throw new IOException(reply.Substring(4));
       }
     }

     ///
     /// Delete a file from the remote FTP server.
     ///
     ///
     public void BorrarFicheroRemoto(string fileName)
     {

       if(!logined)
       {
         Conectarse();
       }

       MandarComando("DELE "+fileName);

       if(retValue != 250)
       {
         throw new IOException(reply.Substring(4));
       }

     }

     ///
     /// Rename a file on the remote FTP server.
     ///
     ///
     ///
    public void RenombrarFicheroRemoto(string oldFileName, string newFileName)
     {

       if(!logined)
       {
         Conectarse();
       }

       MandarComando("RNFR "+oldFileName);

       if(retValue != 350)
       {
         throw new IOException(reply.Substring(4));
       }

       //  known problem
       //  rnto will not take care of existing file.
       //  i.e. It will overwrite if newFileName exist
       MandarComando("RNTO "+newFileName);
       if(retValue != 250)
       {
         throw new IOException(reply.Substring(4));
       }

     }

     ///
     /// Create a directory on the remote FTP server.
     ///
     ///
    public void HacerDirectorioRemoto(string dirName)
     {

       if(!logined)
       {
         Conectarse();
       }

       MandarComando("MKD "+dirName);

       if(retValue != 250)
       {
         throw new IOException(reply.Substring(4));
       }

     }

     ///
     /// Delete a directory on the remote FTP server.
     ///
     ///
     public void BorrarDirectorioRemoto(string dirName)
     {

       if(!logined)
       {
         Conectarse();
       }

       MandarComando("RMD "+dirName);

       if(retValue != 250)
       {
         throw new IOException(reply.Substring(4));
       }

     }

     ///
     /// Change the current working directory on the remote FTP server.
     ///
     ///
    public void CambiarDeDirectorioRemoto(string dirName)
     {

       if(dirName.Equals("."))
       {
         return;
       }

       if(!logined)
       {
         Conectarse();
       }

       MandarComando("CWD "+dirName);

       if(retValue != 250)
       {
         throw new IOException(reply.Substring(4));
       }

       this.remotePath = dirName;

     }

     ///
     /// Retroceder a la carpeta anterior en el servidor
     ///
        public void Retroceder()
        {
            if (!remotePath.Equals("/"))
            {
                int pos = remotePath.LastIndexOf('/');
                string aux;
                if (pos == 0)
                    aux = "/";
                else
                    aux = remotePath.Substring(0, pos);
                this.CambiarDeDirectorioRemoto(aux);
            }
            else
            {
                throw new IOException("Estas en el directorio base...");
            }
            
        }

        ///
        /// Avanzar a la carpeta especificada en el servidor
        ///
        public void Avanzar(string carpeta)
        {
            if (remotePath.Equals("/"))
            {
                string aux = remotePath + carpeta;
                this.CambiarDeDirectorioRemoto(aux);
            }
            else
            {
                string aux = remotePath + "/" + carpeta;
                this.CambiarDeDirectorioRemoto(aux);
            }

        }



     ///
     /// Close the FTP connection.
     ///
     public void CerrarConeccion()
     {

       if( clientSocket != null )
       {
         MandarComando("QUIT");
       }

       Limpiar();
     }

    
     private void LeerRespuesta()
     {
       mes = "";
       reply = LeerLinea();
       retValue = Int32.Parse(reply.Substring(0,3));
     }

     private void LeerRespuesta2() // Raul
     {
         mes = "";
         reply = LeerLinea2();
         retValue = Int32.Parse(reply.Substring(0, 3));
     }

     private void Limpiar()
     {
       if(clientSocket!=null)
       {
         clientSocket.Close();
         clientSocket = null;
       }
       logined = false;
     }

     private string LeerLinea()
     {
       while(true)
       {
         bytes = clientSocket.Receive(buffer, buffer.Length, 0);
         mes += ASCII.GetString(buffer, 0, bytes);
         if(bytes < buffer.Length)//hasta que mes tenga todo lo que se mando
         {
           break;
         }
       }

       char[] seperator = {'\n'};
       string[] mess = mes.Split(seperator);

       if(mes.Length > 2)
       {
         mes = mess[mess.Length-2];
       }
       else
       {
         mes = mess[0];
       }
       string h = mes.Substring(3, 1);
       if(!mes.Substring(3,1).Equals(" "))//si es diferente de espacio
       {
         return LeerLinea();
       }

      return mes;
     }

     private string LeerLinea2() // Raul
     {
         while (true)
         {
             bytes2 = socket_paraBD.Receive(buffer2, buffer2.Length, 0);
             mes2 += ASCII.GetString(buffer2, 0, bytes);
             if (bytes < buffer.Length)//hasta que mes tenga todo lo que se mando
             {
                 break;
             }
         }

         char[] seperator = { '\n' };
         string[] mess = mes2.Split(seperator);

         if (mes2.Length > 2)
         {
             mes2 = mess[mess.Length - 2];
         }
         else
         {
             mes2 = mess[0];
         }
         string h = mes.Substring(3, 1);
         if (!mes2.Substring(3, 1).Equals(" "))//si es diferente de espacio
         {
             return LeerLinea2();
         }

         return mes2;
     }

     private void MandarComando(String command)
     {

       Byte[] cmdBytes = 
       Encoding.ASCII.GetBytes((command+"\r\n").ToCharArray());
       
           clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
       
       LeerRespuesta();
     }

     private void MandarComando2(String command) // Raul
     {

         Byte[] cmdBytes =
         Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());

         clientSocket.Send(cmdBytes, cmdBytes.Length, 0);

         LeerRespuesta2();
     }

        public void obtenerRemotePath()
        {
            MandarComando2("pwd");
            if (retValue == 257)
            {
                int ini = reply.IndexOf('"');
                int fin = reply.LastIndexOf('"');
                string aux = reply.Substring(ini, fin - ini);
                remotePath = aux;
            }
            else
            {
                throw new IOException(" No se pudo obtener el directorio ");
            }
        }
     private Socket CrearSockerParaDatos()
     {

       MandarComando("PASV");
         //227 Iniciando modo pasivo. 
       if(retValue != 227)
       {
         throw new IOException(reply.Substring(4));
       }

       int index1 = reply.IndexOf('(');
       int index2 = reply.IndexOf(')');
       string ipData = reply.Substring(index1+1,index2-index1-1);
       int[] parts = new int[6];

       int len = ipData.Length;
       int partCount = 0;
       string buf="";

       for (int i = 0; i < len && partCount <= 6; i++)
       {

         char ch = Char.Parse(ipData.Substring(i,1));
         if (Char.IsDigit(ch))
           buf+=ch;
         else if (ch != ',')
         {
           throw new IOException("Malformed PASV reply: " + reply);
         }

         if (ch == ',' || i+1 == len)
         {

           try
           {
             parts[partCount++] = Int32.Parse(buf);
             buf="";
           }
           catch (Exception)
           {
             throw new IOException("Malformed PASV reply: " + reply);
           }
         }
       }

       string ipAddress = parts[0] + "."+ parts[1]+ "." + parts[2] + "." + parts[3];

       int port = (parts[4] << 8) + parts[5];

       Socket s = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
       IPEndPoint ep = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);
     

       try
       {
         s.Connect(ep);
       }
       catch(Exception)
       {
         throw new IOException("Can't connect to remote server");
       }

       return s;
     }
    
}
