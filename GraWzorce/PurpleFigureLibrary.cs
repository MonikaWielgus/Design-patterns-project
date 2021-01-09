using System.Drawing;

namespace GraWzorce
{
    class PurpleFigureLibrary : IFigureLibrary
    {
        public void DrawCircle(int x, int y, int size, Graphics canvas)
        {
            canvas.FillEllipse(Brushes.Purple,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

        public void DrawSquare(int x, int y, int size, Graphics canvas)
        {
            canvas.FillRectangle(Brushes.Purple,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

    }
}
