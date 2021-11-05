using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_03_WPF_MVVM.Model
{
    class StudentModel
    {
        #region properties
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        #endregion

        #region methods
        public StudentModel()
        {
            // create some demo students
            Students.Add(new Student { Name = "Mike", Score = 80 });
            Students.Add(new Student { Name = "Alice", Score = 75 });
        }

        public void Add(Student studentToAdd)
        {
            if (studentToAdd == null) return;
            Students.Add(studentToAdd);
        }

        public void Remove(Student studentToDelete)
        {
            // ToDo, Student darf nur gelöscht werden, wenn er nicht null ist
            if (studentToDelete == null) return;
            Students.Remove(studentToDelete);
        }
        #endregion
    }
}
