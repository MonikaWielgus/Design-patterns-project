using System.Drawing;

namespace GraWzorce
{
    public class Square : Figure
    {
        public Square() : base() { }
        public Square(int x, int y, int size, IFigureLibrary fl) : base(x, y, size, fl) { }

        public override void Draw(Graphics can)
        {
            FLibrary.DrawSquare(X,Y,Size,can);
        }
        public override IPrototype Clone()
        {
            IPrototype result = new Square(this.X,this.Y,this.Size,this.FLibrary);
            return result;
        }
    }
}
