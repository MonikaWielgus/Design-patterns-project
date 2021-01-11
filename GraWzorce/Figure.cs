using System.Drawing;

namespace GraWzorce
{
    public abstract class Figure : IPrototype
    {
        public int X;
        public int Y;
        public Details details;

        public Figure() { }
        public Figure(int x, int y, Details details)
        {
            this.X = x;
            this.Y = y;
            this.details = details;
        }
        public abstract void Draw(Graphics can);
        public abstract IPrototype Clone();
    }
}
