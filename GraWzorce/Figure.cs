using System.Drawing;

namespace GraWzorce
{
    public abstract class Figure : IPrototype
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Details details;
        //public int Size { get; set; }
        //public IFigureLibrary FLibrary { get; set; }

        public Figure() { }
        public Figure(int x, int y, Details details)
        {
            this.X = x;
            this.Y = y;
            this.details = details;
            //this.Size = size;
            //this.FLibrary = fLibrary;
        }
        public abstract void Draw(Graphics can);
        public int getSize()
        {
            return details.GetSize();
        }
        public IFigureLibrary GetIFigureLibrary()
        {
            return details.GetIFigureLibrary();
        }

        public abstract IPrototype Clone();
    }
}
