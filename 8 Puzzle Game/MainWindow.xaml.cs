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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeNoImage();
        }

        /// <summary>
        /// add new image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // choose file
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico";

            if (ofd.ShowDialog() == true)
            {
                // get image's path
                filename = ofd.FileName;

                InitializeAddImage();
            }
        }

        /// <summary>
        /// start/pause game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!noImage)
            {
                switch (playButton.Tag)
                {
                    case "play":
                        PlayAction();
                        break;

                    case "pause":
                        PauseAction("Press Play to unpause.");
                        break;
                }
            }
        } // end method PlayButton_Click
    }
}
