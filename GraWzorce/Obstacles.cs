﻿using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace GraWzorce
{
    public class Obstacles : Game
    {
        private Circle hero;
        private Barriers barrier;
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
            if (barrier.barriers.ContainsKey(number))
            {
                barrier.barriers.TryGetValue(number, out bool value);
                if (value)
                {
                    GenerateFood();
                    return;
                }

            }
            Details details = DetailsFactory.getFigureDetails(new GreenFigureLibrary().GetType().ToString());
            food = new Circle(GetX(number), GetY(number), details);
        }

        public override void MovePlayer()
        {
            switch (Settings.direction)
            {
                case Direction.Right:
                    hero.X++;
                    break;
                case Direction.Left:
                    hero.X--;
                    break;
                case Direction.Up:
                    hero.Y--;
                    break;
                case Direction.Down:
                    hero.Y++;
                    break;
            }

            int maxXpos = (Width / SquareWidth) - 1;
            int maxYpos = (Height / SquareHeight) - 1;

            if (
                hero.X < 0 || hero.Y < 0 ||
                hero.X > maxXpos || hero.Y > maxYpos
                )
            {
                Die();
            }
            if (barrier.barriers.ContainsKey(RealPlace(hero.X, hero.Y)))
            {
                barrier.barriers.TryGetValue(RealPlace(hero.X, hero.Y), out bool value);
                if (value)
                    Die();
            }
            if (hero.X == food.X && hero.Y == food.Y)
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
                barrier = new BentBarriers(Width, Height, SquareWidth, SquareHeight);
            else if (v == 1)
                barrier = new StraightBarriers(Width, Height, SquareWidth, SquareHeight);
            BarrierCaller.Do(barrier);
            Details details = DetailsFactory.getFigureDetails(new RedFigureLibrary().GetType().ToString());
            hero = new Circle(0, 0, details);
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public override void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {
                bool value;
                IFigureLibrary black = new BlackFigureLibrary();
                /*foreach (var k in barrier.barriers.Keys)
                {
                    if (barrier.barriers.TryGetValue(k, out value))
                    {
                        if (value == true)
                        {
                            Details detail = DetailsFactory.getFigureDetails(black.GetType().ToString());
                            Figure square = new Square(GetX(k), GetY(k), detail);
                            square.Draw(canvas);
                        }
                    }

                }*/
                foreach(int k in barrier)
                {
                    Details detail = DetailsFactory.getFigureDetails(black.GetType().ToString());
                    Figure square = new Square(GetX(k), GetY(k), detail);
                    square.Draw(canvas);
                }
                food.Draw(canvas);

                hero.Draw(canvas);

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
