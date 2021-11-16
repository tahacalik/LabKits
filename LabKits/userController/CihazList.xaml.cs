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
    /// CihazList.xaml etkileşim mantığı
    /// </summary>
    public partial class CihazList : UserControl
    {
        public CihazList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBIstem.GridDoldurCihaz(dtg_cihazListesi);
        }
        MainWindow gk2 = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_cihazSil_Click(object sender, RoutedEventArgs e)
        {
            GuncellemeCihaz ekle = new GuncellemeCihaz();
            ekle.Owner = gk2;
            gk.Opacity = 0.0;
            ekle.ShowDialog();
        }
        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_cihazEkle_Click(object sender, RoutedEventArgs e)
        {
            CihazEklePenceresi ekle = new CihazEklePenceresi();
            ekle.Owner = gk;
            gk.Opacity = 0.0;
            ekle.ShowDialog();
        }


    }
}
