using System;
using System.Collections;
using System.Collections.Generic;

namespace GraWzorce
{
    class TrueBarrierIterator : BarrierIterator
    {
        private Dictionary<int, bool> Values;
        ArrayList Keys;
        private int Position=0;

        public TrueBarrierIterator(Dictionary<int, bool> values)
        {
            this.Values = values;
            Keys = new ArrayList(Values.Keys);
        }

        public override object Current()
        {
            return Keys[Position];
        }

        public override bool MoveNext()
        {           
            bool value=false;
            int updatedPosition = this.Position;
            do
            {   updatedPosition += 1;
                if (updatedPosition >= Keys.Count)
                    return false;
                Values.TryGetValue((int)Keys[updatedPosition], out value);
            } while (value == false);
            this.Position = updatedPosition;
            return true;
        }

        public override void Reset()
        {
            this.Position=0;
        }
    }
}
