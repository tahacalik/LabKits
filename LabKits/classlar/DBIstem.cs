using LabKits.classlar.parametreler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LabKits.classlar
{
    class DBIstem
    {
        //The main class where we make database queries. The main queries are always referenced from here.
        public static bool GridDoldur(DataGrid grd)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select kitler.kitId, kitler.girisTarihi, kitler.kitAdi, kitler.kitAdet, kitler.kitLot, cihazlar.CihazAdi From kitler Inner Join cihazlar on cihazlar.CihazId = kitler.KitCihaz", con);
            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            finally
            {
                con.Dispose();
            }

            if (i > 0) return true; else return false;
        }

        public static bool CihazListele(DataGrid grd)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select * from cihazlar", con);
            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            finally
            {
                con.Dispose();
            }

            if (i > 0) return true; else return false;
        }

        public static bool GridDoldurCihaz(DataGrid grd)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("SELECT cihazlar.cihazAdi, cihazlar.CihazId, COUNT(kitler.kitId) AS 'tanimliKit' FROM kitler, cihazlar WHERE cihazlar.CihazId = kitler.kitCihaz GROUP BY cihazlar.CihazId", con);
            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            finally
            {
                con.Dispose();
            }

            if (i > 0) return true; else return false;
        }


        public static bool EklemeIslemi(mainprmt veri)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Insert into kitler (kitAdi, kitLot, kitCihaz, kitAdet, girisTarihi) values (@kitAdi,@kitLot,@kitCihaz,@kitAdet,@girisTarihi)", con);

            com.Parameters.AddWithValue("@kitAdi", veri.KitAdi);
            com.Parameters.AddWithValue("@kitLot", veri.KitLot);
            com.Parameters.AddWithValue("@kitCihaz", veri.KitCihaz);
            com.Parameters.AddWithValue("@kitAdet", veri.KitAdet);
            com.Parameters.AddWithValue("@girisTarihi", veri.GirisTarihi);

            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;

        }

        public static bool CihazEklemeIslemi(mainprmt veri)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Insert into cihazlar (CihazAdi) values (@CihazAdi)", con);

            com.Parameters.AddWithValue("@CihazAdi", veri.CihazAdi);


            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;

        }



        public static bool GuncellemeIslemi(mainprmt veri)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("UPDATE kitler SET kitAdet = @kitAdet where kitLot=@kitLot", con);

            com.Parameters.AddWithValue("@kitAdet", veri.KitAdet);
            com.Parameters.AddWithValue("@kitLot", veri.KitLot);

            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;

        }

    }
}
