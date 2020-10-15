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
        private void InitializeNoImage()
        {
            //numberOfMove.Integer = 0;
            filename = "Images/noimg.png";
            DisplayOriginalImage();
            CutImageIntoPieces();
            AddPiecesToBoard();
            ChangeButtonToPlay();
            noImage = true;
            realTimer.Content = TimeSpan.FromSeconds(timeToPlay).ToString("c").Remove(0, 3);
            SetCountdownTimer();
        }

        private void InitializeAddImage()
        {
            //numberOfMove.Integer = 0;
            timeToPlay = 600;
            realTimer.Content = TimeSpan.FromSeconds(timeToPlay).ToString("c").Remove(0, 3);
            time = TimeSpan.FromSeconds(timeToPlay);
            timer.Stop();
            DisplayOriginalImage();
            CutImageIntoPieces();
            GetAndRemoveMissingPiece();
            ShufflePieces();
            AddPiecesToBoard();
            UnhideBoard();
            HideBoard("Press Play to begin.");
            ChangeButtonToPlay();
            noImage = false;
            isMoveable = false;
        }
    }
}
