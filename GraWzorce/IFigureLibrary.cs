using System.Drawing;

namespace GraWzorce
{
    public interface IFigureLibrary
    {
        void DrawCircle(int x, int y, int size, Graphics canvas);
        void DrawSquare(int x, int y, int size, Graphics canvas);
    }
}
