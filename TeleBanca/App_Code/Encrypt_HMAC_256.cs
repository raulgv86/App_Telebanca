using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Encrypt_HMAC_256
/// </summary>
public class Encrypt_HMAC_256
{
	public Encrypt_HMAC_256()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string CreateToken(string mensaje, string llave_secreta)
    {
        string clave_encrypt = "";
        llave_secreta = llave_secreta ?? "";
        byte[] llaveByte = Encoding.ASCII.GetBytes(llave_secreta);
        byte[] mensajeByte = Encoding.ASCII.GetBytes(mensaje);

        using (var hmac256 = new HMACSHA256(llaveByte))
        {
            byte[] hash_mensaje = hmac256.ComputeHash(mensajeByte);
            //clave_encrypt = Convert.ToBase64String(hash_mensaje);
            clave_encrypt = BitConverter.ToString(hash_mensaje);
        }

        return clave_encrypt;
    }
}