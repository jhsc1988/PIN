using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Kreira i vraća SHA512 hash
/// </summary>
public static class hash_crypto
{
    public static string create_hash(string s)
    {
        SHA512Managed sha = new SHA512Managed(); // objekt s f-jom za hash algoritam
        byte[] poljeBajtova = UTF32Encoding.UTF32.GetBytes(s);
        byte[] hashiranoPoljeBajtova = sha.ComputeHash(poljeBajtova);
        return Convert.ToBase64String(hashiranoPoljeBajtova);
    }

}