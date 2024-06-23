namespace CafeOtomasyonu.WinForms.Ayarlar
{
    partial class frmBackup
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
            this.components = new System.ComponentModel.Container();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSunucu = new DevExpress.XtraEditors.TextEdit();
            this.cmbVT = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtYol = new DevExpress.XtraEditors.TextEdit();
            this.btnSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnYedekAl = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblYuzde = new DevExpress.XtraEditors.LabelControl();
            this.lblDurumu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtSunucu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BorderColor = System.Drawing.Color.DarkGray;
            this.labelControl3.Appearance.Options.UseBorderColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl3.Location = new System.Drawing.Point(12, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(94, 26);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Sunucu Adı : ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BorderColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseBorderColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.Location = new System.Drawing.Point(12, 66);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 26);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Veritabanı Adı : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BorderColor = System.Drawing.Color.DarkGray;
            this.labelControl2.Appearance.Options.UseBorderColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.Location = new System.Drawing.Point(12, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 26);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Dosya Yolu : ";
            // 
            // txtSunucu
            // 
            this.txtSunucu.Location = new System.Drawing.Point(112, 36);
            this.txtSunucu.Name = "txtSunucu";
            this.txtSunucu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSunucu.Properties.Appearance.Options.UseFont = true;
            this.txtSunucu.Size = new System.Drawing.Size(201, 24);
            this.txtSunucu.TabIndex = 14;
            // 
            // cmbVT
            // 
            this.cmbVT.Location = new System.Drawing.Point(112, 67);
            this.cmbVT.Name = "cmbVT";
            this.cmbVT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbVT.Properties.Appearance.Options.UseFont = true;
            this.cmbVT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVT.Size = new System.Drawing.Size(201, 24);
            this.cmbVT.TabIndex = 15;
            // 
            // txtYol
            // 
            this.txtYol.Location = new System.Drawing.Point(112, 100);
            this.txtYol.Name = "txtYol";
            this.txtYol.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYol.Properties.Appearance.Options.UseFont = true;
            this.txtYol.Size = new System.Drawing.Size(165, 24);
            this.txtYol.TabIndex = 16;
            // 
            // btnSec
            // 
            this.btnSec.Location = new System.Drawing.Point(283, 101);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(30, 23);
            this.btnSec.TabIndex = 17;
            this.btnSec.Text = "...";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // btnYedekAl
            // 
            this.btnYedekAl.Location = new System.Drawing.Point(238, 145);
            this.btnYedekAl.Name = "btnYedekAl";
            this.btnYedekAl.Size = new System.Drawing.Size(75, 29);
            this.btnYedekAl.TabIndex = 18;
            this.btnYedekAl.Text = "Yedekle";
            this.btnYedekAl.Click += new System.EventHandler(this.btnYedekAl_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(98, 148);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(135, 22);
            this.progressBarControl1.TabIndex = 19;
            // 
            // lblYuzde
            // 
            this.lblYuzde.Location = new System.Drawing.Point(204, 176);
            this.lblYuzde.Name = "lblYuzde";
            this.lblYuzde.Size = new System.Drawing.Size(20, 13);
            this.lblYuzde.TabIndex = 20;
            this.lblYuzde.Text = "0 %";
            // 
            // lblDurumu
            // 
            this.lblDurumu.Location = new System.Drawing.Point(183, 206);
            this.lblDurumu.Name = "lblDurumu";
            this.lblDurumu.Size = new System.Drawing.Size(41, 13);
            this.lblDurumu.TabIndex = 21;
            this.lblDurumu.Text = "Drurumu";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(126, 206);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Drurumu : ";
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 230);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lblDurumu);
            this.Controls.Add(this.lblYuzde);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.btnYedekAl);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.txtYol);
            this.Controls.Add(this.cmbVT);
            this.Controls.Add(this.txtSunucu);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedekleme";
            ((System.ComponentModel.ISupportInitialize)(this.txtSunucu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSunucu;
        private DevExpress.XtraEditors.ComboBoxEdit cmbVT;
        private DevExpress.XtraEditors.TextEdit txtYol;
        private DevExpress.XtraEditors.SimpleButton btnSec;
        private DevExpress.XtraEditors.SimpleButton btnYedekAl;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.LabelControl lblYuzde;
        private DevExpress.XtraEditors.LabelControl lblDurumu;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
    }
}