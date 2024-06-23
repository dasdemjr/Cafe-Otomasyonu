using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.WinTools;

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasaRezerv : DevExpress.XtraEditors.XtraForm
    {
        private int _masaId;
        public bool islemYapildi;
        private Entities.Models.Masalar masalar;
        MasalarDal masalarDal = new MasalarDal();
        CafeContext context = new CafeContext();
        public frmMasaRezerv(int masaId)
        {
            InitializeComponent();
            _masaId = masaId;
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            masalar = masalarDal.GetByFilter(context, m => m.Id == _masaId);
            masalar.Islem = txtIslem.Text;
            masalar.SonIslemTarihi = Convert.ToDateTime(dateEditTarih.EditValue);
            masalar.KullaniciId = KullaniciAyarlari.kullaniciId;
            masalar.RezerveMi = true;
            masalarDal.Save(context);
            islemYapildi = true;
            this.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}