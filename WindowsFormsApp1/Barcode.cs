using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Barcode
    {
        public Barcode(string text, int multipler = 2)
        {
            this.multipler = multipler;
            this.text = text;
            binaryText = GetBinary(text);
            //var CountryCode = 460;
            //var CompanyCode = 16541;

            //var str = $"{CountryCode}{CompanyCode}{text}";
            //var sum1 = 0;
            //var sum2 = 0;
            ////Сумма нечётных чисел
            //for (int i = 0; i < str.Length; i += 2)
            //    sum1 += int.Parse(str[i].ToString());
            ////Сумма чётных чисел
            //for (int i = 1; i < str.Length; i += 2)
            //    sum2 += int.Parse(str[i].ToString());
            //sum1 *= 3;
            //sum1 += sum2;
            //sum1 %= 10;
            //sum1 = 10 - sum1;
            //str += sum1;
        }
        public static Dictionary<int, string> CodeTable = new Dictionary<int, string>()
        {
            {0,"00000" },
            {1,"00001" },
            {2,"00011" },
            {3,"00111" },
            {4,"01111" },
            {5,"11111" },
            {6,"11110" },
            {7,"11100" },
            {8,"11000" },
            {9,"10000" },

        };
        public const int Height = 60;
        public readonly int multipler;
        private string text;
        private string binaryText;
        public static string GetBinary(string text)
        {
            var sum = "";
            foreach (var item in text)
            {
                if (CodeTable.TryGetValue(int.Parse(item.ToString()), out string value))
                {
                    sum += value;
                }
                else throw new Exception();
            }
            return sum;
        }
        public Bitmap GetBitmap()
        {
            Bitmap resultBitmap = new Bitmap(multipler * binaryText.Length+10, multipler * Height);
            Graphics g = Graphics.FromImage(resultBitmap);
            g.Clear(Color.White);
            for (int i = 0, b = 0; i < binaryText.Length; i += multipler, b++)
            {
                Color lineColor = binaryText[b] == '1' ? Color.Black : Color.White;
                Pen p = new Pen(new SolidBrush(lineColor));
                g.DrawRectangle(p, i, 0, multipler+2, resultBitmap.Height/2);
            }
            g.DrawRectangle(new Pen(Color.White), 0, resultBitmap.Height, resultBitmap.Width, 10 * multipler);
            g.FillRectangle(new SolidBrush(Color.White), 0, resultBitmap.Height, resultBitmap.Width, 10 * multipler);

            g.DrawString(text, new Font("Consolas", 7*multipler), new SolidBrush(Color.Black), 0, resultBitmap.Width);
            return resultBitmap;
        }

    }
}
