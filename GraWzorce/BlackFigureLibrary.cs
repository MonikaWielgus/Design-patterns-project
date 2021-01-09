using System.Drawing;

namespace GraWzorce
{
    class BlackFigureLibrary : IFigureLibrary
    {
        public void DrawCircle(int x, int y, int size, Graphics canvas)
        {
            canvas.FillEllipse(Brushes.Black,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

        public void DrawSquare(int x, int y, int size, Graphics canvas)
        {
            canvas.FillRectangle(Brushes.Black,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

    }

}
