using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Captcha
    {
        Random ra = new Random(); 
        public Captcha(int height = 100, int width = 400, int fontSize = 70)
        {
            _height = height;
            _width = width;
            _fontSize = fontSize;
            _captcha = GetCaptchaString(new Random(), 10);
        }
        int _height;
        string _captcha;
        private int _width;
        int _fontSize;

        public bool CheckAnswer(string answer)
        {
            return _captcha == answer;
        }
        public static string GetCaptchaString(Random r, int maxLength)
        {
            string result = "";
            for (int i = 0; i < r.Next(3, maxLength); i++)
            {
                result += (char)r.Next('1', 'z');
            }
            return result;
        }
        Pen[] colorpens = {
Pens.Black,
Pens.Red,
Pens.RoyalBlue,
Pens.Green,
Pens.Yellow,
Pens.White,
Pens.Tomato,
Pens.Sienna,
Pens.Pink };
        public Bitmap GetCaptchaImage()
        {
            var image = new Bitmap(_captcha.Length * _fontSize, _height);
            var font = new Font("TimesNewRoman", _fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.Clear(GetRandomColor);
            graphics.DrawString(_captcha, font, new SolidBrush(GetRandomColor), new Point(0, 0));
            return image;
            graphics.DrawLine(colorpens[ra.Next(colorpens.Length)],
new Point(0, 0),
new Point(_width - 1, _height - 1));
            graphics.DrawLine(colorpens[ra.Next(colorpens.Length)],
            new Point(0, _height - 1),
            new Point(_width - 1, 0));
            for (int i = 0; i < _width; ++i)
                for (int j = 0; j < _height; ++j)
                    if (ra.Next() % 20 == 0)
                        image.SetPixel(i, j, Color.White);

            return image;
        }
        private Color GetRandomColor => Color.FromArgb(ra.Next(255), ra.Next(255), ra.Next(255));
    }
}
