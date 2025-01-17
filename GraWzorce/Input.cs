﻿using System.Collections;
using System.Windows.Forms;

namespace GraWzorce
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable();
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }
        public static void PressKey(Keys key)
        {
            keyTable[key] = true;
        }
        public static void ReleaseKey(Keys key)
        {
            keyTable[key] = false;
        }
    }
}
