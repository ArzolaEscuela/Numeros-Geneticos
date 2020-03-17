using System;
using System.Drawing;

namespace Numeros_Geneticos
{
    public static class ChromosomeExtensions 
    {
        public static int GetIntFromChromosomeArray(this Chromosome[] chromosomes)
        {
            int total = 0;
            int index = 1;

            for (int i = chromosomes.Length - 1; i >= 0; i--)
            {
                if (chromosomes[i].Usable)
                {
                    total += index * 2;
                }
                index++;
            }

            return total;
        }
    }

    public class Chromosome : ICloneable
    {
        private readonly Individual _originalOwner;
        private bool _usable = false;

        public Color ChromosomeColor => _originalOwner.DrawColor;
        public bool Usable => _usable;

        public void ToggleUsable() => _usable = !_usable;

        public Chromosome(Individual originalOwner, bool usable = false)
        {
            _usable = usable;
            this._originalOwner = originalOwner;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString() => $"[Original Owner: {_originalOwner.Name}, Usable?: {_usable}]";
    }
}