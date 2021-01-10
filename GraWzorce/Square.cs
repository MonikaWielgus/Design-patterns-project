using System.Drawing;

namespace GraWzorce
{
    public class Square : Figure
    {
        public Square() : base() { }
        public Square(int x, int y, Details details) : base(x, y, details) { }

        public override void Draw(Graphics can)
        {
            details.GetIFigureLibrary().DrawSquare(X,Y,details.GetSize(),can);
        }
        public override IPrototype Clone()
        {
            IPrototype result = new Square(this.X,this.Y,this.details);
            return result;
        }
    }
}
