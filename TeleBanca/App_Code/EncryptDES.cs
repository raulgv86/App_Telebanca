using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;


/// <summary>
/// Summary description for EncryptDES
/// </summary>
public class EncryptDES
{
    //public string valor = "01234567";
    public string hexares;
    public byte[] key, keyQ, IV, cifrado, newLlave, cifradoCort;

    public enum Modo
    {
        ENCRIPTAR,
        DESENCRIPTAR
    };

    public byte[] _vectorInicializacion { get; set; }
    public byte[] _Key { get; set; }

    public EncryptDES()
    {

    }

    public EncryptDES(byte[] vector, byte[] key)
    {
        this._vectorInicializacion = vector;
        this._Key = key;
    }

    public byte[] DES_Encriptar(string cadena)
    {
        byte[] cadena_bytes = Encoding.UTF8.GetBytes(cadena);

        using (var des = new DESCryptoServiceProvider())
        {
            
            des.IV = this._vectorInicializacion;
            des.Key = this._Key;
            des.Mode = CipherMode.CBC;
            
            using (var memoryStream = new MemoryStream())
            {
                CryptoStream cryptoStream = null;

                cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(cadena_bytes, 0, cadena_bytes.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }
        return null;
    }

    #region DES: Metodos copiados del ejemplo enviado por REDSA para la encriptacion del PIN Digital

    public static int GetHexVal(char hex)
    {
        int val = (int)hex;
        return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));

    }

    //metodo que convierte la llave pasada por parametro a binario
    public static byte[] StringToBinary(string hex)
    {
        if (hex.Length % 2 == 1)
            throw new Exception("Problema");

        byte[] arr = new byte[hex.Length >> 1];
        for (int i = 0; i < hex.Length >> 1; ++i)
        {
            arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));

        }

        return arr;

    }

    public static string ByteArrString(byte[] ba)
    {
        /*  StringBuilder hex = new StringBuilder(ba.Length * 2);
          foreach (byte b in ba)
          {
              hex.AppendFormat("0:x2", b);
          }
         hex.ToString();
         */


        return BitConverter.ToString(ba).Replace("-", "");
    }

    public static byte[] ConvertHExtoByte(string hex)
    {
        int numberchar = hex.Length;
        byte[] bytes = new byte[numberchar / 2];
        for (int i = 0; i < numberchar; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

        return bytes;
    }


    public static byte[] Encrypt_DES(Modo mode, byte[] key, byte[] data)
    {
        using (var tDESCsp = new DESCryptoServiceProvider())
        {
            tDESCsp.Key = key;
            tDESCsp.Mode = CipherMode.ECB;
            tDESCsp.Padding = PaddingMode.None;

            using (var ms = new MemoryStream())
            {

                CryptoStream cs = null;
                if (mode == Modo.ENCRIPTAR)
                    cs = new CryptoStream(ms, tDESCsp.CreateEncryptor(), CryptoStreamMode.Write);
                else
                    if (mode == Modo.DESENCRIPTAR)
                        cs = new CryptoStream(ms, tDESCsp.CreateDecryptor(), CryptoStreamMode.Write);


                if (cs == null)
                    return null;

                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();
                return ms.ToArray();
            }
        }
        return null;
    }

    public static byte[] encrypt(string data, byte[] key, byte[] IV)
    {

        byte[] eData;
        using (DESCryptoServiceProvider tDESCsp = new DESCryptoServiceProvider())
        {

            /*    tDESCsp.GenerateKey();
                tDESCsp.GenerateIV();
              byte[] keywe = tDESCsp.Key;*/


            tDESCsp.Key = key;
            tDESCsp.IV = IV;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, tDESCsp.CreateEncryptor(tDESCsp.Key, tDESCsp.IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                    //   ms.
                    eData = ms.ToArray();
                }

            }


        }


        return eData;


    }

    #endregion

}