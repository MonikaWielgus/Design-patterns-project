using System.Windows.Forms;

namespace GraWzorce
{
    class PressKey : ICommandInterface
    {
        public void Execute(Keys key)
        {
            Input.PressKey(key);
        }

    }
}
