using System.Windows.Forms;

namespace GraWzorce
{
    class ReleaseKey : ICommandInterface
    {
        public void Execute(Keys key)
        {
            Input.ReleaseKey(key);
        }
    }
}
