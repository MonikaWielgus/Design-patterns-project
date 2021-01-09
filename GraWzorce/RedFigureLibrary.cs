using System.Drawing;

namespace GraWzorce
{
    class RedFigureLibrary : IFigureLibrary
    {
        public void DrawCircle(int x, int y, int size, Graphics canvas)
        {
            canvas.FillEllipse(Brushes.Red,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

        public void DrawSquare(int x, int y, int size, Graphics canvas)
        {
            canvas.FillRectangle(Brushes.Red,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }
    }
}
