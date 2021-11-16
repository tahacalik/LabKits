using LabKits.classlar;
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
        }

        MainWindow gk3 = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_kitSil_Click(object sender, RoutedEventArgs e)
        {
            Guncelleme ekle = new Guncelleme();
            ekle.Owner = gk3;
            gk3.Opacity = 0.0;
            ekle.ShowDialog();
        }
    }
}
