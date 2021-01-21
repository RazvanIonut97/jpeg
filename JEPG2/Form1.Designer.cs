
namespace JEPG2
{
    partial class Form1
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
            this.ImagineOriginala = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.loadImage = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ImagineInversa = new System.Windows.Forms.PictureBox();
            this.listaMetode = new System.Windows.Forms.CheckedListBox();
            this.tabLimita = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ImagineOriginala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagineInversa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLimita)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagineOriginala
            // 
            this.ImagineOriginala.Location = new System.Drawing.Point(12, 12);
            this.ImagineOriginala.Name = "ImagineOriginala";
            this.ImagineOriginala.Size = new System.Drawing.Size(256, 256);
            this.ImagineOriginala.TabIndex = 0;
            this.ImagineOriginala.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadImage
            // 
            this.loadImage.FileName = "openFileDialog1";
            this.loadImage.Filter = "Files|*.bmp;";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Direct Steps";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Reverse Steps";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ImagineInversa
            // 
            this.ImagineInversa.Location = new System.Drawing.Point(291, 12);
            this.ImagineInversa.Name = "ImagineInversa";
            this.ImagineInversa.Size = new System.Drawing.Size(256, 256);
            this.ImagineInversa.TabIndex = 7;
            this.ImagineInversa.TabStop = false;
            // 
            // listaMetode
            // 
            this.listaMetode.CheckOnClick = true;
            this.listaMetode.FormattingEnabled = true;
            this.listaMetode.Items.AddRange(new object[] {
            "ZigZag",
            "Q xy = 1+(x+y)*R",
            "Factor Calitate"});
            this.listaMetode.Location = new System.Drawing.Point(93, 274);
            this.listaMetode.Name = "listaMetode";
            this.listaMetode.Size = new System.Drawing.Size(110, 49);
            this.listaMetode.TabIndex = 10;
            this.listaMetode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listaMetode_ItemCheck);
            // 
            // tabLimita
            // 
            this.tabLimita.Location = new System.Drawing.Point(93, 329);
            this.tabLimita.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.tabLimita.Name = "tabLimita";
            this.tabLimita.Size = new System.Drawing.Size(88, 20);
            this.tabLimita.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 467);
            this.Controls.Add(this.tabLimita);
            this.Controls.Add(this.listaMetode);
            this.Controls.Add(this.ImagineInversa);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ImagineOriginala);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImagineOriginala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagineInversa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLimita)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagineOriginala;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog loadImage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox ImagineInversa;
        private System.Windows.Forms.CheckedListBox listaMetode;
        private System.Windows.Forms.NumericUpDown tabLimita;
    }
}

