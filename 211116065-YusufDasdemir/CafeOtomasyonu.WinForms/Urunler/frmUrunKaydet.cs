using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;

namespace CafeOtomasyonu.WinForms.Urunler
{
    public partial class frmUrunKaydet : DevExpress.XtraEditors.XtraForm
    {
        private MenuDal menuDal = new MenuDal();
        UrunDal urunDal = new UrunDal();
        private Urun _entity;
        private CafeContext context = new CafeContext();
        public bool kaydet = false;

        public frmUrunKaydet(Urun entity)
        {
            InitializeComponent();
            _entity = entity;
            lookUpEdit1.Properties.DataSource = menuDal.GetAll(context);
            lookUpEdit1.DataBindings.Add("EditValue", _entity, "MenuId");
            txtUrunAd.DataBindings.Add("Text", _entity, "UrunAdi");
            txtUrunKod.DataBindings.Add("Text", _entity, "UrunKodu");
            cBirim1.DataBindings.Add("Text", _entity, "BirimFiyati1", true);
            cBirim2.DataBindings.Add("Text", _entity, "BirimFiyati2", true);
            cBirim3.DataBindings.Add("Text", _entity, "BirimFiyati3", true);
            memoAciklama.DataBindings.Add("Text", _entity, "Aciklama");
            dateEdit1.DataBindings.Add("Text", _entity, "Tarih", true);
            if (_entity.Id != 0)
            {
                if (_entity.Resim != null)
                {
                    try
                    {
                        pictureEdit1.Image = Image.FromFile(_entity.Resim);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (pictureEdit1.GetLoadedImageLocation() != "")
            {
                string hedefYol = $"{Application.StartupPath}\\Image\\{txtUrunAd.Text}-{txtUrunKod.Text}.png";
                if (File.Exists(hedefYol))
                {
                    File.Delete(hedefYol);
                }
                File.Copy(pictureEdit1.GetLoadedImageLocation(), hedefYol);
                _entity.Resim = $"Image\\{txtUrunAd.Text}-{txtUrunKod.Text}.png";
            }
            if (urunDal.AddOrUpdate(context, _entity))
            {
                urunDal.Save(context);
                kaydet = true;
                MessageBox.Show("İşlem başarıyla gerçekleştirldi", "Başarılı", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}