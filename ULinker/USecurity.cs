using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ULinker
{
    public class USecurity
    {

        public static UBase CreateDatabase(string name,string password = "")
        {

            string current_directory = Directory.GetCurrentDirectory() + @"\";
            string path = current_directory + name + ".ulink";
          
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"{DateTime.UtcNow.ToLongDateString()}|{name}|{password}");
            }
                
            return new UBase(name,password, DateTime.UtcNow.ToLongDateString(),path);

        }


        public static void EncryptBase(UBase Base)
        {
            if(File.Exists(Base.Path))
            {
                EncryptFile(Base);
            }
            else
            {
                Alert.Error("Unable to encrpyt the base path does not exitst!");
                return;

            }

        }

        public static void DecryptBase(UBase Base,string Password)
        {
            if (File.Exists(Base.Path))
            {
                DecryptFile(Base,Password);
            }
            else
            {
                Alert.Error("Unable to decrpyt the base path does not exitst!");
                return;

            }
        }



   
        private static void EncryptFile(UBase Base)
        {

            try
            {
                string password = Base.Password;
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = Base.DBName;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(Base.Path, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch(Exception ex)
            {
                Alert.Error("Encrpytion failed!");
                Alert.Info(ex.Message);
            }
        }

        private static void DecryptFile(UBase Base,string password)
        {


            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(Base.Path, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream("DE_" + new Random().Next(5000,10000), FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();


        }


    }
}
