using LabKits.classlar;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabKits.userController
{
    /// <summary>
    /// KullaniciStokList.xaml etkileşim mantığı
    /// </summary>
    public partial class KullaniciStokList : UserControl
    {
        public KullaniciStokList()
        {
            InitializeComponent();
        }

        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_kitEkle_Click(object sender, RoutedEventArgs e)
        {
            kitEklePenceresi ekle = new kitEklePenceresi();
            ekle.Owner = gk;
            gk.Opacity = 0.0;
            ekle.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBIstem.GridDoldur(dtg_stokListesi);
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select CihazAdi from cihazlar", con);
            com.CommandType = CommandType.Text;
            SQLiteDataReader dr;
            con.Open();
            dr = com.ExecuteReader();
            cmb_cihaz.Items.Add("Hepsi");
            cmb_cihaz.Items.Add("Kritik Stok");
            while (dr.Read()) { cmb_cihaz.Items.Add(dr["CihazAdi"]); }
            con.Close();
        }

        MainWindow gk3 = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_kitSil_Click(object sender, RoutedEventArgs e)
        {
            Guncelleme ekle = new Guncelleme();
            ekle.Owner = gk3;
            gk3.Opacity = 0.0;
            ekle.ShowDialog();
        }


        private void cmb_cihaz_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_filter_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_cihaz.Text != "")
            {
                if (cmb_cihaz.Text == "Hepsi")
                {
                    DBIstem.GridDoldur(dtg_stokListesi);
                }
                else if (cmb_cihaz.Text == "Kritik Stok")
                {
                    SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
                    SQLiteCommand com = new SQLiteCommand("Select kitler.girisTarihi, kitler.kitAdi, kitler.kitAdet, kitler.kitLot, kitler.kitSKT, kitler.kitKullanilabilir, cihazlar.CihazAdi From kitler Inner Join cihazlar on cihazlar.CihazId = kitler.KitCihaz Where kitler.kitAdet <= 2", con);
                    com.Parameters.AddWithValue("@cihazAdi", cmb_cihaz.Text);
                    SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dtg_stokListesi.ItemsSource = dt.DefaultView;
                    con.Dispose();
                }
                else
                {
                    SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
                    SQLiteCommand com = new SQLiteCommand("Select kitler.girisTarihi, kitler.kitAdi, kitler.kitAdet, kitler.kitLot, kitler.kitSKT, kitler.kitKullanilabilir, cihazlar.CihazAdi From kitler Inner Join cihazlar on cihazlar.CihazId = kitler.KitCihaz Where (cihazlar.CihazAdi Like @cihazAdi)", con);
                    com.Parameters.AddWithValue("@cihazAdi", cmb_cihaz.Text);

                    if (cmb_cihaz.Text == "")
                    {
                        DBIstem.GridDoldur(dtg_stokListesi);
                        con.Dispose();
                    }
                    else
                    {
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        dtg_stokListesi.ItemsSource = dt.DefaultView;
                        con.Dispose();
                    }
                }
            }

        }
    }
}
