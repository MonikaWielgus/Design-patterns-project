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
            Circle body = (Circle)snake[snake.Count - 1].Clone();
            if (snake.Count - 1 == 0)
            {
                Details details = DetailsFactory.getFigureDetails(new PinkFigureLibrary().GetType().ToString());
                body.details = details;
            }


            snake.Add(body);

            Settings.Score += Settings.Points;
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();
        }

        public override void GenerateFood()
        {
            int maxXpos = Width / ElementSize - 1;
            int maxYpos = Height / ElementSize - 1;
            Random rnd = new Random();
            Details details = DetailsFactory.getFigureDetails(new GreenFigureLibrary().GetType().ToString());
            Food = new Circle(rnd.Next(0, maxXpos), rnd.Next(0, maxYpos), details);
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

                    int maxXpos = Width / ElementSize - 1;
                    int maxYpos = Height / ElementSize - 1;

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
                    if (snake[0].X == Food.X && snake[0].Y == Food.Y)
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
            Details details = DetailsFactory.getFigureDetails(new PurpleFigureLibrary().GetType().ToString());
            Circle head = new Circle(10, 5, details);
            snake.Add(head);
            CountScoreLabel.Text = Settings.Score.ToString();
            GenerateFood();

        }

        public override void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {

                foreach (Circle c in snake)
                {
                    c.Draw(canvas);
                }
                Food.Draw(canvas);
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
