using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace GraWzorce
{
    public class Obstacles : Game
    {
        private Circle Hero;
        private Barriers Barrier;
        private readonly Random Rand = new Random();

        public override void Eat()
        {
            Settings.Score += Settings.Points;
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public override void GenerateFood()
        {
            int maxXpos = PictureBox1.Size.Width / Settings.Size;
            int maxYpos = PictureBox1.Size.Height / Settings.Size;
            int number = Rand.Next(0, maxXpos * maxYpos);
            if (Barrier.barriers.ContainsKey(number))
            {
                Barrier.barriers.TryGetValue(number, out bool value);
                if (value)
                {
                    GenerateFood();
                    return;
                }

            }
            Details details = DetailsFactory.getFigureDetails(new GreenFigureLibrary().GetType().ToString());
            Food = new Circle(GetX(number), GetY(number), details);
        }

        public override void MovePlayer()
        {
            switch (Settings.direction)
            {
                case Direction.Right:
                    Hero.X++;
                    break;
                case Direction.Left:
                    Hero.X--;
                    break;
                case Direction.Up:
                    Hero.Y--;
                    break;
                case Direction.Down:
                    Hero.Y++;
                    break;
            }

            int maxXpos = (Width / ElementSize) - 1;
            int maxYpos = (Height / ElementSize) - 1;

            if (
                Hero.X < 0 || Hero.Y < 0 ||
                Hero.X > maxXpos || Hero.Y > maxYpos
                )
            {
                Die();
            }
            if (Barrier.barriers.ContainsKey(RealPlace(Hero.X, Hero.Y)))
            {
                Barrier.barriers.TryGetValue(RealPlace(Hero.X, Hero.Y), out bool value);
                if (value)
                    Die();
            }
            if (Hero.X == Food.X && Hero.Y == Food.Y)
            {
                Eat();
            }
        }
        public override void StartGame()
        {
            EndLabel.Visible = false;
            new Settings();
            int v = Rand.Next(0, 2);
            BarrierCaller barrierCaller = new BarrierCaller();
            if (v == 0)
                Barrier = new BentBarriers(Width, Height, ElementSize);
            else if (v == 1)
                Barrier = new StraightBarriers(Width, Height, ElementSize);
            BarrierCaller.Do(Barrier);
            Details details = DetailsFactory.getFigureDetails(new RedFigureLibrary().GetType().ToString());
            Hero = new Circle(0, 0, details);
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public override void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {
                IFigureLibrary black = new BlackFigureLibrary();

                foreach(int k in Barrier)
                {
                    Details detail = DetailsFactory.getFigureDetails(black.GetType().ToString());
                    Figure square = new Square(GetX(k), GetY(k), detail);
                    square.Draw(canvas);
                }
                Food.Draw(canvas);

                Hero.Draw(canvas);

            }
            else
            {
                string gameOver = "Koniec gry \n" + "Twój wynik to " + Settings.Score + "\nNaciśnij enter, żeby zacząć od początku \n";
                EndLabel.Text = gameOver;
                EndLabel.Visible = true;
            }
        }

    }
}
