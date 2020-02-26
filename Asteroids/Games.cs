using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Image background = Image.FromFile("Images\\fon.jpg");

        public static BaseObject[] _objs;

        static Game()
        {
        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();

        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            _objs = new BaseObject[90];
            for (int i = 0; i < 10; i++)
                _objs[i] = new Star(new Point(600, i * 20), new Point(15 - i, 15 - i + 1), new Size(20, 20));
            for (int i = 10; i < 20; i++)
                _objs[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i + 1), new Size(20, 20));
            for (int i = 20; i < 30; i++)
                _objs[i] = new Asteroid(new Point(600, i * 20), new Point(15 - i, 15 - i + 1), new Size(20, 20));
            for (int i = 30; i < 60; i++)
                _objs[i] = new Flash(new Point(600, i * 10), new Point(15 - i, 15 - i + 1), new Size(10, 10));      
            for (int i = 60; i < 90; i++)
                _objs[i] = new Line(new Point(600, i * 10), new Point(10 - i, 5 - i + 1), new Size(10, 10));

        }

        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(background, 0, 0);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));

            foreach (BaseObject obj in _objs)
                obj.Draw();

            Buffer.Render();
        }

    }

}
