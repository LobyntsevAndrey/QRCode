using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "QR Code";
            button2.Text = "Save";
            label2.Text = "1";
            comboBox1.SelectedItem = "L";
            comboBox2.SelectedItem = "1";
            comboBox3.SelectedItem = "Optimal";
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            textBox1.Multiline = true;
            textBox1.Height = 32;
            textBox1.Width = 400;
        }

        private void Encode(string qrtext)
        {
            string modeIndicator = "0100";
            var version = Convert.ToInt32(comboBox2.Text);
            var lvl = comboBox1.Text;
            int[] total_codewords = { 19, 16, 13, 9,
                                      34, 28, 22, 16,
                                      55, 44, 34, 26,
                                      80, 64, 48, 36,
                                      108, 86, 62, 46,
                                      136, 108, 76, 60,
                                      156, 124, 88, 66,
                                      194, 154, 110, 86,
                                      232, 182, 132, 100,
                                      274, 216, 154, 122,
                                      324, 254, 180, 140,
                                      370, 290, 206, 158,
                                      428, 334, 244, 180,
                                      461, 365, 261, 197,
                                      523, 415, 295, 223,
                                      589, 453, 325, 253,
                                      647, 507, 367, 283,
                                      721, 563, 397, 313,
                                      795, 627, 445, 341,
                                      861, 669, 485, 385,
                                      932, 714, 512, 406,
                                      1006, 782, 568, 442,
                                      1094, 860, 614, 464,
                                      1174, 914, 664, 514,
                                      1276, 1000, 718, 538,
                                      1370, 1062, 754, 596,
                                      1468, 1128, 808, 628,
                                      1531, 1193, 871, 661,
                                      1631, 1267, 911, 701,
                                      1735, 1373, 985, 745,
                                      1843, 1455, 1033, 793,
                                      1955, 1541, 1115, 845,
                                      2071, 1631, 1171, 901,
                                      2191, 1725, 1231, 961,
                                      2306, 1812, 1286, 986,
                                      2434, 1914, 1354, 1054,
                                      2566, 1992, 1426, 1096,
                                      2702, 2102, 1502, 1142,
                                      2812, 2216, 1582, 1222,
                                      2956, 2334, 1666, 1276};
            int[] ec_codewords =  { 7, 10, 13, 17,
                                    10, 16, 22, 28,
                                    15, 26, 18, 22,
                                    20, 18, 26, 16,
                                    26, 24, 18, 22,
                                    18, 16, 24, 28,
                                    20, 18, 18, 26,
                                    24, 22, 22, 26,
                                    30, 22, 20, 24,
                                    18, 26, 24, 28,
                                    20 ,30, 28, 24,
                                    24, 22, 26, 28,
                                    26, 22, 24, 22,
                                    30, 24, 20, 24,
                                    22, 24, 30, 24,
                                    24, 28, 24, 30,
                                    28, 28, 28, 28,
                                    30, 26, 28, 28,
                                    28, 26, 26, 26,
                                    28, 26, 30, 28,
                                    28, 26, 28, 30,
                                    28, 28, 30, 24,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    26, 28, 30, 30,
                                    28, 28, 28, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30,
                                    30, 28, 30, 30, 
                                    30, 28, 30, 30,
                                    30, 28, 30, 30 };
            int[] blocks = {1, 19, 0, 0,
                            1, 16, 0, 0,
                            1, 13, 0, 0,
                            1, 9, 0, 0,
                            1, 34, 0, 0,
                            1, 28, 0, 0,
                            1, 22, 0, 0,
                            1, 16, 0, 0,
                            1, 55, 0, 0,
                            1, 44, 0, 0,
                            2, 17, 0, 0,
                            2, 13, 0, 0,
                            1, 80, 0, 0,
                            2, 32, 0, 0,
                            2, 24, 0, 0,
                            4, 9, 0, 0,
                            1, 108, 0, 0,
                            2, 43, 0, 0,
                            2, 15, 2, 16,
                            2, 11, 2, 12,
                            2, 68, 0, 0,
                            4, 27, 0, 0,
                            4, 19, 0, 0,
                            4, 15, 0, 0,
                            2, 78, 0, 0,
                            4, 31, 0, 0,
                            2, 14, 4, 15,
                            4, 13, 1, 14,
                            2, 97, 0, 0,
                            2, 38, 2, 39,
                            4, 18, 2, 19,
                            4, 14, 2, 15,
                            2, 116, 0, 0,
                            3, 36, 2, 37,
                            4, 16, 4, 17,
                            4, 12, 4, 13,
                            2, 68, 2, 69,
                            4, 43, 1, 44,
                            6, 19, 2, 20,
                            6, 15, 2, 16,
                            4, 81, 0, 0,
                            1, 50, 4, 51,
                            4, 22, 4, 23,
                            3, 12, 8, 13,
                            2, 92, 2, 93,
                            6, 36, 2, 37,
                            4, 20, 6, 21,
                            7, 14, 4, 15,
                            4, 107, 0, 0,
                            8, 37, 1, 38,
                            8, 20, 4, 21,
                            12, 11, 4, 12,
                            3, 115, 1, 116,
                            4, 40, 5, 41,
                            11, 16, 5, 17,
                            11, 12, 5, 13, 
                            5, 87, 1, 88,      
                            5, 41, 5, 42,
                            5, 24, 7, 25,
                            11, 12, 7, 13,
                            5, 98, 1, 99,
                            7, 45, 3, 46,
                            15, 19, 2, 20,
                            3, 15, 13, 16,
                            1, 107, 5, 108,
                            10, 46, 1, 47,
                            1, 22, 15, 23,
                            2, 14, 17, 15,
                            5, 120, 1, 121,
                            9, 43, 4, 44,
                            17, 22, 1, 23,
                            2, 14, 19, 15,
                            3, 113, 4, 114,
                            3, 44, 11, 45,
                            17, 21, 4, 22,
                            9, 13, 16, 14,
                            3, 107, 5, 108,
                            3, 41, 13, 42,
                            15, 24, 5, 25,
                            15, 15, 10, 16,
                            4, 116, 4, 117,
                            17, 42, 0, 0,
                            17, 22, 6, 23,
                            19, 16, 6, 17,
                            2, 111, 7, 112,
                            17, 46, 0, 0,
                            7, 24, 16, 25,
                            34, 13, 0, 0,
                            4, 121, 5, 122,
                            4, 47, 14, 48,
                            11, 24, 14, 25,
                            16, 15, 14, 16,
                            6, 117, 4, 118,
                            6, 45, 14, 46,
                            11, 24, 16, 25,
                            30, 16, 2, 17,
                            8, 106, 4, 107,
                            8, 47, 13, 48,
                            7, 24, 22, 25,
                            22, 15, 13, 16,
                            10, 114, 2, 115,
                            19, 46, 4, 47,
                            28, 22, 6, 23,
                            33, 16, 4, 17,
                            8, 122, 4, 123,
                            22, 45, 3, 46,
                            8, 23, 26, 24,
                            12, 15, 28, 16,
                            3, 117, 10, 118,
                            3, 45, 23, 46,
                            4, 24, 31, 25,
                            11, 15, 31, 16,
                            7, 116, 7, 117,
                            21, 45, 7, 46,
                            1, 23, 37, 24,
                            19, 15, 26, 16,
                            5, 115, 10, 116,
                            19, 47, 10, 48,
                            15, 24, 25, 25,
                            23, 15, 25, 16,
                            13, 115, 3, 116,
                            2, 46, 29, 47,
                            42, 24, 1, 25,
                            23, 15, 28, 16,
                            17, 115, 0, 0,
                            10, 46, 23, 47,
                            10, 24, 35, 25,
                            19, 15, 35, 16,
                            17, 115, 1, 116,
                            14, 46, 21, 47,
                            29, 24, 19, 25,
                            11, 15, 46, 16,
                            13, 115, 6, 116,
                            14, 46, 23, 47,
                            44, 24, 7, 25,
                            59, 16, 1, 17,
                            12, 121, 7, 122,
                            12, 47, 26, 48,
                            39, 24, 14, 25,
                            22, 15, 41, 16,
                            6, 121, 14, 122,
                            6, 47, 34, 48,
                            46, 24, 10, 25,
                            2, 15, 64, 16,
                            17, 122, 4, 123,
                            29, 46, 14, 47,
                            49, 24, 10, 25,
                            24, 15, 46, 16,
                            4, 122, 18, 123,
                            13, 46, 32, 47,
                            48, 24, 14, 25,
                            42, 15, 32, 16,
                            20, 117, 4, 118,
                            40, 47, 7, 48,
                            43, 24, 22, 25,
                            10, 15, 67, 16,
                            19, 118, 6, 119,
                            18, 47, 31, 48,
                            34, 24, 34, 25,
                            20, 15, 61, 16
                            };
            var code = total_codewords[4 * (version - 1) + comboBox1.SelectedIndex];
            var ec = ec_codewords[4 * (version - 1) + comboBox1.SelectedIndex];
            int bit;
            if (version < 10)
                bit = 8;
            else if (version < 27)
                bit = 16;
            else
                bit = 16;
            var fullBit = code * 8;


            var arrayb = new char[qrtext.Length];
            byte[] codeBytes;
            for (var i = 0; i < qrtext.Length; i++)
            {
                arrayb[i] = qrtext[i];
            }
            codeBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(arrayb);
            var array = new string[qrtext.Length];
            for (var i = 0; i < qrtext.Length; i++)
            {
                array[i] = Convert.ToString(codeBytes[i],2);
                array[i] = addingZeros(array[i], 8);
            }


            // длина текста в двоичном
            string countIndicator = addingZeros(Convert.ToString(array.Length, 2), bit);

            var text = modeIndicator + countIndicator;       
            foreach (var i in array)
                text += i;


            // терминатор из нулей
            var terminator = "";
            if (text.Length < fullBit)
            {
                if (fullBit - text.Length > 4)
                    terminator = "0000";
                else
                {
                    for (var i = 0; i < fullBit - text.Length; i++)
                        terminator += "0";
                }

                text += terminator;
            }

            // добавление до кратности 8
            if (text.Length % 8 != 0)
            {
                var len = text.Length;
                for (var i = 0; i < (8 - (len % 8)); i++)
                    text += "0";
            }

            // заполнение до максимума QR кода
            while (text.Length < fullBit)
            {
                text += "11101100";
                if (text.Length == fullBit)
                    break;
                text += "00010001";
            }


            // разбитие по 8
            int n_;
            
            if (text.Length % 8 == 0)
                n_ = text.Length / 8;
            else
                n_ = text.Length / 8 + 1;
            var array_ = new string[n_];

            for (int i = 0; i < text.Length / 8; i++)
            {
                array_[i] = text.Substring(i * 8, 8);
            }
            if (qrtext.Length % 8 != 0)
            {
                int len = array_.Length - 1;
                array_[len] = text.Substring((len) * 8);
            }

            // преобразование в десятичный
            var arrayDec = new int[array_.Length];
            for (var i = 0; i < array_.Length; i++)
                arrayDec[i] = Convert.ToInt32(array_[i], 2);

            var groups = new int[2][][];
            var count = 0;
            var block1_count = blocks[4 * (4 * (version - 1) + comboBox1.SelectedIndex)];
            var block1_size = blocks[4 * (4 * (version - 1) + comboBox1.SelectedIndex) + 1];
            var block2_count = blocks[4 * (4 * (version - 1) + comboBox1.SelectedIndex) + 2];
            var block2_size = blocks[4 * (4 * (version - 1) + comboBox1.SelectedIndex) + 3];
            groups[0] = new int[block1_count][];
            for (var i = 0; i < block1_count; i++)
            {
                groups[0][i] = new int[block1_size];
                for (var j = 0; j < block1_size; j++)
                {
                    groups[0][i][j] = arrayDec[count];
                    count++;
                }
            }
            if (block2_count > 0)
            {
                groups[1] = new int[block2_count][];
                for (var i = 0; i < block2_count; i++)
                {
                    groups[1][i] = new int[block2_size];
                    for (var j = 0; j < block2_size; j++)
                    {
                        groups[1][i][j] = arrayDec[count];
                        count++;
                    }
                }
            }

            var generation = codeReed_Solomon(ec);
            var correction = new int[block1_count + block2_count][];
            var k = 0;
            for (; k < block1_count; k++)
            {
                correction[k] = new int[ec];
                correction[k] = dividePol(groups[0][k], generation);
            }
            for (var j = 0; j < block2_count; j++)
            {
                correction[k] = new int[ec];
                correction[k] = dividePol(groups[1][j], generation);
                k++;
            }

            var final = new int[block1_count*block1_size + block2_count*block2_size + ec*correction.Length];
            var finCounter = 0;
            for (var i = 0; i < Math.Max(block1_size, block2_size); i++)
            {
                if (i < block1_size)
                {
                    for (var j = 0; j < block1_count; j++)
                    {
                        final[finCounter] = groups[0][j][i];
                        finCounter++;
                    }
                }
                for (var j = 0; j < block2_count; j++)
                {
                    final[finCounter] = groups[1][j][i];
                    finCounter++;
                }
            }
            for (var i = 0; i < ec; i++)
            {
                for (var j = 0; j < correction.Length; j++)
                {
                    final[finCounter] = correction[j][i];
                    finCounter++;
                }
            }



            // в двоичный
            var finalArrayTo2 = new string[final.Length];
            for (var i = 0; i < finalArrayTo2.Length; i++)
            {
                finalArrayTo2[i] = addingZeros(Convert.ToString(Convert.ToInt32(final[i]), 2), 8);
            }

            placement(finalArrayTo2, version, lvl);
        }


        private string addingZeros(string main, int count)
        {
            string tmp = "";
            for (var i = 0; i < count - main.Length; i++)
                tmp += "0";
            return main = tmp + main;
        }

        private int[] codeReed_Solomon(int ec)
        {
            var genPol = new int[ec][];
            genPol[0] = new int[ec + 1];
            genPol[0][0] = 1;
            genPol[0][1] = 1;
            for (var i = 1; i < ec; i++)
            {
                genPol[i] = new int[ec + 1];
                genPol[i][0] = 1;
                var j = 1;
                for (; j <= i; j++)
                    genPol[i][j] = multGF256(expGF256(i), genPol[i - 1][j - 1]) ^ genPol[i - 1][j];
                genPol[i][j] = multGF256(expGF256(i), genPol[i - 1][j - 1]);
            }
            return genPol[ec - 1];
        }

        private int[] dividePol(int[] arrayDec, int[] genPol)
        {
            var mainArray = new int[arrayDec.Length + genPol.Length - 1];
            for (var i = 0; i < arrayDec.Length; i++)
            {
                mainArray[i] = arrayDec[i];
            }

            var divArray = new int[genPol.Length];
            for (var i = 0; i < genPol.Length; i++)
            {
                divArray[i] = genPol[i];
            }



            for (var i = 0; i < arrayDec.Length; i++)
            {
                var tmp = new int[arrayDec.Length + genPol.Length - 1];
                var lead = mainArray[i];
                var h = 0;
                for (var j = i; j < i + genPol.Length; j++)
                {
                    tmp[j] = multGF256(lead, divArray[h]);
                    mainArray[j] ^= tmp[j];
                    h++;
                }
            }
            var finalArray = new int[genPol.Length - 1];
            for (var i = 0; i < genPol.Length - 1; i++)
            {
                finalArray[i] = mainArray[arrayDec.Length + i];
            }
            return finalArray;
        }

        private int logGF256(int index)
        {
            var array = new int[] {0, 1, 25, 2, 50, 26, 198, 3, 223, 51, 238, 27, 104, 199, 75, 4,
                                   100, 224, 14, 52, 141, 239, 129, 28, 193, 105, 248, 200, 8, 76, 113, 5,
                                   138, 101, 47, 225, 36, 15, 33, 53, 147, 142, 218, 240, 18, 130, 69,
                                   29, 181, 194, 125, 106, 39, 249, 185, 201, 154, 9, 120, 77, 228, 114,
                                   166, 6, 191, 139, 98, 102, 221, 48, 253, 226, 152, 37, 179, 16, 145,
                                   34, 136, 54, 208, 148, 206, 143, 150, 219, 189, 241, 210, 19, 92,
                                   131, 56, 70, 64, 30, 66, 182, 163, 195, 72, 126, 110, 107, 58, 40,
                                   84, 250, 133, 186, 61, 202, 94, 155, 159, 10, 21, 121, 43, 78, 212,
                                   229, 172, 115, 243, 167, 87, 7, 112, 192, 247, 140, 128, 99, 13, 103,
                                   74, 222, 237, 49, 197, 254, 24, 227, 165, 153, 119, 38, 184, 180,
                                   124, 17, 68, 146, 217, 35, 32, 137, 46, 55, 63, 209, 91, 149, 188,
                                   207, 205, 144, 135, 151, 178, 220, 252, 190, 97, 242, 86, 211, 171,
                                   20, 42, 93, 158, 132, 60, 57, 83, 71, 109, 65, 162, 31, 45, 67, 216,
                                   183, 123, 164, 118, 196, 23, 73, 236, 127, 12, 111, 246, 108, 161,
                                   59, 82, 41, 157, 85, 170, 251, 96, 134, 177, 187, 204, 62, 90, 203,
                                   89, 95, 176, 156, 169, 160, 81, 11, 245, 22, 235, 122, 117, 44, 215,
                                   79, 174, 213, 233, 230, 231, 173, 232, 116, 214, 244, 234, 168, 80,
                                   88, 175 };
            return array[index - 1];
        }

        private int expGF256(int index)
        {
            var array = new int[] {1, 2, 4, 8, 16, 32, 64, 128, 29, 58, 116, 232, 205, 135, 19, 38,
                                   76, 152, 45, 90, 180, 117, 234, 201, 143, 3, 6, 12, 24, 48, 96, 192, 157,
                                   39, 78, 156, 37, 74, 148, 53, 106, 212, 181, 119, 238, 193, 159, 35,
                                   70, 140, 5, 10, 20, 40, 80, 160, 93, 186, 105, 210, 185, 111, 222,
                                   161, 95, 190, 97, 194, 153, 47, 94, 188, 101, 202, 137, 15, 30, 60,
                                   120, 240, 253, 231, 211, 187, 107, 214, 177, 127, 254, 225, 223, 163,
                                   91, 182, 113, 226, 217, 175, 67, 134, 17, 34, 68, 136, 13, 26, 52,
                                   104, 208, 189, 103, 206, 129, 31, 62, 124, 248, 237, 199, 147, 59,
                                   118, 236, 197, 151, 51, 102, 204, 133, 23, 46, 92, 184, 109, 218,
                                   169, 79, 158, 33, 66, 132, 21, 42, 84, 168, 77, 154, 41, 82, 164, 85,
                                   170, 73, 146, 57, 114, 228, 213, 183, 115, 230, 209, 191, 99, 198,
                                   145, 63, 126, 252, 229, 215, 179, 123, 246, 241, 255, 227, 219, 171,
                                   75, 150, 49, 98, 196, 149, 55, 110, 220, 165, 87, 174, 65, 130, 25,
                                   50, 100, 200, 141, 7, 14, 28, 56, 112, 224, 221, 167, 83, 166, 81,
                                   162, 89, 178, 121, 242, 249, 239, 195, 155, 43, 86, 172, 69, 138, 9,
                                   18, 36, 72, 144, 61, 122, 244, 245, 247, 243, 251, 235, 203, 139, 11,
                                   22, 44, 88, 176, 125, 250, 233, 207, 131, 27, 54, 108, 216, 173, 71,
                                   142, 1};
            return array[index];
        }

        private int multGF256(int a, int b)
        {
            if (a == 0)
                a = 1;
            if (b == 0)
                b = 1;
            var c = logGF256(a) + logGF256(b);
            if (c >= 256)
                c %= 255;
            return expGF256(c);
        }

        private void placement(string[] finalArrayTo2, int v, string lvl)
        {
            var scale = trackBar1.Value;
            var size = ((v - 1) * 4) + 21;
            Bitmap qrcode = new Bitmap(size, size);
            // искатель
            finder(qrcode, 0, 0);
            finder(qrcode, size - 7, 0);
            finder(qrcode, 0, size - 7);

            // темный модуль
            darkMod(qrcode, v);

            // резервирование ечееек
            reserve(qrcode, size, v);

            // шаблон выравнивания
            var alignCoord = new int[][] 
            {
                new int[] { 6, 18 },
                new int[] { 6, 22 },
                new int[] { 6, 26 },
                new int[] { 6, 30 },
                new int[] { 6, 34 },
                new int[] { 6, 22, 38 },
                new int[] { 6, 24, 42 },
                new int[] { 6, 26, 46 },
                new int[] { 6, 28, 50 },
                new int[] { 6, 30, 54 },
                new int[] { 6, 32, 58 },
                new int[] { 6, 34, 62 },
                new int[] { 6, 26, 46, 66 },
                new int[] { 6, 26, 48, 70 },
                new int[] { 6, 26, 50, 74 },
                new int[] { 6, 30, 54, 78 },
                new int[] { 6, 30, 56, 82 },
                new int[] { 6, 30, 58, 86 },
                new int[] { 6, 34, 62, 90 },
                new int[] { 6, 28, 50, 72, 94 },
                new int[] { 6, 26, 50, 74, 98 },
                new int[] { 6, 30, 54, 78, 102 },
                new int[] { 6, 28, 54, 80, 106 },
                new int[] { 6, 32, 58, 84, 110 },
                new int[] { 6, 30, 58, 86, 114 },
                new int[] { 6, 34, 62, 90, 118 },
                new int[] { 6, 26, 50, 74, 98, 122 },
                new int[] { 6, 30, 54, 78, 102, 126 },
                new int[] { 6, 26, 52, 78, 104, 130 },
                new int[] { 6, 30, 56, 82, 108, 134 },
                new int[] { 6, 34, 60, 86, 112, 138 },
                new int[] { 6, 30, 58, 86, 114, 142 },
                new int[] { 6, 34, 62, 90, 118, 146 },
                new int[] { 6, 30, 54, 78, 102, 126, 150 },
                new int[] { 6, 24, 50, 76, 102, 128, 154 },
                new int[] { 6, 28, 54, 80, 106, 132, 158 },
                new int[] { 6, 32, 58, 84, 110, 136, 162 },
                new int[] { 6, 26, 54, 82, 110, 138, 166 },
                new int[] { 6, 30, 58, 86, 114, 142, 170 }
            };
            if (v > 1)
                alignment(qrcode, alignCoord[v - 2]);

            // шаблон синхроницзации
            timing(qrcode, size);
            separator(qrcode, size);

            // размещение данных
            var dataMask = place(qrcode, size, v, finalArrayTo2);

            // маскировка данных
            var qr = penalty(qrcode, size, dataMask, lvl, v);

            // тихая зона
            qr = quietZone(qr, size);
            size = size + 8;
            Bitmap scaledQr = new Bitmap(size * scale, size * scale);
            scaling(qr, size, scaledQr, scale);

            pictureBox1.Image = scaledQr as Image;
        }

        private Bitmap quietZone(Bitmap qr, int size)
        {
            var newQr = new Bitmap(size + 8, size + 8);
            for (var i = 0; i < size + 8; i++)
            {
                for(var j = 0; j < size + 8; j++)
                {
                    newQr.SetPixel(i, j, Color.White);
                }
            }
            for (var i = 4; i < size + 4; i++)
            {
                for (var j = 4; j < size + 4; j++)
                {
                    newQr.SetPixel(i, j, qr.GetPixel(i - 4, j - 4));
                }
            }
            return newQr;
        }

        private void enterReserve(Bitmap qr, string format, int size) 
        {
            var count = 0;
            
            for (var i = 0; i < 6; i++)
            {
                if (format[count] == '0')
                    qr.SetPixel(i, 8, Color.White);
                else
                    qr.SetPixel(i, 8, Color.Black);
                count++;
            }

            for (var i = 7; i < 9; i++)
            {
                if (format[count] == '0')
                    qr.SetPixel(i, 8, Color.White);
                else
                    qr.SetPixel(i, 8, Color.Black);
                count++;
            }

            if (format[count] == '0')
                qr.SetPixel(8, 7, Color.White);
            else
                qr.SetPixel(8, 7, Color.Black);
            count++;

            for (var i = 5; i >= 0; i--)
            {
                if (format[count] == '0')
                    qr.SetPixel(8, i, Color.White);
                else
                    qr.SetPixel(8, i, Color.Black);
                count++;
            }
            count = 0;
            

            for (var i = 0; i < 7; i++)
            {
                if (format[count] == '0')
                    qr.SetPixel(8, size - 1 - i, Color.White);
                else
                    qr.SetPixel(8, size - 1 - i, Color.Black);
                count++;
            }

            for (var i = 7; i >= 0; i--)
            {
                if (format[count] == '0')
                    qr.SetPixel(size - 1 - i, 8, Color.White);
                else
                    qr.SetPixel(size - 1 - i, 8, Color.Black);
                count++;
            }

        }

        private string formatString (string level, int pattern)
        {
            var res = "";
            switch (level)
            {
                case "L":
                    res += "01";
                    break;
                case "M":
                    res += "00";
                    break;
                case "Q":
                    res += "11";
                    break;
                default:
                    res += "10";
                    break;
            }
            res += addingZeros(Convert.ToString(pattern, 2), 3);
            var strPol = "10100110111";
            var main = res + "0000000000";
            while (main[0] == '0' && main.Length > 10) 
            {
                main = main.Substring(1);
            }
            while (main.Length > 10)
            {
                var div = strPol;
                var len = main.Length - div.Length;
                for (var i = 0; i < len; i++)
                {
                    div += "0";
                }

                main = Convert.ToString(Convert.ToInt32(main, 2) ^ Convert.ToInt32(div, 2), 2);
            }
            if (main.Length < 10)
            {
                var len = 10 - main.Length;
                var tmp = "";
                for (var i = 0; i < len; i++)
                {
                    tmp += "0";
                }
                main = tmp + main;
            }
            
            res = res + main;
            res = Convert.ToString(Convert.ToInt32(res, 2) ^ Convert.ToInt32("101010000010010", 2), 2);
            return addingZeros(res, 15);
        }

        private Bitmap enterSecondReserve(Bitmap Qr, int size, int v)
        {
            var strPol = "1111100100101";
            var sixBit = addingZeros(Convert.ToString(v, 2), 6);
            var main = sixBit + "000000000000";
            while (main[0] == '0' && main.Length > 12)
            {
                main = main.Substring(1);
            }
            while (main.Length > 12)
            {
                var div = strPol;
                var len = main.Length - div.Length;
                for (var i = 0; i < len; i++)
                {
                    div += "0";
                }

                main = Convert.ToString(Convert.ToInt32(main, 2) ^ Convert.ToInt32(div, 2), 2);
            }
            if(main.Length < 12)
            {
                var len = 12 - main.Length;
                var tmp = "";
                for (var i = 0; i < len; i++)
                {
                    tmp += "0";
                }
                main = tmp + main;
            }
            main = sixBit + main;

            var count = 17;
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (main[count] == '0')
                    {
                        Qr.SetPixel(i, size - 11 + j, Color.White);
                        Qr.SetPixel(size - 11 + j, i, Color.White);
                    }
                    else
                    {
                        Qr.SetPixel(i, size - 11 + j, Color.Black);
                        Qr.SetPixel(size - 11 + j, i, Color.Black);
                    }
                    count--;
                }
            }

            return Qr;
        }

        private void finder(Bitmap qrcode, int x, int y)
        {
            for (var i = 0; i < 7; i++)
            {
                qrcode.SetPixel(x + i, y, Color.Black);
                qrcode.SetPixel(x, y + i, Color.Black);
                qrcode.SetPixel(x + i, y + 6, Color.Black);
                qrcode.SetPixel(x + 6, y + i, Color.Black);
            }

            for (var i = 1; i < 6; i++)
            {
                qrcode.SetPixel(x + i, y + 1, Color.White);
                qrcode.SetPixel(x + 1, y + i, Color.White);
                qrcode.SetPixel(x + i, y + 5, Color.White);
                qrcode.SetPixel(x + 5, y + i, Color.White);
            }

            for (var i = 2; i < 5; i++)
            {
                for (var j = 2; j < 5; j++)
                {
                    qrcode.SetPixel(x + i, y + j, Color.Black);
                }
            }
        }

        private void timing(Bitmap qrcode, int size)
        {
            for (var i = 0; i < size - 16; i += 2)
            {
                qrcode.SetPixel(6, 8 + i, Color.Black);
                qrcode.SetPixel(8 + i, 6, Color.Black);
            }
            for (var i = 1; i < size - 16; i += 2)
            {
                qrcode.SetPixel(6, 8 + i, Color.White);
                qrcode.SetPixel(8 + i, 6, Color.White);
            }
        }

        private void separator(Bitmap qrcode, int size)
        {
            for (var i = 0; i < 8; i++)
            {
                qrcode.SetPixel(7, i, Color.White);
                qrcode.SetPixel(i, 7, Color.White);
                qrcode.SetPixel(size - 8, i, Color.White);
                qrcode.SetPixel(i, size - 8, Color.White);
                qrcode.SetPixel(size - 1 - i, 7, Color.White);
                qrcode.SetPixel(7, size - 1 - i, Color.White);
            }
        }

        private void alignment(Bitmap qrcode, int[] align)
        {
            for (var i = 0; i < align.Length; i++)
            {
                for (var j = 0; j < align.Length; j++)
                {
                    if (qrcode.GetPixel(align[i], align[j]).ToArgb() == 0)
                    {
                        setAlignment(qrcode, align[i], align[j]);
                    }
                }
            }
        }

        private void setAlignment(Bitmap qrcode, int x, int y)
        {
            qrcode.SetPixel(x, y, Color.Black);
            for (var i = 0; i < 3; i++)
            {
                qrcode.SetPixel(x - 1, y - 1 + i, Color.White);
                qrcode.SetPixel(x + 1, y - 1 + i, Color.White);
                qrcode.SetPixel(x - 1 + i, y - 2, Color.Black);
                qrcode.SetPixel(x - 1 + i, y + 2, Color.Black);
            }
            qrcode.SetPixel(x, y - 1, Color.White);
            qrcode.SetPixel(x, y + 1, Color.White);
            for (var i = 0; i < 5; i++)
            {
                qrcode.SetPixel(x - 2, y - 2 + i, Color.Black);
                qrcode.SetPixel(x + 2, y - 2 + i, Color.Black);
            }
        }
        private void darkMod(Bitmap qrcode, int v)
        {
            qrcode.SetPixel(8, (4 * v) + 9, Color.Black);
        }

        private void reserve(Bitmap qrcode, int size, int v)
        {
            for (var i = 0; i < 9; i++)
            {
                if (i != 6)
                {
                    qrcode.SetPixel(8, i, Color.Blue);
                    qrcode.SetPixel(i, 8, Color.Blue);
                }
            }
            for (var i = 0; i < 8; i++)
                qrcode.SetPixel(size - 1 - i, 8, Color.Blue);
            for (var i = 0; i < 7; i++)
                qrcode.SetPixel(8, size - 1 - i, Color.Blue);

            if (v > 6) 
            {
                for (var i = 0; i < 6; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        qrcode.SetPixel(i, size - 11 + j, Color.Blue);
                        qrcode.SetPixel(size - 11 + j, i, Color.Blue);
                    }
                }
            }
        }

        private int[,] place(Bitmap qrcode, int size, int v, string[] array)
        {
            int[] remainder = { 0, 7, 7, 7, 7, 7, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0 };
            string data = "";
            for (var i = 0; i < array.Length; i++)
                data += array[i];
            for (var i = 0; i < remainder[v - 1]; i++)
                data += "0";
            var dataMask = new int[size, size];
            var count = 0;
            for (var i = size - 1; i > 0; i -= 2)
            {
                for (var j = size - 1; j >= 0; j--)
                {
                    for (var k = i; k >= i - 1; k--)
                    {
                        Color tmpcolor = qrcode.GetPixel(k, j);
                        if (tmpcolor.ToArgb() == 0)
                        {
                            if (data[count] == '0')
                            {
                                qrcode.SetPixel(k, j, Color.White);
                                dataMask[k, j] = 1;
                            }
                            else
                            {
                                qrcode.SetPixel(k, j, Color.Black);
                                dataMask[k, j] = 2;
                            }
                            count++;
                        }
                    }
                }
                i -= 2;
                if (i == 6)
                    i--;
                for (var j = 0; j < size; j++)
                {
                    for (var k = i; k >= i - 1; k--)
                    {
                        Color tmpcolor = qrcode.GetPixel(k, j);
                        if (tmpcolor.ToArgb() == 0 && count != data.Length)
                        {
                            if (data[count] == '0')
                            {
                                qrcode.SetPixel(k, j, Color.White);
                                dataMask[k, j] = 1;
                            }
                            else
                            {
                                qrcode.SetPixel(k, j, Color.Black);
                                dataMask[k, j] = 2;
                            }
                            count++;
                        }
                    }
                }

            }
            return dataMask;
        }

        private Bitmap penalty(Bitmap qrcode, int size, int[,] dataMask, string lvl, int v)
        {
            var penalties = new int[8];
            string format;
            // 0
            var mask0 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && (i + j) % 2 == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask0.SetPixel(i, j, Color.White);
                        else
                            mask0.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 0);
            enterReserve(mask0, format, size);
            if (v > 6)
                mask0 = enterSecondReserve(mask0, size, v);
            

            penalties[0] += pen1(mask0, size);
            penalties[0] += pen2(mask0, size);
            penalties[0] += pen3(mask0, size);
            penalties[0] += pen4(mask0, size);

            // 1
            var mask1 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && (j) % 2 == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask1.SetPixel(i, j, Color.White);
                        else 
                            mask1.SetPixel(i, j, Color.Black);
                    }
                }
            }


            format = formatString(lvl, 1);
            enterReserve(mask1, format, size);
            if (v > 6)
                mask1 = enterSecondReserve(mask1, size, v);

            penalties[1] += pen1(mask1, size);
            penalties[1] += pen2(mask1, size);
            penalties[1] += pen3(mask1, size);
            penalties[1] += pen4(mask1, size);

            // 2
            var mask2 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && (i) % 3 == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask2.SetPixel(i, j, Color.White);
                        else
                            mask2.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 2);
            enterReserve(mask2, format, size);
            if (v > 6)
                mask2 = enterSecondReserve(mask2, size, v);

            penalties[2] += pen1(mask2, size);
            penalties[2] += pen2(mask2, size);
            penalties[2] += pen3(mask2, size);
            penalties[2] += pen4(mask2, size);

            // 3
            var mask3 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && (i + j) % 3 == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask3.SetPixel(i, j, Color.White);
                        else
                            mask3.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 3);
            enterReserve(mask3, format, size);
            if (v > 6)
                mask3 = enterSecondReserve(mask3, size, v);

            penalties[3] += pen1(mask3, size);
            penalties[3] += pen2(mask3, size);
            penalties[3] += pen3(mask3, size);
            penalties[3] += pen4(mask3, size);

            // 4
            var mask4 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && ((int)(Math.Floor((double) j / 2) + Math.Floor((double) i / 3)) % 2) == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask4.SetPixel(i, j, Color.White);
                        else
                            mask4.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 4);
            enterReserve(mask4, format, size);
            if (v > 6)
                mask4 = enterSecondReserve(mask4, size, v);

            penalties[4] += pen1(mask4, size);
            penalties[4] += pen2(mask4, size);
            penalties[4] += pen3(mask4, size);
            penalties[4] += pen4(mask4, size);

            // 5
            var mask5 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && ((i * j) % 2) + ((i * j) % 3) == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask5.SetPixel(i, j, Color.White);
                        else
                            mask5.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 5);
            enterReserve(mask5, format, size);
            if (v > 6)
                mask5 = enterSecondReserve(mask5, size, v);

            penalties[5] += pen1(mask5, size);
            penalties[5] += pen2(mask5, size);
            penalties[5] += pen3(mask5, size);
            penalties[5] += pen4(mask5, size);

            // 6
            var mask6 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && ((i * j) + ((i * j) % 3)) % 2 == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask6.SetPixel(i, j, Color.White);
                        else
                            mask6.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 6);
            enterReserve(mask6, format, size);
            if (v > 6)
                mask6 = enterSecondReserve(mask6, size, v);

            penalties[6] += pen1(mask6, size);
            penalties[6] += pen2(mask6, size);
            penalties[6] += pen3(mask6, size);
            penalties[6] += pen4(mask6, size);

            // 7
            var mask7 = new Bitmap(qrcode);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if ((dataMask[i, j] == 1 || dataMask[i, j] == 2) && ((i + j) + ((i * j) % 3)) % 2 == 0)
                    {
                        if (dataMask[i, j] == 2)
                            mask7.SetPixel(i, j, Color.White);
                        else
                            mask7.SetPixel(i, j, Color.Black);
                    }
                }
            }

            format = formatString(lvl, 7);
            enterReserve(mask7, format, size);
            if (v > 6)
                mask7 = enterSecondReserve(mask7, size, v);

            penalties[7] += pen1(mask7, size);
            penalties[7] += pen2(mask7, size);
            penalties[7] += pen3(mask7, size);
            penalties[7] += pen4(mask7, size);


            // минимальный штраф применить к qrcode
            switch (comboBox3.SelectedItem) 
            {
                case "0":
                    return mask0;
                case "1":
                    return mask1;
                case "2":
                    return mask2;
                case "3":
                    return mask3;
                case "4":
                    return mask4;
                case "5":
                    return mask5;
                case "6":
                    return mask6;
                case "7":
                    return mask7;
                default:
                    int minVal = penalties.Min();
                    int indexMin = Array.IndexOf(penalties, minVal);
                    switch (indexMin)
                    {
                        case 0:
                            return mask0;
                        case 1:
                            return mask1;
                        case 2:
                            return mask2;
                        case 3:
                            return mask3;
                        case 4:
                            return mask4;
                        case 5:
                            return mask5;
                        case 6:
                            return mask6;
                        default:
                            return mask7;
                    }
            }
        }

        private int pen1(Bitmap mask, int size)
        {
            int pen = 0;
            for (var i = 0; i < size; i++)
            {
                int count = 0;
                for (var j = 0; j < size; j++)
                {
                    if (mask.GetPixel(i, j).R == 0)
                        count++;
                    else
                        count = 0;

                    if (count == 5)
                        pen += 3;
                    else if (count > 5)
                        pen += 1;
                }
            }

            for (var j = 0; j < size; j++)
            {
                int count = 0;
                for (var i = 0; i < size; i++)
                {
                    if (mask.GetPixel(j, i).R == 0)
                        count++;
                    else
                        count = 0;

                    if (count == 5)
                        pen += 3;
                    else if (count > 5)
                        pen += 1;
                }
            }

            for (var i = 0; i < size; i++)
            {
                int count = 0;
                for (var j = 0; j < size; j++)
                {
                    if (mask.GetPixel(i, j).R == 255)
                        count++;
                    else
                        count = 0;

                    if (count == 5)
                        pen += 3;
                    else if (count > 5)
                        pen += 1;
                }
            }

            for (var j = 0; j < size; j++)
            {
                int count = 0;
                for (var i = 0; i < size; i++)
                {
                    if (mask.GetPixel(j, i).R == 255)
                        count++;
                    else
                        count = 0;

                    if (count == 5)
                        pen += 3;
                    else if (count > 5)
                        pen += 1;
                }
            }
            return pen;
        }

        private int pen2(Bitmap mask, int size)
        {
            int pen = 0;
            for (var i = 0; i < size - 1; i++)
            {
                for (var j = 0; j < size - 1; j++)
                {
                    if (mask.GetPixel(i, j).R == 0 && mask.GetPixel(i + 1, j).R == 0 && mask.GetPixel(i, j + 1).R == 0 && mask.GetPixel(i + 1, j + 1).R == 0)
                        pen += 3;
                    else if (mask.GetPixel(i, j).R == 255 && mask.GetPixel(i + 1, j).R == 255 && mask.GetPixel(i, j + 1).R == 255 && mask.GetPixel(i + 1, j + 1).R == 255)
                        pen += 3;
                }
            }
            return pen;
        }

        private int pen3(Bitmap mask, int size)
        {
            int pen = 0;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size - 10; j++)
                {
                    if (mask.GetPixel(i, j).R == 0 && mask.GetPixel(i, j + 1).R == 255 && mask.GetPixel(i, j + 2).R == 0 && mask.GetPixel(i, j + 3).R == 0 &&
                        mask.GetPixel(i, j + 4).R == 0 && mask.GetPixel(i, j + 5).R == 255 && mask.GetPixel(i, j + 6).R == 0 && mask.GetPixel(i, j + 7).R == 255 &&
                        mask.GetPixel(i, j + 8).R == 255 && mask.GetPixel(i, j + 9).R == 255 && mask.GetPixel(i, j + 10).R == 255)
                        pen += 40;
                    if (mask.GetPixel(i, j).R == 255 && mask.GetPixel(i, j + 1).R == 255 && mask.GetPixel(i, j + 2).R == 255 && mask.GetPixel(i, j + 3).R == 255 &&
                        mask.GetPixel(i, j + 4).R == 0 && mask.GetPixel(i, j + 5).R == 255 && mask.GetPixel(i, j + 6).R == 0 && mask.GetPixel(i, j + 7).R == 0 &&
                        mask.GetPixel(i, j + 8).R == 0 && mask.GetPixel(i, j + 9).R == 255 && mask.GetPixel(i, j + 10).R == 0)
                        pen += 40;
                }
            }
            for (var j = 0; j < size; j++)
            {
                for (var i = 0; i < size - 10; i++)
                {
                    if (mask.GetPixel(i, j).R == 0 && mask.GetPixel(i + 1, j).R == 255 && mask.GetPixel(i + 2, j).R == 0 && mask.GetPixel(i + 3, j).R == 0 &&
                        mask.GetPixel(i + 4, j).R == 0 && mask.GetPixel(i + 5, j).R == 255 && mask.GetPixel(i + 6, j).R == 0 && mask.GetPixel(i + 7, j).R == 255 &&
                        mask.GetPixel(i + 8, j).R == 255 && mask.GetPixel(i + 9, j).R == 255 && mask.GetPixel(i + 10, j).R == 255)
                        pen += 40;
                    if (mask.GetPixel(i, j).R == 255 && mask.GetPixel(i + 1, j).R == 255 && mask.GetPixel(i + 2, j).R == 255 && mask.GetPixel(i + 3, j).R == 255 &&
                        mask.GetPixel(i + 4, j).R == 0 && mask.GetPixel(i + 5, j).R == 255 && mask.GetPixel(i + 6, j).R == 0 && mask.GetPixel(i + 7, j).R == 0 &&
                        mask.GetPixel(i + 8, j).R == 0 && mask.GetPixel(i + 9, j).R == 255 && mask.GetPixel(i + 10, j).R == 0)
                        pen += 40;
                }
            }
            return pen;
        }

        private int pen4(Bitmap mask, int size)
        {
            int pen = 0;
            int totalmodules = 0;
            int darkmodules = 0;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    totalmodules++;
                    if (mask.GetPixel(i, j) == Color.Black)
                        darkmodules++;
                }
            }
            var percent = darkmodules / totalmodules * 100;
            int left  = ((int)percent / 5) * 5;
            int right = ((int)percent / 5 + 1) * 5;
            left  = Math.Abs(left - 50) / 5;
            right = Math.Abs(right - 50) / 5;
            pen = Math.Min(left, right) * 10;
            return pen;
        }

        private void scaling(Bitmap qrcode, int size, Bitmap scaledQr, int scale)
        {
            for (var k = 0; k < size * scale; k += scale)
            {
                for (var i = 0; i < size * scale; i += scale)
                {
                    Color pixelColor = qrcode.GetPixel(k / scale, i / scale);
                    for (var j = k; j < k + scale; j++)
                    {
                        for (var h = i; h < i + scale; h++)
                        {
                            scaledQr.SetPixel(j, h, pixelColor);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); 
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp"; 
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName); 
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(trackBar1.Value);
            if (pictureBox1.Image != null)
            {
                Encode(textBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Encode(textBox1.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Encode(textBox1.Text);
            if (textBox1.Text == "")
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Encode(textBox1.Text);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Encode(textBox1.Text);
            }
        }
    }
}
