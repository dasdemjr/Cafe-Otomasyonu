namespace CafeOtomasyonu.WinForms.Masalar
{
    partial class frmMasaDurumlari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasaDurumlari));
            this.groupIslemler = new DevExpress.XtraEditors.GroupControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnRezervEt = new DevExpress.XtraEditors.SimpleButton();
            this.btnMasaAc = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnSiparisler = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sbtnRezerv = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnBos = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnDolu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupIslemler)).BeginInit();
            this.groupIslemler.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupIslemler
            // 
            this.groupIslemler.Controls.Add(this.sbtnRezerv);
            this.groupIslemler.Controls.Add(this.sbtnBos);
            this.groupIslemler.Controls.Add(this.btnKapat);
            this.groupIslemler.Controls.Add(this.sbtnDolu);
            this.groupIslemler.Controls.Add(this.btnRezervEt);
            this.groupIslemler.Controls.Add(this.btnMasaAc);
            this.groupIslemler.Controls.Add(this.btnYenile);
            this.groupIslemler.Controls.Add(this.btnSiparisler);
            this.groupIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupIslemler.Location = new System.Drawing.Point(0, 594);
            this.groupIslemler.Name = "groupIslemler";
            this.groupIslemler.Size = new System.Drawing.Size(1130, 88);
            this.groupIslemler.TabIndex = 5;
            this.groupIslemler.Text = "İşlemler";
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.ImageOptions.Image")));
            this.btnKapat.Location = new System.Drawing.Point(1048, 36);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(70, 44);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Kapat";
            // 
            // btnRezervEt
            // 
            this.btnRezervEt.Enabled = false;
            this.btnRezervEt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRezervEt.ImageOptions.Image")));
            this.btnRezervEt.Location = new System.Drawing.Point(264, 36);
            this.btnRezervEt.Name = "btnRezervEt";
            this.btnRezervEt.Size = new System.Drawing.Size(117, 44);
            this.btnRezervEt.TabIndex = 0;
            this.btnRezervEt.Text = "Rezerve Et";
            this.btnRezervEt.Click += new System.EventHandler(this.btnRezervEt_Click);
            // 
            // btnMasaAc
            // 
            this.btnMasaAc.Enabled = false;
            this.btnMasaAc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMasaAc.ImageOptions.Image")));
            this.btnMasaAc.Location = new System.Drawing.Point(138, 36);
            this.btnMasaAc.Name = "btnMasaAc";
            this.btnMasaAc.Size = new System.Drawing.Size(117, 44);
            this.btnMasaAc.TabIndex = 0;
            this.btnMasaAc.Text = "Masa Aç";
            this.btnMasaAc.Click += new System.EventHandler(this.btnMasaAc_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYenile.ImageOptions.SvgImage")));
            this.btnYenile.Location = new System.Drawing.Point(387, 36);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(117, 44);
            this.btnYenile.TabIndex = 0;
            this.btnYenile.Text = "Yenile-Listele";
            // 
            // btnSiparisler
            // 
            this.btnSiparisler.Enabled = false;
            this.btnSiparisler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSiparisler.ImageOptions.Image")));
            this.btnSiparisler.Location = new System.Drawing.Point(12, 36);
            this.btnSiparisler.Name = "btnSiparisler";
            this.btnSiparisler.Size = new System.Drawing.Size(117, 44);
            this.btnSiparisler.TabIndex = 0;
            this.btnSiparisler.Text = "Siparişler";
            this.btnSiparisler.Click += new System.EventHandler(this.btnSiparisler_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1130, 46);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Masa Durumları";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1130, 548);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // sbtnRezerv
            // 
            this.sbtnRezerv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnRezerv.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.sbtnRezerv.Appearance.Options.UseBackColor = true;
            this.sbtnRezerv.Location = new System.Drawing.Point(955, 42);
            this.sbtnRezerv.Name = "sbtnRezerv";
            this.sbtnRezerv.Size = new System.Drawing.Size(87, 32);
            this.sbtnRezerv.TabIndex = 7;
            this.sbtnRezerv.Text = "Rezerv Masa";
            // 
            // sbtnBos
            // 
            this.sbtnBos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnBos.Appearance.BackColor = System.Drawing.Color.Green;
            this.sbtnBos.Appearance.Options.UseBackColor = true;
            this.sbtnBos.Location = new System.Drawing.Point(862, 42);
            this.sbtnBos.Name = "sbtnBos";
            this.sbtnBos.Size = new System.Drawing.Size(87, 32);
            this.sbtnBos.TabIndex = 8;
            this.sbtnBos.Text = "Boş Masa";
            // 
            // sbtnDolu
            // 
            this.sbtnDolu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDolu.Appearance.BackColor = System.Drawing.Color.Red;
            this.sbtnDolu.Appearance.Options.UseBackColor = true;
            this.sbtnDolu.Location = new System.Drawing.Point(769, 42);
            this.sbtnDolu.Name = "sbtnDolu";
            this.sbtnDolu.Size = new System.Drawing.Size(87, 32);
            this.sbtnDolu.TabIndex = 9;
            this.sbtnDolu.Text = "Dolu Masa";
            // 
            // frmMasaDurumlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 682);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupIslemler);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmMasaDurumlari";
            this.Text = "Masa Durumları";
            ((System.ComponentModel.ISupportInitialize)(this.groupIslemler)).EndInit();
            this.groupIslemler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupIslemler;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnSiparisler;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRezervEt;
        private DevExpress.XtraEditors.SimpleButton btnMasaAc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton sbtnRezerv;
        private DevExpress.XtraEditors.SimpleButton sbtnBos;
        private DevExpress.XtraEditors.SimpleButton sbtnDolu;
    }
}