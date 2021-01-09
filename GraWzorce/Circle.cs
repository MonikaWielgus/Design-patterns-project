using System.Drawing;

namespace GraWzorce
{
    public class Circle : Figure
    {
        public Circle() : base() { }
        public Circle(int x, int y, int size, IFigureLibrary fl) : base(x, y, size, fl) { }
        public override void Draw(Graphics can)
        {
            FLibrary.DrawCircle(X,Y,Size,can);
        }
        public override IPrototype Clone()
        {
            IPrototype result = new Circle(this.X, this.Y, this.Size, this.FLibrary);
            return result;
        }
    }
}
