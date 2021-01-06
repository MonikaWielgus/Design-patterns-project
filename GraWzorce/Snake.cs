using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraWzorce
{
    public class Snake : Game
    {
        private List<Circle> snake = new List<Circle>();

        public override void Eat()
        {
            Circle food = new Circle
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(food);

            Settings.Score += Settings.Points;
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public override void GenerateFood()
        {
            int maxXpos = Width / SquareWidth - 1;
            int maxYpos = Height / SquareHeight - 1;
            Random rnd = new Random();
            food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };
        }

        public override void MovePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            snake[i].X++;
                            break;
                        case Direction.Left:
                            snake[i].X--;
                            break;
                        case Direction.Up:
                            snake[i].Y--;
                            break;
                        case Direction.Down:
                            snake[i].Y++;
                            break;
                    }

                    int maxXpos = Width / SquareWidth - 1;
                    int maxYpos = Height / SquareHeight - 1;

                    if (
                        snake[i].X < 0 || snake[i].Y < 0 ||
                        snake[i].X > maxXpos || snake[i].Y > maxYpos
                        )
                    {
                        Die();
                    }
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                        {
                            Die();
                        }
                    }
                    if (snake[0].X == food.X && snake[0].Y == food.Y)
                    {
                        Eat();
                    }

                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }

        public override void StartGame()
        {
            EndLabel.Visible = false;
            new Settings();
            snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            snake.Add(head);
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public override void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {

                Brush snakeColour;
                for (int i = 0; i < snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.HotPink;
                    }
                    else
                    {
                        snakeColour = Brushes.Purple;
                    }
                    canvas.FillEllipse(snakeColour,
                                        new Rectangle(
                                            snake[i].X * Settings.Width,
                                            snake[i].Y * Settings.Height,
                                            Settings.Width, Settings.Height
                                            ));

                    canvas.FillEllipse(Brushes.Black,
                                        new Rectangle(
                                            food.X * Settings.Width,
                                            food.Y * Settings.Height,
                                            Settings.Width, Settings.Height
                                            ));
                }
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
