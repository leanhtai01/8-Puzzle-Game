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
using System.Windows.Threading;

namespace _8_Puzzle_Game
{
    public partial class MainWindow : Window
    {
        private string filename; // image use to play
        private BitmapImage oriImg; // original image for reference
        private List<Image> pieces = new List<Image>(); // contain pieces of image after cut
        private Image missingPiece; // save removed pieces
        private string emptyRectName = " "; // name of empty rectangle
        private Canvas piecesCanvas; // contain rectangles
        private Canvas coverCanvas; // cover the board
        private int gapSize = 2; // gap between pieces
        private int numberOfPieces = 3; // square root of number of pieces
        private double pieceRelativeWidth; // relative width of a piece
        private double pieceRelativeHeight; // relative height of a pieces
        private bool noImage = true; // is something in the board?
        private bool isMoveable = false; // is the play button pressed?
        private DispatcherTimer timer;
        private TimeSpan time;
        private int timeToPlay = 600;
        //private IntegerBinding numberOfMove = new IntegerBinding(0);
    }
}
