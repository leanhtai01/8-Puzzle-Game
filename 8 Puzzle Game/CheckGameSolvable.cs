using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace _8_Puzzle_Game
{
    public partial class MainWindow : Window
    {
        private int CountInversions()
        {
            int count = 0;

            for (int i = 0; i < pieces.Count - 1; ++i)
            {
                for (int j = i + 1; j < pieces.Count; ++j)
                {
                    int position_i = Int32.Parse((pieces[i].Tag as PieceInfo).PiecePosition);
                    int position_j = Int32.Parse((pieces[j].Tag as PieceInfo).PiecePosition);

                    if (position_i > position_j)
                    {
                        ++count;
                    }
                }
            }

            return count;
        }

        private bool IsSolvable()
        {
            return CountInversions() % 2 == 0;
        }
    }
}
