using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JEPG2
{
    public partial class Form1 : Form
    {
        int metoda;
        int limita = 0;
        Bitmap bmp;
        //RGB
        byte[,] R;
        byte[,] G;
        byte[,] B;
        //Y CB CR
        byte[,] Y;
        byte[,] CB;
        byte[,] CR;
        // Subesantionare
        byte[,] SubCB;
        byte[,] SubCR;
        //DCT
        double[,] Ydct;
        double[,] CBdct;
        double[,] CRdct;
        //cuantizare
        int[,] YQ;
        int[,] CBQ;
        int[,] CRQ;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = loadImage.ShowDialog();
            if (d == DialogResult.OK)
            {
                bmp = new Bitmap(loadImage.FileName);
                ImagineOriginala.Image = bmp;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            metoda = listaMetode.SelectedIndex;
            limita =(int) tabLimita.Value;
            //RGB
            R = JPEG.GetRGB(bmp,1);
            G= JPEG.GetRGB(bmp, 2);
            B= JPEG.GetRGB(bmp, 3);
            //YCBCR
            Y = JPEG.RGBtoYCBCR(R, G, B, 1);
            CB = JPEG.RGBtoYCBCR(R, G, B, 2);
            CR = JPEG.RGBtoYCBCR(R, G, B, 3);
            //Subesantionarea
            SubCB = JPEG.Subesantionare(CB);
            SubCR = JPEG.Subesantionare(CR);
            //DCT
            Ydct = JPEG.DCT(Y, 256);
            CBdct = JPEG.DCT(SubCB, 128);
            CRdct = JPEG.DCT(SubCR,128);
            //Cuantizare
            //YQ = JPEG.Cuantizare(Ydct, 256, metoda,limita);
            YQ = JPEG.Cuantizare(Ydct, 256, metoda, limita);
            CBQ = JPEG.Cuantizare(CBdct, 128, metoda, limita);
            CRQ = JPEG.Cuantizare(CRdct, 128, metoda, limita);




        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ydct = JPEG.Decuantizare(YQ, 256, metoda, limita);
            CBdct = JPEG.Decuantizare(CBQ, 128, metoda, limita);
            CRdct = JPEG.Decuantizare(CRQ, 128, metoda, limita);

            Y =JPEG.InversDCT(Ydct,256);
            SubCR = JPEG.InversDCT(CRdct, 128);
            SubCB = JPEG.InversDCT(CBdct, 128);
            //Reesantionare
            CB = JPEG.InversSubesantionare(SubCB);
            CR = JPEG.InversSubesantionare(SubCR);
            // YCBCR-->RGB
            R = JPEG.YCBCRtoRGB(Y, CB, CR, 1);
            G = JPEG.YCBCRtoRGB(Y, CB, CR, 2);
            B = JPEG.YCBCRtoRGB(Y, CB, CR, 3);
            ImagineInversa.Image = JPEG.RGBToBMP(R, G, B);
        }

        private void listaMetode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < listaMetode.Items.Count; ++ix)
            {
                if (ix != e.Index) listaMetode.SetItemChecked(ix, false);
            }
        }
    }
}
