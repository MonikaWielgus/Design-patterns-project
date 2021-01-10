using System.Drawing;

namespace GraWzorce
{
    public class Circle : Figure
    {
        public Circle() : base() { }
        public Circle(int x, int y, Details details) : base(x, y, details) { }
        public override void Draw(Graphics can)
        {
            details.GetIFigureLibrary().DrawCircle(X,Y,details.GetSize(),can);
        }
        public override IPrototype Clone()
        {
            IPrototype result = new Circle(this.X, this.Y, this.details);
            return result;
        }
    }
}
