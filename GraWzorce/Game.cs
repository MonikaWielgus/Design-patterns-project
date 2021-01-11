using System;
using System.Windows.Forms;

namespace GraWzorce
{
    public abstract class Game
    {
        protected Circle food;
        protected int Width { get; set; }
        protected int Height { get; set; }
        protected int SquareWidth { get; set; }
        protected int SquareHeight { get; set; }
        protected Label EndLabel { get; set; }
        protected Label ScoreLabel { get; set; }
        protected Label CountScoreLabel { get; set; }
        protected PictureBox PictureBox1 { get; set; }
        public Game()
        {
            food = new Circle();
        }
        public void GetReferences(Label endLabel, Label scoreLabel, Label countScoreLabel, PictureBox pb)
        {
            EndLabel = endLabel;
            ScoreLabel = scoreLabel;
            CountScoreLabel = countScoreLabel;
            PictureBox1 = pb;
            Width = pb.Width;
            Height = pb.Height;
            SquareWidth = Settings.Size;
            SquareHeight = Settings.Size;
        }

        protected int GetX(int number)
        {
            return number % (Width / SquareWidth);
        }
        protected int GetY(int number)
        {
            return number / (Width / SquareWidth);
        }
        protected int RealPlace(int x, int y)
        {
            return y * (Width / SquareWidth) + x;
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
