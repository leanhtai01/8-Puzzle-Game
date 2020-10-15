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
        /// cut original image into 9 pieces
        /// </summary>
        private void CutImageIntoPieces()
        {
            var pieceActualWidth = oriImg.PixelWidth / numberOfPieces;
            var pieceActualHeight = oriImg.PixelHeight / numberOfPieces;
            var widthRatio = boardCanvas.Width / numberOfPieces / pieceActualWidth;
            var heightRatio = boardCanvas.Height / numberOfPieces / pieceActualHeight;
            var ratio = pieceActualWidth > pieceActualHeight ? widthRatio : heightRatio;

            // calculate relative width, height of a piece
            pieceRelativeWidth = pieceActualWidth * ratio;
            pieceRelativeHeight = pieceActualHeight * ratio;

            pieces.Clear();
            for (var i = 0; i < numberOfPieces; ++i)
            {
                for (var j = 0; j < numberOfPieces; ++j)
                {
                    var cropped = new CroppedBitmap(oriImg, new Int32Rect(i * pieceActualWidth, j * pieceActualHeight, pieceActualWidth, pieceActualHeight));
                    var piece = new Image();
                    var piecePosition = i.ToString() + j.ToString();

                    piece.Source = cropped;
                    piece.Name = "piece" + piecePosition;
                    piece.Width = pieceRelativeWidth;
                    piece.Height = pieceRelativeHeight;
                    piece.Tag = new PieceInfo(i, j, piecePosition);
                    piece.MouseLeftButtonUp += Piece_MouseLeftButtonUp;

                    pieces.Add(piece);
                }
            }
        } // end method CutImageIntoPieces
    }
}
