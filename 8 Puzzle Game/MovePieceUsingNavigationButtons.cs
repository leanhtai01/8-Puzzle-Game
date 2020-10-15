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
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMoveable)
            {
                MovePieceToLeftUsingNavigation();

                if (IsWon())
                {
                    SetupBoardAfterWon();
                }
            }
        } // end method LeftButton_Click

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMoveable)
            {
                MovePieceToTopUsingNavigation();

                if (IsWon())
                {
                    SetupBoardAfterWon();
                }
            }
        } // end method UpButton_Click

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMoveable)
            {
                MovePieceToRightUsingNavigation();

                if (IsWon())
                {
                    SetupBoardAfterWon();
                }
            }
        } // end method RightButton_Click

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMoveable)
            {
                MovePieceToBottomUsingNavigation();

                if (IsWon())
                {
                    SetupBoardAfterWon();
                }
            }
        } // end method DownButton_Click
    }
}
