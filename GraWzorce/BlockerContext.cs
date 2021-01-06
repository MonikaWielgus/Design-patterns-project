
namespace GraWzorce
{
    class BlockerContext
    {
        private IBlockStrategy strategy;
        public void Set(IBlockStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Do(int i, int j, Barriers b)
        {
            strategy.BlockHere(i, j, b);
        }

    }
}
