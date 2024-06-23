﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.Models;

namespace CafeOtomasyonu.WinForms.Odemeler
{
    public partial class frmOdeme : DevExpress.XtraEditors.XtraForm
    {
        private string _satisKodu;
        private string _odemeTuru;
        public OdemeHareketleri odemeHareketleri;
        public bool kaydedildi;
        public decimal _kalan;

        public frmOdeme(string odemeTuru,string satisKodu, decimal kalan)
        {
            InitializeComponent();
            _odemeTuru = odemeTuru;
            _satisKodu = satisKodu;
            _kalan = kalan;
            if (_odemeTuru == "Nakit")
            {
                lblBasilk.Text = "Nakit Ödeme";
            }
            else if (_odemeTuru == "Kredi Kartı")
            {
                lblBasilk.Text = "Kredi Kartı ile Ödeme";
            }
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            odemeHareketleri = new OdemeHareketleri
            {
                SatisKodu = _satisKodu,
                OdemeTuru = _odemeTuru,
                Odenen = calcTutar.Value,
                Aciklama = txtAciklama.Text,
                Tarih = Convert.ToDateTime(dateEditTarih.Text)
            };
            kaydedildi = true;
            this.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTamami_Click(object sender, EventArgs e)
        {
            calcTutar.Value = _kalan;
        }
    }
}