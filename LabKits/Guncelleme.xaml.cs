using LabKits.classlar;
using LabKits.classlar.parametreler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LabKits
{
    /// <summary>
    /// Guncelleme.xaml etkileşim mantığı
    /// </summary>
    public partial class Guncelleme : Window
    {
        public Guncelleme()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DBIstem.GridDoldur(dtg_GuncellemeListesi);
        }

        private void guncellePencereKpt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;
        }

        private void guncelleAra_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select * From kitler Where (kitAdi Like @kitAdi) ", con);
            com.Parameters.AddWithValue("@kitAdi", txt_KitAdi.Text);

            if (txt_KitAdi.Text == "")
            {
                DBIstem.GridDoldur(dtg_GuncellemeListesi);
                con.Dispose();
            }
            else
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dtg_GuncellemeListesi.ItemsSource = dt.DefaultView;
                con.Dispose();
            }

        }

        private void guncelleGuncelle_Click(object sender, RoutedEventArgs e)
        {
            KayitPopUp bilgi = new KayitPopUp();
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("UPDATE kitler SET kitAdi='" + txt_KitAdi.Text + "', kitAdet='" + txt_KitAdet.Text + "', kitLot='" + txt_KitLot.Text + "' WHERE kitId='" + txt_KitId.Text + "'", con);
            if (txt_KitAdi.Text == "" && txt_KitLot.Text == "" && txt_KitAdet.Text=="")
            {
                mainprmt.Hata = 1;
                mainprmt.Bilgi_Content = "Eksik bilgi!";
                bilgi.Show();


                DBIstem.GridDoldur(dtg_GuncellemeListesi);
            }
            else
            {
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();

                }
                catch (Exception test)
                {
                    MessageBox.Show(test.ToString());
                    mainprmt.Hata = 1;
                    mainprmt.Bilgi_Content = "Güncelleme Başarısız!";
                    bilgi.Show();
                    throw;
                }
                
                con.Dispose();
                DBIstem.GridDoldur(dtg_GuncellemeListesi);
            }



        }


        private void guncelleSil_Click(object sender, RoutedEventArgs e)
        {
            KayitPopUp bilgi = new KayitPopUp();
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("DELETE FROM kitler WHERE kitLot='" + txt_KitLot.Text + "'", con);
            if (txt_KitAdi.Text == "" && txt_KitLot.Text == "")
            {
                mainprmt.Hata = 1;
                mainprmt.Bilgi_Content = "Adını ve Lot'unu Giriniz";
                bilgi.Show();
                
                
                DBIstem.GridDoldur(dtg_GuncellemeListesi);
            }
            else
            {
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();

                }
                catch (Exception test)
                {
                    MessageBox.Show(test.ToString());
                    mainprmt.Hata = 1;
                    mainprmt.Bilgi_Content = "Silme İşlemi Başarısız!";
                    bilgi.Show();
                    throw;
                }

                con.Dispose();
                DBIstem.GridDoldur(dtg_GuncellemeListesi);
            }



        }
    }
}
