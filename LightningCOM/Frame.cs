using System;

namespace LightningCOM
{
    public class Frame
    {
        public Animations anims;
        public bool[] reles;
        public Frame(Animations anims)
        {
            this.anims = anims;
            reles = new bool[8];
            reles[7] = true; 
            
        }
        public void SetRele(int a)
        {
            reles[a] = !reles[a];
        }

            public void SetRele(int a,bool b)
        {
            reles[a] = b;
        }
       public byte ConvertBoolArrayToByte()
        {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            int index = 7;

            // Loop through the array
            foreach (bool b in reles)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index--;
            }

            return result;
        }
    }
}