using LabKits.classlar;
using LabKits.classlar.parametreler;
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

namespace LabKits
{
    /// <summary>
    /// CihazEklePenceresi.xaml etkileşim mantığı
    /// </summary>
    public partial class CihazEklePenceresi : Window
    {
        public CihazEklePenceresi()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ekleCihazIslemTamam_Click(object sender, RoutedEventArgs e)
        {
            KayitPopUp bilgi = new KayitPopUp();

            if (txt_cihazAdi.Text != "" )
            {

                mainprmt veri = new mainprmt();
                veri.CihazAdi = txt_cihazAdi.Text;

                if (DBIstem.CihazEklemeIslemi(veri))
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
                mainprmt.Bilgi_Content = "Cihazın Bir Adı Olmalı!";
                bilgi.Show();

            }
        }

        private void ekleCihazPencereKpt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;
        }
    }
}
