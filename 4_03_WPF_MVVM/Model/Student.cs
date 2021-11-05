using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _4_03_WPF_MVVM.Model
{
    class Student : INotifyPropertyChanged
    {
        #region properties
        private string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private int score;
        public int Score
        {
            get => score;
            set
            {
                score = value;
                RaisePropertyChanged();
            }
        }

        private DateTime timeAdded;
        public DateTime TimeAdded
        {
            get => timeAdded;
            set
            {
                timeAdded = value;
                RaisePropertyChanged();
            }
        }

        //private string comment = string.Empty;
        //public string Comment
        //{
        //    get => comment;
        //    set
        //    {
        //        comment = value;
        //        RaisePropertyChanged();
        //    }
        //}
        public string Comment => $"This student was added at {TimeAdded}";
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region methods
        public override int GetHashCode()
        {
            unchecked
            {
                return Name.GetHashCode() * 3 + Score.GetHashCode() * 7;
            }
        }
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
                return false;

            if (Name != student.Name)
                return false;
            if (Score != student.Score)
                return false;
            if (TimeAdded != student.TimeAdded)
                return false;
            if (Comment != student.Comment)
                return false;

            return true;
        }
        #endregion
    }
}
