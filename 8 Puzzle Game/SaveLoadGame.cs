using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!noImage)
            {
                UnhideBoard();
                PauseAction("Game saved. Press Play to unpause.");
                var writer = new StreamWriter("data.dat");

                writer.WriteLine(filename);
                writer.WriteLine(timeToPlay);
                foreach (var piece in pieces)
                {
                    string infoPiece = (piece.Tag as PieceInfo).I.ToString()
                        + ' ' + (piece.Tag as PieceInfo).J.ToString()
                        + ' ' + (piece.Tag as PieceInfo).PiecePosition;
                    writer.WriteLine(infoPiece);
                }

                writer.Close();
            }
        }

        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            pieces.Clear();
            if (File.Exists("data.dat"))
            {
                using (StreamReader sr = new StreamReader("data.dat"))
                {
                    filename = sr.ReadLine();
                    if (File.Exists(filename))
                    {
                        UnhideBoard();
                        PauseAction("Game load successfully!\nPress Play to begin!");

                        timeToPlay = Int32.Parse(sr.ReadLine());
                        DisplayOriginalImage();
                        CutImageIntoPieces();
                        GetAndRemoveMissingPiece();

                        for (int i = 0; i < pieces.Count; ++i)
                        {
                            string[] info = sr.ReadLine().Split(' ');

                            (pieces[i].Tag as PieceInfo).I = Int32.Parse(info[0]);
                            (pieces[i].Tag as PieceInfo).J = Int32.Parse(info[1]);
                        }

                        realTimer.Content = TimeSpan.FromSeconds(timeToPlay).ToString("c").Remove(0, 3);
                        time = TimeSpan.FromSeconds(timeToPlay);
                        timer.Stop();
                        AddPiecesToBoard();
                        noImage = false;
                        isMoveable = false;
                    }
                    else
                    {
                        UnhideBoard();
                        PauseAction("Image file doesn't exist!");
                        await Task.Delay(2000);

                        if (!noImage)
                        {
                            UnhideBoard();
                            PauseAction("Press Play to continue.");
                        }
                        else
                        {
                            UnhideBoard();
                            InitializeNoImage();
                        }
                    }

                    sr.Close();
                }
            }
            else
            {
                UnhideBoard();
                PauseAction("Sorry! There are no save file!");
                await Task.Delay(2000);

                if (!noImage)
                {
                    UnhideBoard();
                    PauseAction("Press Play to continue.");
                }
                else
                {
                    UnhideBoard();
                    InitializeNoImage();
                }
            }
        }
    }
}
