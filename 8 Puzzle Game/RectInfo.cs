using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Game
{
    public class RectInfo
    {
        int i;
        int j;
        bool isFilled;

        public RectInfo(int i, int j, bool isFilled)
        {
            this.i = i;
            this.j = j;
            this.isFilled = isFilled;
        }

        public int I { get => i; set => i = value; }
        public int J { get => j; set => j = value; }
        public bool IsFilled { get => isFilled; set => isFilled = value; }
    }
}
