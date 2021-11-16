using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LabKits.classlar;
using LabKits.userController;

namespace LabKits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// It is the main block window of the software. It contains the user interface.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_kapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_kucult_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_buyut_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                anaGrd.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void brd_sagUst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cagir.ekranCagir(icerik, new KullaniciStokList());
            DBbaglanti.BaglantiTest();
            sqlDurumText.Content = DBbaglanti.Baglanti;
        }

        private void btn_menuList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(btn_menuList.Width != 23) { 
            GridLength grd = new GridLength(115, GridUnitType.Pixel);
            menuColumn.Width = grd;
            menu1.Visibility = Visibility.Hidden;
            menu2.Visibility = Visibility.Hidden;
            baslikText.Visibility = Visibility.Hidden;
            solAltBanner.Visibility = Visibility.Hidden;
            adalablogo.Visibility = Visibility.Hidden;
            btn_menuList.Width = 23;
            btn_menuList.Margin = new Thickness(45, 0, 0, 0);
            }
            else
            {
            GridLength grd = new GridLength(220, GridUnitType.Pixel);
            menuColumn.Width = grd;
            menu1.Visibility = Visibility.Visible;
            menu2.Visibility = Visibility.Visible;
            baslikText.Visibility = Visibility.Visible;
            btn_menuList.Width = 24;

            solAltBanner.Visibility = Visibility.Visible;
            adalablogo.Visibility = Visibility.Visible;
            }
        }

        #region

        int secim;
        private void menu_stokEkrani_Click(object sender, RoutedEventArgs e)
        {
            cagir.ekranCagir(icerik, new KullaniciStokList());
            secim = 1;
            secilendurum();
        }


        private void menu_cihazlar_Click(object sender, RoutedEventArgs e)
        {
            cagir.ekranCagir(icerik, new CihazList());
            secim = 2;
            secilendurum();
        }

        private void menu_kritikStok_Click(object sender, RoutedEventArgs e)
        {
            secim = 3;
            secilendurum();
        }

        private void menu_ayarlar_click(object sender, RoutedEventArgs e)
        {
            secim = 4;
            secilendurum();
        }

        void secilendurum()
        {

            if (secim == 1)
            {
                menu_stokEkrani.IsChecked = true;
            }
            else
            {
                menu_stokEkrani.IsChecked = false;
            }
            if (secim == 2)
            {
                menu_cihazlar.IsChecked = true;
            }
            else
            {
                menu_cihazlar.IsChecked = false;
            }
        }

        #endregion
    }
}
