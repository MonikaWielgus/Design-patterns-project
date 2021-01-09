using System.Drawing;

namespace GraWzorce
{
    class PinkFigureLibrary : IFigureLibrary
    {
        public void DrawCircle(int x, int y, int size, Graphics canvas)
        {
            canvas.FillEllipse(Brushes.LightPink,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }

        public void DrawSquare(int x, int y, int size, Graphics canvas)
        {
            canvas.FillRectangle(Brushes.LightPink,
                            new Rectangle(x * size,
                            y * size, size,
                            size));
        }
    }
}
