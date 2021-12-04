using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LabKits.classlar.parametreler
{
    public class mainprmt
    {

        #region Static Parametreler
        public static sbyte Hata;
        public static string Bilgi_Content;
        #endregion

        #region eklePrmt
        private int _kitId;
        private int _kitCihaz;
        private int _kitAdet;
        private int _kitHasta;

        private string _kitAdi;
        private string _kitLot;
        private string _girisTarihi;
        private string _kitSKT;
        private string _CihazAdi;

        public int KitId { get => _kitId; set => _kitId = value; }
        public int KitCihaz { get => _kitCihaz; set => _kitCihaz = value; }
        public int KitHasta { get => _kitHasta; set => _kitHasta = value; }
        public int KitAdet { get => _kitAdet; set => _kitAdet = value; }
        public string KitAdi { get => _kitAdi; set => _kitAdi = value; }
        public string KitLot { get => _kitLot; set => _kitLot = value; }
        public string GirisTarihi { get => _girisTarihi; set => _girisTarihi = value; }
        public string KitSkt { get => _kitSKT; set => _kitSKT = value; }
        public string CihazAdi { get => _CihazAdi; set => _CihazAdi = value; }
        #endregion
    }
}
