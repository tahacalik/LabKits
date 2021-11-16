
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;


namespace LabKits.classlar
{
    public class DBbaglanti
    {
        //Database connection part. Its directory is static, the database is placed in the same location in new installations.
        public static string DBadres = @"Data Source=C:\LabKits\Database\ada.db;Version=3;New=False;Compress=True;Read Only=False;";
        public static string Baglanti;
        public static void BaglantiTest()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBadres))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                        Baglanti = "Bağlantı Sağlandı..";
                    }
                    catch (Exception)
                    {
                        Baglanti = "Bağlantı Hatası...";
                    }
                    
                    
                }

                else
                {
                    Baglanti = "Bağlantı Sağlandı..";
                }
            }
        }
    }
}
