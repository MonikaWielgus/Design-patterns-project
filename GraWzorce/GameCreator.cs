namespace GraWzorce
{
    abstract class GameCreator
    {
        public abstract Game FactoryMethod();
        public void StartGame()
        {
            var product = FactoryMethod();
            product.StartGame();
        }
    }
}
