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
        private void SetCountdownTimer()
        {
            time = TimeSpan.FromSeconds(timeToPlay);

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                string s = time.ToString("c");

                realTimer.Content = s.Remove(0, 3);
                if (time == TimeSpan.Zero)
                {
                    SetupBoardAfterLost();
                    timer.Stop();
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
                timeToPlay--;
            }, Application.Current.Dispatcher);

            timer.Stop(); // make sure timer not run until user press play button
        }
    }
}
