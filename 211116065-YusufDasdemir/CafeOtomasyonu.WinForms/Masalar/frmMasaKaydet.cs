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

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasaKaydet : DevExpress.XtraEditors.XtraForm
    {
        CafeContext context = new CafeContext();
        private MasalarDal masalarDal = new MasalarDal();
        private Entities.Models.Masalar _entity;
        public bool kaydet = false;
        public frmMasaKaydet(Entities.Models.Masalar entity)
        {
            InitializeComponent();
            _entity = entity;
            txtMasaAdi.DataBindings.Add("Text", _entity, "MasaAdi");
            memoAciklama.DataBindings.Add("Text", _entity, "Aciklama");
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_entity.Id == 0)
            {
                _entity.Durumu = false;
                _entity.RezerveMi = false;
                _entity.EklemeTarihi = DateTime.Now;
                _entity.SonIslemTarihi = DateTime.Now;
                _entity.Islem = "Yeni Masa Eklendi";
            }
            else if (_entity.Id!=0)
            {
                _entity.SonIslemTarihi = DateTime.Now;
                _entity.Islem = "Masa Güncellendi";
            }
            if (masalarDal.AddOrUpdate(context, _entity))
            {
                masalarDal.Save(context);
                kaydet = true;
                this.Close();
            }
        }
    }
}