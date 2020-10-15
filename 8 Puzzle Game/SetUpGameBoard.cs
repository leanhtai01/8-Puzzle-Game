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
        /// display original image (for reference)
        /// </summary>
        private void DisplayOriginalImage()
        {
            oriImg = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
            originalImage.Source = oriImg;
        } // end method DisplayOriginalImage

        /// <summary>
        /// shuffle pieces
        /// </summary>
        private void ShufflePieces()
        {
            bool isSolvable = false;

            while (!isSolvable)
            {
                Random rnd = new Random();
                int n = pieces.Count;

                while (n > 1)
                {
                    n--;
                    int k = rnd.Next(n + 1);
                    SwapPosition(pieces[n], pieces[k]);
                }

                isSolvable = IsSolvable();
            }
        } // end method ShufflePieces

        /// <summary>
        /// swap position of two image
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        private void SwapPosition(Image image1, Image image2)
        {
            var iTmp = (image1.Tag as PieceInfo).I;
            var jTmp = (image1.Tag as PieceInfo).J;

            (image1.Tag as PieceInfo).I = (image2.Tag as PieceInfo).I;
            (image1.Tag as PieceInfo).J = (image2.Tag as PieceInfo).J;
            (image2.Tag as PieceInfo).I = iTmp;
            (image2.Tag as PieceInfo).J = jTmp;
        } // end method SwapPosition

        /// <summary>
        /// get and remove missing piece
        /// </summary>
        private void GetAndRemoveMissingPiece()
        {
            missingPiece = pieces[0];
            pieces.RemoveAt(0);
            emptyRectName = "rectCanvas00";
        } // end method GetAndRemoveMissingPiece

        /// <summary>
        /// add pieces to game board
        /// </summary>
        private void AddPiecesToBoard()
        {
            boardCanvas.Children.Clear();
            MakePiecesContainer();

            // insert piece to right rectangle
            foreach (var piece in pieces)
            {
                InsertPieceToRect(piece);
            }
        } // end method AddPiecesToBoard

        /// <summary>
        /// insert piece to its corresponding rectangle (a canvas)
        /// </summary>
        /// <param name="piece"></param>
        private void InsertPieceToRect(Image piece)
        {
            var i = (piece.Tag as PieceInfo).I;
            var j = (piece.Tag as PieceInfo).J;
            var piecePosition = i.ToString() + j.ToString();
            var rectName = "rectCanvas" + piecePosition;
            var rectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, rectName) as Canvas;

            rectCanvas.Children.Add(piece);
            (rectCanvas.Tag as RectInfo).IsFilled = true;
        } // end method InsertPieceToRect

        /// <summary>
        /// make a container (canvas) for rectangles (canvas) contain images
        /// </summary>
        private void MakePiecesContainer()
        {
            double paddingWidth = 0.0;
            double paddingHeight = 0.0;

            piecesCanvas = new Canvas();
            boardCanvas.Children.Add(piecesCanvas);
            piecesCanvas.Width = pieceRelativeWidth * numberOfPieces + (numberOfPieces - 1) * gapSize;
            piecesCanvas.Height = pieceRelativeHeight * numberOfPieces + (numberOfPieces - 1) * gapSize;

            // center pieces
            paddingWidth = (boardCanvas.Width - piecesCanvas.Width) / 2;
            paddingHeight = (boardCanvas.Height - piecesCanvas.Height) / 2;
            Canvas.SetLeft(piecesCanvas, paddingWidth);
            Canvas.SetTop(piecesCanvas, paddingHeight);

            // make slot for pieces
            for (int i = 0; i < numberOfPieces; ++i)
            {
                for (int j = 0; j < numberOfPieces; ++j)
                {
                    Canvas rectCanvas = new Canvas();
                    var piecePosition = i.ToString() + j.ToString();

                    piecesCanvas.Children.Add(rectCanvas);
                    rectCanvas.Name = "rectCanvas" + piecePosition;
                    rectCanvas.Width = pieceRelativeWidth;
                    rectCanvas.Height = pieceRelativeHeight;
                    rectCanvas.Tag = new RectInfo(i, j, false);
                    Canvas.SetLeft(rectCanvas, i * (pieceRelativeWidth + gapSize));
                    Canvas.SetTop(rectCanvas, j * (pieceRelativeHeight + gapSize));
                }
            }
        } // end method MakePieceContainer
    }
}
