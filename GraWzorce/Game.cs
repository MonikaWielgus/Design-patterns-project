using System;
using System.Windows.Forms;

namespace GraWzorce
{
    public abstract class Game
    {
        protected Circle Food;
        protected int Width;
        protected int Height;
        protected int ElementSize;
        protected Label EndLabel;
        protected Label ScoreLabel;
        protected Label CountScoreLabel;
        protected PictureBox PictureBox1;
        public Game()
        {
            Food = new Circle();
        }
        public void GetReferences(Label endLabel, Label scoreLabel, Label countScoreLabel, PictureBox pb)
        {
            EndLabel = endLabel;
            ScoreLabel = scoreLabel;
            CountScoreLabel = countScoreLabel;
            PictureBox1 = pb;
            Width = pb.Width;
            Height = pb.Height;
            ElementSize = Settings.Size;
            ElementSize = Settings.Size;
        }

        protected int GetX(int number)
        {
            return number % (Width / ElementSize);
        }
        protected int GetY(int number)
        {
            return number / (Width / ElementSize);
        }
        protected int RealPlace(int x, int y)
        {
            return y * (Width / ElementSize) + x;
        }
        public abstract void UpdateGraphics(object sender, PaintEventArgs e);
        public void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver == true)
            {
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;
                MovePlayer();
            }
            PictureBox1.Invalidate();
        }
        public abstract void StartGame();
        public abstract void MovePlayer();
        public abstract void GenerateFood();
        public abstract void Eat();
        public void Die()
        {
            Settings.GameOver = true;
        }

    }
}
