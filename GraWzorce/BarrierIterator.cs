using System.Collections;
namespace GraWzorce
{
    abstract class BarrierIterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract bool MoveNext();

        public abstract void Reset();
        public abstract object Current();
    }
}
