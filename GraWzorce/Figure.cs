using System.Drawing;

namespace GraWzorce
{
    public abstract class Figure : IPrototype
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public IFigureLibrary FLibrary { get; set; }

        public Figure(){}
        public Figure(int x, int y, int size, IFigureLibrary fLibrary)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
            this.FLibrary = fLibrary;
        }
        public abstract void Draw(Graphics can);
        public abstract IPrototype Clone();
    }
}
