using System.Drawing;

namespace GraWzorce
{
    class GreenFigureLibrary : IFigureLibrary
    {
        public void DrawCircle(int x, int y, int size, Graphics canvas)
        {
            canvas.FillEllipse(Brushes.Green,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

        public void DrawSquare(int x, int y, int size, Graphics canvas)
        {
            canvas.FillRectangle(Brushes.Green,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }
    }
}
