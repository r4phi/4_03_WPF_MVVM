using _4_03_WPF_MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _4_03_WPF_MVVM.ViewModel
{
    class StudentViewModel : INotifyPropertyChanged
    {
        #region properties
        public StudentModel Students { get; private set; } = new StudentModel();
        private Student studentToAdd = new Student();
        public Student StudentToAdd
        {
            get => studentToAdd;
            set
            {
                studentToAdd = value;
                RaisePropertyChanged();
            }
        }
        public Student StudentToDelete { get; set; } = null;
        #endregion

        #region methods
        public StudentViewModel()
        { 
            ExitCommand = new RelayCommand(e =>
            {
                System.Environment.Exit(0);
            }, c => true);

            AddCommand = new RelayCommand(e =>
            {
                Students.Add(StudentToAdd);
                StudentToAdd = new Student();
            }, c => StudentToAdd.Name.Length != 0);

            RemoveCommand = new RelayCommand(e =>
            {
                Students.Remove(StudentToDelete);
            }, c => StudentToDelete != null);
        }
        #endregion

        #region commands
        public ICommand ExitCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
