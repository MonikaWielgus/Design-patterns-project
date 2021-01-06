namespace GraWzorce
{
    class ObstaclesGameCreator : GameCreator
    {
        public override Game FactoryMethod()
        {
            return new Obstacles();
        }
    }
}
