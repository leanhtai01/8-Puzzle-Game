using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Game
{
    public class PieceInfo
    {
        int i;
        int j;
        string piecePosition;

        public PieceInfo(int i, int j, string piecePosition)
        {
            this.i = i;
            this.j = j;
            this.piecePosition = piecePosition;
        }

        public int I { get => i; set => i = value; }
        public int J { get => j; set => j = value; }
        public string PiecePosition { get => piecePosition; set => piecePosition = value; }
    }
}
