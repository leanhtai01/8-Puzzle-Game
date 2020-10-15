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
        /// <summary>
        /// check whether user win the game
        /// </summary>
        /// <returns></returns>
        private bool IsWon()
        {
            foreach (var child in piecesCanvas.Children)
            {
                Canvas rectCanvas = child as Canvas;

                if ((rectCanvas.Tag as RectInfo).IsFilled == true)
                {
                    Image piece = rectCanvas.Children[0] as Image;
                    int i = (piece.Tag as PieceInfo).I;
                    int j = (piece.Tag as PieceInfo).J;
                    string currentPosition = i.ToString() + j.ToString();

                    if (currentPosition != (piece.Tag as PieceInfo).PiecePosition)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private async void SetupBoardAfterWon()
        {
            timer.Stop();
            ChangeButtonToPlay();
            noImage = true;
            HideBoard("Congratulation! You won!");
            InsertPieceToRect(missingPiece);
            await Task.Delay(3000);
            UnhideBoard();
        }

        private void SetupBoardAfterLost()
        {
            ChangeButtonToPlay();
            noImage = true;
            HideBoard("Timeout! Sorry! You lose!");
        }
    }
}
