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
        /// hide game board
        /// </summary>
        /// <param name="title"></param>
        private void HideBoard(string title)
        {
            TextBlock titleTextBlock = new TextBlock();

            // setup cover canvas
            coverCanvas = new Canvas();
            coverCanvas.Height = boardCanvas.Height + 12;
            coverCanvas.Width = boardCanvas.Width + 12;
            coverCanvas.Margin = boardCanvas.Margin;
            coverCanvas.HorizontalAlignment = HorizontalAlignment.Center;
            coverCanvas.VerticalAlignment = VerticalAlignment.Center;
            coverCanvas.Background = new SolidColorBrush(Colors.LightGray);
            leftGrid.Children.Add(coverCanvas);

            // setup title
            titleTextBlock.Text = title;
            titleTextBlock.FontSize = 30;
            titleTextBlock.FontWeight = FontWeights.Bold;
            coverCanvas.Children.Add(titleTextBlock);

            // center title
            titleTextBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Canvas.SetLeft(titleTextBlock, (coverCanvas.Width - titleTextBlock.DesiredSize.Width) / 2);
            Canvas.SetTop(titleTextBlock, (coverCanvas.Height - titleTextBlock.DesiredSize.Height) / 2);
        }

        /// <summary>
        /// unhide game board
        /// </summary>
        private void UnhideBoard()
        {
            leftGrid.Children.Remove(coverCanvas);
        }
    }
}
