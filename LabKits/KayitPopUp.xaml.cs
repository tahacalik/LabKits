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
using System.Windows.Threading;

namespace LabKits
{
    /// <summary>
    /// KayitPopUp.xaml etkileşim mantığı
    /// </summary>
    /// Alert popup that changes based on actions.
    public partial class KayitPopUp : Window
    {
        public KayitPopUp()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hata();
        void Hata()
        {
            if(mainprmt.Hata == 1)
            {
                lbl_Durum.Content = mainprmt.Bilgi_Content;
            }
            else
            {
                lbl_Durum.Content = mainprmt.Bilgi_Content;

            }
                DispatcherTimer timer = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromSeconds(3)
                };
                timer.Tick += delegate (object sender, EventArgs e)
                {
                    ((DispatcherTimer)timer).Stop();
                    if (this.ShowActivated) this.Close();
                };

                timer.Start();
            }
        }
    }
}
