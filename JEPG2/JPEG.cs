using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPG2
{
    public class JPEG
    {
        public static double[,] CosMatrix = new double[8, 8];
        static void CalculeazaCos()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    CosMatrix[i, j] = Math.Cos(((2 * i + 1) * j * Math.PI) / 16);
                }
            }
        }
        public static byte[,] GetRGB(Bitmap bmp, int nr)
        {
            byte[,] rez = new byte[256, 256];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    switch (nr)
                    {
                        case 1:
                            rez[i, j] = bmp.GetPixel(i, j).R;
                            break;
                        case 2:
                            rez[i, j] = bmp.GetPixel(i, j).G;
                            break;
                        case 3:
                            rez[i, j] = bmp.GetPixel(i, j).B;
                            break;
                    }
                }
            }
            return rez;
        }

        public static Bitmap ByteToBMP(byte[,] matrix, int nr, int rezolutie)
        {
            Bitmap bmp = new Bitmap(rezolutie, rezolutie);
            for (int i = 0; i < rezolutie; i++)
            {
                for (int j = 0; j < rezolutie; j++)
                {
                    int nrCurent = matrix[i, j];
                    switch (nr)
                    {
                        case 1:
                            bmp.SetPixel(i, j, Color.FromArgb(nrCurent, 0, 0));
                            break;
                        case 2:
                            bmp.SetPixel(i, j, Color.FromArgb(0, nrCurent, 0));
                            break;
                        case 3:
                            bmp.SetPixel(i, j, Color.FromArgb(0, 0, nrCurent));
                            break;
                        case 4:
                            bmp.SetPixel(i, j, Color.FromArgb(nrCurent, nrCurent, nrCurent));
                            break;
                    }
                }
            }
            return bmp;
        }

        internal static double[,] Decuantizare(int[,] matrix, int rezolutie, int metoda, int limita)
        {
            double[,] rez = new double[rezolutie, rezolutie];
            switch (metoda)
            {
                case 0:
                    rez = ReversZigZag(matrix, rezolutie);
                    break;
                case 1:
                    rez = ReversMetoda2(matrix, rezolutie, limita);
                    break;
                case 2:

                    break;
            }
            return rez;
        }

        public static int[,] Cuantizare(double[,] matrix, int rezolutie, int metoda, int limita)
        {
            int[,] rez = new int[rezolutie, rezolutie];
            switch (metoda)
            {
                case 0:
                    rez = ZigZag(matrix, rezolutie, limita);
                    break;
                case 1:
                    rez = Metoda2(matrix, rezolutie, limita);
                    break;
                case 2:

                    break;
            }
            return rez;
        }

        public static int[,] ZigZag(double[,] matrix, int rezolutie, int limita)
        {
            int[,] rez = new int[rezolutie, rezolutie];
            int[,] zigzag =
           {
                {0,1,5,6,14,15,27,28 },
                {2,4,7,13,16,26,29,42 },
                {3,8,12,17,25,30,41,43 },
                {9,11,18,24,31,40,44,53 },
                {10,19,23,32,39,45,52,54 },
                {20,22,33,38,46,51,55,60 },
                {21,34,37,47,50,56,59,61 },
                {35,36,48,49,57,58,62,63 }
            };


            for (int x = 0; x < rezolutie; x += 8)
            {
                for (int y = 0; y < rezolutie; y += 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (zigzag[i, j] <= limita)
                            {
                                rez[i + x, j + y] = (int)matrix[i + x, j + y];
                            }
                        }
                    }
                }
            }

            return rez;
        }
        public static double[,] ReversZigZag(int[,] matrix, int v)
        {
            double[,] rez = new double[v, v];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    int a = matrix[i, j];
                    rez[i, j] = 1.0 * matrix[i, j];
                    double d = rez[i, j];
                }
            }
            return rez;
        }
        public static int[,] Metoda2(double[,] matrix, int marime, int limita)
        {
            int[,] rez = new int[marime, marime];
            for (int i = 0; i < marime; i += 8)
            {
                for (int j = 0; j < marime; j += 8)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            rez[i + x, j + y] = (int)(matrix[i + x, j + y] / (1 + (x + y) * limita));
                        }
                    }
                }
            }
            return rez;
        }
        public static double[,] ReversMetoda2(int[,] matrix, int marime, int limita)
        {
            double[,] rez = new double[marime, marime];
            for (int i = 0; i < marime; i += 8)
            {
                for (int j = 0; j < marime; j += 8)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            rez[i + x, j + y] = matrix[i + x, j + y] * (1 + (x + y) * limita);
                        }
                    }
                }
            }
            return rez;
        }

        public static double[,] DCT(byte[,] matrix, int rezolutie)
        {
            double[,] rez = new double[rezolutie, rezolutie];
            CalculeazaCos();
            for (int a = 0; a < rezolutie; a += 8)
            {
                for (int b = 0; b < rezolutie; b += 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            double suma = 0.0;
                            for (int x = 0; x < 8; x++)
                            {
                                for (int y = 0; y < 8; y++)
                                {
                                    suma += matrix[a + x, b + y] * CosMatrix[x, i] * CosMatrix[y, j];
                                }
                            }
                            rez[a + i, b + j] = 0.25 * Cx(i) * Cx(j) * suma;
                        }
                    }
                }
            }
            return rez;
        }
        public static byte[,] InversDCT(double[,] matrix, int rezolutie)
        {
            byte[,] rez = new byte[rezolutie, rezolutie];
            CalculeazaCos();
            for (int a = 0; a < rezolutie; a += 8)
            {

                for (int b = 0; b < rezolutie; b += 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            double suma = 0.0;
                            for (int x = 0; x < 8; x++)
                            {
                                for (int y = 0; y < 8; y++)
                                {
                                    suma += matrix[x + a, y + b] * Cx(x) * Cx(y) * CosMatrix[i, x] * CosMatrix[j, y];
                                }
                            }
                            suma *= 0.25;
                            rez[a + i, b + j] = (byte)suma;
                        }
                    }
                }
            }
            return rez;
        }

        private static double Cx(int x)
        {
            double rez;
            if (x == 0)
            {
                rez = 1.0 / Math.Sqrt(2.0);
            }
            else rez = 1.0;
            return rez;
        }

        public static byte[,] InversSubesantionare(byte[,] matrix)
        {
            byte[,] rez = new byte[256, 256];
            for (int i = 0; i < 256; i += 2)
            {
                for (int j = 0; j < 256; j += 2)
                {
                    rez[i, j] = matrix[i / 2, j / 2];
                    rez[i, j + 1] = matrix[i / 2, j / 2];
                    rez[i + 1, j] = matrix[i / 2, j / 2];
                    rez[i + 1, j + 1] = matrix[i / 2, j / 2];
                }
            }
            return rez;
        }

        public static byte[,] Subesantionare(byte[,] matrix)
        {

            byte[,] rez = new byte[128, 128];
            for (int i = 0; i < 256; i += 2)
            {
                for (int j = 0; j < 256; j += 2)
                {
                    rez[i / 2, j / 2] = (byte)((matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1]) / 4);
                }
            }
            return rez;
        }

        public static byte[,] YCBCRtoRGB(byte[,] Y, byte[,] Cb, byte[,] Cr, int nr)
        {
            byte[,] rez = new byte[256, 256];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    switch (nr)
                    {
                        case 1:
                            rez[i, j] = (byte)Math.Min(Math.Max(0, Math.Round(Y[i, j] + 1.402 * (Cr[i, j] - 128))), 255);
                            break;
                        case 2:
                            rez[i, j] = (byte)Math.Min(Math.Max(0, Math.Round(Y[i, j] - 0.3441 * (Cb[i, j] - 128) - 0.7141 * (Cr[i, j] - 128))), 255);
                            break;
                        case 3:
                            rez[i, j] = (byte)Math.Min(Math.Max(0, Math.Round(Y[i, j] + 1.772 * (Cb[i, j] - 128))), 255);
                            break;
                    }
                }
            }
            return rez;
        }

        public static byte[,] RGBtoYCBCR(byte[,] r, byte[,] g, byte[,] b, int nr)
        {
            byte[,] rez = new byte[256, 256];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    switch (nr)
                    {
                        case 1:
                            rez[i, j] = (byte)Math.Min(Math.Max(0, Math.Round(0.299 * r[i, j] + 0.587 * g[i, j] + 0.114 * b[i, j])), 255);
                            break;
                        case 2:
                            rez[i, j] = (byte)Math.Min(Math.Max(0, Math.Round((-0.299 * r[i, j] - 0.587 * g[i, j] + 0.886 * b[i, j]) / 1.772 + 128)), 255);
                            break;
                        case 3:
                            rez[i, j] = (byte)Math.Min(Math.Max(0, Math.Round((0.701 * r[i, j] - 0.587 * g[i, j] - 0.114 * b[i, j]) / 1.402 + 128)), 255);
                            break;
                    }
                }
            }
            return rez;
        }

        public static Bitmap RGBToBMP(byte[,] r, byte[,] g, byte[,] b)
        {
            Bitmap bmp = new Bitmap(256, 256);
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(r[i, j], g[i, j], b[i, j]));
                }
            }
            return bmp;
        }
    }
}
