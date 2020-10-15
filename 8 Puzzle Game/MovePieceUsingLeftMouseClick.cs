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
        /// move piece to corresponding position on left mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Piece_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isMoveable && !noImage)
            {
                var piece = sender as Image;
                var i = (piece.Tag as PieceInfo).I;
                var j = (piece.Tag as PieceInfo).J;

                if (CanMoveLeft(i, j))
                {
                    MovePieceToLeft(piece, i, j);
                }
                else if (CanMoveTop(i, j))
                {
                    MovePieceToTop(piece, i, j);
                }
                else if (CanMoveRight(i, j))
                {
                    MovePieceToRight(piece, i, j);
                }
                else if (CanMoveBottom(i, j))
                {
                    MovePieceToBottom(piece, i, j);
                }

                if (IsWon())
                {
                    SetupBoardAfterWon();
                }
            }
        } // end method Piece_MouseLeftButtonUp

        /// <summary>
        /// check whether current pieces can move to left
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool CanMoveLeft(int i, int j)
        {
            var rectName = "rectCanvas" + (i - 1) + j;
            var rectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, rectName) as Canvas;

            return rectCanvas != null && (rectCanvas.Tag as RectInfo).IsFilled != true;
        } // end method IsLeftEmpty

        /// <summary>
        ///  move piece to the left
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void MovePieceToLeft(Image piece, int i, int j)
        {
            var currRectName = "rectCanvas" + i + j;
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, currRectName) as Canvas;

            (piece.Tag as PieceInfo).I = i - 1;
            currRectCanvas.Children.Clear();
            (currRectCanvas.Tag as RectInfo).IsFilled = false;
            emptyRectName = currRectCanvas.Name; // keep track empty rect
            InsertPieceToRect(piece);
        } // end method MovePieceToLeft

        /// <summary>
        /// check whether piece can move to top
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool CanMoveTop(int i, int j)
        {
            var rectName = "rectCanvas" + i + (j - 1);
            var rectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, rectName) as Canvas;

            return rectCanvas != null && (rectCanvas.Tag as RectInfo).IsFilled != true;
        } // end method IsTopEmpty

        /// <summary>
        /// move piece to top
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void MovePieceToTop(Image piece, int i, int j)
        {
            var currRectName = "rectCanvas" + i + j;
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, currRectName) as Canvas;

            (piece.Tag as PieceInfo).J = j - 1;
            currRectCanvas.Children.Clear();
            (currRectCanvas.Tag as RectInfo).IsFilled = false;
            emptyRectName = currRectCanvas.Name; // keep track empty rect
            InsertPieceToRect(piece);
        } // end method MovePieceToTop

        /// <summary>
        /// check whether piece can move to right
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool CanMoveRight(int i, int j)
        {
            var rectName = "rectCanvas" + (i + 1) + j;
            var rectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, rectName) as Canvas;

            return rectCanvas != null && (rectCanvas.Tag as RectInfo).IsFilled != true;
        } // end method IsRightEmpty

        /// <summary>
        /// move piece to right
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void MovePieceToRight(Image piece, int i, int j)
        {
            var currRectName = "rectCanvas" + i + j;
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, currRectName) as Canvas;

            (piece.Tag as PieceInfo).I = i + 1;
            currRectCanvas.Children.Clear();
            (currRectCanvas.Tag as RectInfo).IsFilled = false;
            emptyRectName = currRectCanvas.Name; // keep track empty rect
            InsertPieceToRect(piece);
        } // end method MovePieceToRight

        /// <summary>
        /// check whether piece can move to bottom
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool CanMoveBottom(int i, int j)
        {
            var rectName = "rectCanvas" + i + (j + 1);
            var rectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, rectName) as Canvas;

            return rectCanvas != null && (rectCanvas.Tag as RectInfo).IsFilled != true;
        } // end method IsBottomEmpty

        /// <summary>
        /// move piece to bottom
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void MovePieceToBottom(Image piece, int i, int j)
        {
            var currRectName = "rectCanvas" + i + j;
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, currRectName) as Canvas;

            (piece.Tag as PieceInfo).J = j + 1;
            currRectCanvas.Children.Clear();
            (currRectCanvas.Tag as RectInfo).IsFilled = false;
            emptyRectName = currRectCanvas.Name; // keep track empty rect
            InsertPieceToRect(piece);
        } // end method MovePieceToBottom
    }
}
