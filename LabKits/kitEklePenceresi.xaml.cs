using System;
using System.Collections.Generic;
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
using System.Threading.Tasks;
using LabKits.classlar.parametreler;
using LabKits.classlar;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;
using LabKits.userController;

namespace LabKits
{
    /// <summary>
    /// kitEklePenceresi.xaml etkileşim mantığı
    /// </summary>
    /// It visualizes kit adding process and contains these operations.
    public partial class kitEklePenceresi : Window
    {

        public kitEklePenceresi()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select CihazAdi from cihazlar", con);
            com.CommandType = CommandType.Text;
            SQLiteDataReader dr;
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read()){ cmb_cihaz.Items.Add(dr["CihazAdi"]); }
            con.Close();
        }


        private void ekleIslemTamam_Click(object sender, RoutedEventArgs e)
        {

            KayitPopUp bilgi = new KayitPopUp();

            if (txt_kitadi.Text != "" && txt_Lot.Text != "" && cmb_cihaz.Text !="" && txt_Adet.Text!="")
            {
                int cihazCode = 0;
                string[] cihazDizi = new string[cmb_cihaz.Items.Count];
                for (int i = 0; i < cmb_cihaz.Items.Count; i++)
                {
                    cihazDizi[i] = cmb_cihaz.Items[i].ToString();
                }
                for (int i = 0; i < cmb_cihaz.Items.Count; i++)
                {
                    if (cmb_cihaz.Text == cihazDizi[i])
                    {
                        cihazCode = i + 1;
                    }
                }
                mainprmt veri = new mainprmt();
                veri.KitCihaz = cihazCode;
                veri.KitAdi = txt_kitadi.Text;
                veri.KitAdet = Int32.Parse(txt_Adet.Text);
                veri.KitLot = txt_Lot.Text;
                DateTime dt = DateTime.Now;
                veri.GirisTarihi = dt.Date.ToString("yyyy-MM-dd");
                if (DBIstem.EklemeIslemi(veri))
                {

                    mainprmt.Hata = 0;
                    
                    mainprmt.Bilgi_Content = "Kayıt İşlemi Başarılı!";
                    bilgi.Show();

                }
                else
                {

                    mainprmt.Hata = 1;
                    mainprmt.Bilgi_Content = "Kayıt İşlemi Başarısız!";
                    bilgi.Show();
                }
            }
            else
            {

                mainprmt.Hata = 1;
                mainprmt.Bilgi_Content = "Bütün Alanları Doldurunuz!";
                bilgi.Show();

            }
        }

        //private void txt_Eklenen_PreviewTextInput(object sender, TextCompositionEventArgs e) { if (!char.IsDigit(e.Text, e.Text.Length - 1)){ e.Handled = true; } }

        private void eklePencereKpt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;
        }

        private void cmb_cihaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_Lot_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_Adet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text,e.Text.Length - 1))
            {
                e.Handled = true;

            }
        }
    }
}
