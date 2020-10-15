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
        private void MovePieceToLeftUsingNavigation()
        {
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, emptyRectName) as Canvas;

            if (currRectCanvas != null)
            {
                var i = (currRectCanvas.Tag as RectInfo).I;
                var j = (currRectCanvas.Tag as RectInfo).J;
                string rightRectName = "rectCanvas" + (i + 1) + j;
                var rightRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, rightRectName) as Canvas;

                if (rightRectCanvas != null && CanMoveLeft(i + 1, j))
                {
                    MovePieceToLeft(rightRectCanvas.Children[0] as Image, i + 1, j);
                }
            }
        }

        private void MovePieceToTopUsingNavigation()
        {
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, emptyRectName) as Canvas;

            if (currRectCanvas != null)
            {
                var i = (currRectCanvas.Tag as RectInfo).I;
                var j = (currRectCanvas.Tag as RectInfo).J;
                string bottomRectName = "rectCanvas" + i + (j + 1);
                var bottomRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, bottomRectName) as Canvas;

                if (bottomRectCanvas != null && CanMoveTop(i, j + 1))
                {
                    MovePieceToTop(bottomRectCanvas.Children[0] as Image, i, j + 1);
                }
            }
        }

        private void MovePieceToRightUsingNavigation()
        {
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, emptyRectName) as Canvas;

            if (currRectCanvas != null)
            {
                var i = (currRectCanvas.Tag as RectInfo).I;
                var j = (currRectCanvas.Tag as RectInfo).J;
                string leftRectName = "rectCanvas" + (i - 1) + j;
                var leftRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, leftRectName) as Canvas;

                if (leftRectCanvas != null && CanMoveRight(i - 1, j))
                {
                    MovePieceToRight(leftRectCanvas.Children[0] as Image, i - 1, j);
                }
            }
        }

        private void MovePieceToBottomUsingNavigation()
        {
            var currRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, emptyRectName) as Canvas;

            if (currRectCanvas != null)
            {
                var i = (currRectCanvas.Tag as RectInfo).I;
                var j = (currRectCanvas.Tag as RectInfo).J;
                string topRectName = "rectCanvas" + i + (j - 1);
                var topRectCanvas = LogicalTreeHelper.FindLogicalNode(piecesCanvas, topRectName) as Canvas;

                if (topRectCanvas != null && CanMoveBottom(i, j - 1))
                {
                    MovePieceToBottom(topRectCanvas.Children[0] as Image, i, j - 1);
                }
            }
        }
    }
}
