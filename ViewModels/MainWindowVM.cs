using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApplication.Models;
using DesktopApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DesktopApplication.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent;


        //command for adding new students in the objects
        [RelayCommand]
        public void AddNewStudents()
        {
            var viewmodel = new AddStudentWindowVM();
            AddStudentWindow nw = new AddStudentWindow(viewmodel);
            nw.ShowDialog();

            if (viewmodel.Student.FirstName != null)
            {
                students.Add(viewmodel.Student);
            }
        }

        //command for updating details of the students
        [RelayCommand]
        public void UpdateDetails()
        {
            if(selectedStudent!=null)
            {
                var newViewModel = new AddStudentWindowVM(selectedStudent);
                var nWindow = new AddStudentWindow(newViewModel);
                
                nWindow.ShowDialog();

                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, newViewModel.Student);
            }
            else
            {
                MessageBox.Show("Please Select a Student To Update Details", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //command for deleting the students from the table
        [RelayCommand]
        public void DeleteStudent()
        {
            if(selectedStudent!=null)
            {
                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Please Select The Student To Delete From The System","Warning!",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //command for back from the window currently logged
        [RelayCommand]
        public void Exit()
        {
            Application.Current.Shutdown();
        }


        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();

            string dateString = "2023-04-15";
            DateOnly dateTime;
            DateOnly.TryParse(dateString, out dateTime);

            BitmapImage demo = new BitmapImage(new Uri("/Images/1.png",UriKind.Relative));

            //sample for the testing purpose
            students.Add(new Student("Tharindu","Imalka","tharindtcc","horana",dateTime,demo,3.5));
            students.Add(new Student("Tharindu", "Imalka", "tharindtcc", "horana", dateTime, demo, 3.5));
            students.Add(new Student("Tharindu", "Imalka", "tharindtcc", "horana", dateTime, demo, 3.5));
            students.Add(new Student("Tharindu", "Imalka", "tharindtcc", "horana", dateTime, demo, 3.5));
        }
    }
}