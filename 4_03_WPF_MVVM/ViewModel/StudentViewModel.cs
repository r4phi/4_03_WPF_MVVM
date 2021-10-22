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
    class StudentViewModel
    {
        #region properties
        public StudentModel Students { get; private set; } = new StudentModel();
        public Student Student { get; set; } = new Student();
        public String Name { get; set; } = string.Empty;
        public int Score { get; set; }
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
                Student.TimeAdded = DateTime.Now;
                Student.Comment = $"This Student was added at {Student.TimeAdded}";
                Students.Add(new Student
                {
                });
                Student.Reset();
            }, c => true);

            RemoveCommand = new RelayCommand(e =>
            {

            }, c => true);
        }
        #endregion

        #region commands
        public ICommand ExitCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        #endregion
    }
}
