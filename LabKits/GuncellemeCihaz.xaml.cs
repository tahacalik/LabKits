using LabKits.classlar;
using LabKits.classlar.parametreler;
using System;
using System.Collections.Generic;
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
    /// GuncellemeCihaz.xaml etkileşim mantığı
    /// </summary>
    public partial class GuncellemeCihaz : Window
    {
        public GuncellemeCihaz()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBIstem.CihazListele(dtg_cihazListesi);
        }

        private void guncelleCihazGuncelle_Click(object sender, RoutedEventArgs e)
        {
            KayitPopUp bilgi = new KayitPopUp();
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("UPDATE cihazlar SET CihazAdi='" + txt_CihazAdi.Text + "' WHERE CihazId='" + txt_CihazID.Text + "'", con);
            if (txt_CihazAdi.Text == "" && txt_CihazID.Text == "" )
            {
                mainprmt.Hata = 1;
                mainprmt.Bilgi_Content = "Eksik bilgi!";
                bilgi.Show();


                DBIstem.CihazListele(dtg_cihazListesi );
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
                DBIstem.CihazListele(dtg_cihazListesi);
            }



        }

        private void guncelleCihazPencereKpt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;
        }

        private void guncelleCihazSil_Click(object sender, RoutedEventArgs e)
        {
            KayitPopUp bilgi = new KayitPopUp();
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("DELETE FROM cihazlar WHERE CihazId='" + txt_CihazID.Text + "'", con);
            SQLiteCommand com2 = new SQLiteCommand("DELETE FROM kitler WHERE kitCihaz='" + txt_CihazID.Text + "'", con);
            var result = MessageBox.Show("CİHAZ SİLDİĞİNİZDE CİHAZA BAĞLI KİTLER DE SİLİNECEKTİR! DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {

                if (txt_CihazID.Text == "" && txt_CihazAdi.Text == "")
                {

                    mainprmt.Hata = 1;
                    mainprmt.Bilgi_Content = "Cihazı Seçiniz";
                    bilgi.Show();


                    DBIstem.CihazListele(dtg_cihazListesi);
                }
                else
                {
                    try
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        com2.ExecuteNonQuery();

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
                    DBIstem.CihazListele(dtg_cihazListesi);
                }
            }
            else
            {
                DBIstem.CihazListele(dtg_cihazListesi);
            }

        }
    }
}
