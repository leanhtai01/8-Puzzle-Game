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
        private void ChangeButtonToPlay()
        {
            var playIcon = new BitmapImage(new Uri("Icons/play.ico", UriKind.Relative));

            playButton.Tag = "play";
            playImage.Source = playIcon;
        }

        private void ChangeButtonToPause()
        {
            var pauseIcon = new BitmapImage(new Uri("Icons/pause.ico", UriKind.Relative));

            playButton.Tag = "pause";
            playImage.Source = pauseIcon;
        }
    }
}
