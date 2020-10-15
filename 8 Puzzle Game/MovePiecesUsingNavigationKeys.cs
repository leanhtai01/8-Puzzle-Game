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
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMoveable)
            {
                if (e.Key == Key.Left)
                {
                    MovePieceToLeftUsingNavigation();
                }
                else if (e.Key == Key.Up)
                {
                    MovePieceToTopUsingNavigation();
                }
                else if (e.Key == Key.Right)
                {
                    MovePieceToRightUsingNavigation();
                }
                else if (e.Key == Key.Down)
                {
                    MovePieceToBottomUsingNavigation();
                }

                if (IsWon())
                {
                    SetupBoardAfterWon();
                }
            }
        }
    }
}
