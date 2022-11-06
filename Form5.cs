using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Bitmap HandlerTexure = Resource1.Handler,
            TargetTexture = Resource1.Target;
        private Point _targetPosition = new Point(300, 300);
        private Point _direction = Point.Empty;
        private int _score = 0;

        Random r = new Random();
        Timer timer = new Timer();
        public Form5()
        {
            InitializeComponent();
            //timer.Tick += timer2_Tick;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Random r = new Random();
            timer2.Interval = r.Next(25, 1000);
            _targetPosition.X = r.Next(100, 1000);
            _targetPosition.Y = r.Next(100, 1000);
            _direction.X = r.Next(10, 200);
            _direction.Y = r.Next(10, 200);
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var localPosition = this.PointToClient(Cursor.Position);

            _targetPosition.X += _direction.X = 5;
            _targetPosition.Y += _direction.Y = 5;

            if (_targetPosition.X < 0 || _targetPosition.X > 700)
            {
                _direction.X *= -1;
                _targetPosition.X = 200;
            }
            if (_targetPosition.Y < 0 || _targetPosition.Y > 400)
            {
                _direction.Y *= -1;
                _targetPosition.Y = 200;
            }

            Point between = new Point(localPosition.X - _targetPosition.X, localPosition.Y - _targetPosition.Y);
            float distance = (float)Math.Sqrt((between.X * between.X) + (between.Y * between.Y));
            
            if (distance < 15)
            {
                AddScore(1);
            }

            var handlerRect = new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100);
            var targetRect = new Rectangle(_targetPosition.X - 50, _targetPosition.Y - 50, 100, 100);

            g.DrawImage(HandlerTexure, handlerRect);
            g.DrawImage(TargetTexture, targetRect);
        }

        private void AddScore(int score)
        {
            _score += score;
            scoreLabel.Text = _score.ToString();
        }
    }
}
