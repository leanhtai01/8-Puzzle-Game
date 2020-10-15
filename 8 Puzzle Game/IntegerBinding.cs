using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Game
{
    public class IntegerBinding : INotifyPropertyChanged
    {
        private int integer;

        public IntegerBinding(int integer)
        {
            this.integer = integer;
        }

        public int Integer
        {
            get => integer; set
            {
                integer = value;
                NotifyPropertyChanged("Integer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
