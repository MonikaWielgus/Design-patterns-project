using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
