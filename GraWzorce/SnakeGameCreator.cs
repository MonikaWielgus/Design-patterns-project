namespace GraWzorce
{
    class SnakeGameCreator : GameCreator
    {
        public override Game FactoryMethod()
        {
            return new Snake();
        }
    }
}
