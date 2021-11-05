﻿using _4_03_WPF_MVVM.Model;
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
                Console.WriteLine(Student);
                Students.Remove(Student);
            }, c => true);

            AddCommand = new RelayCommand(e =>
            {
                Students.Add(new Student
                {
                    Name = Name,
                    Score = Score,
                    Comment = $"This Student was added at {DateTime.Now}",
                    TimeAdded = DateTime.Now
                });
                Name = string.Empty;
                Score = 0;
            }, c => true);

            RemoveCommand = new RelayCommand(e =>
            {
                Students.Remove(Student);
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
