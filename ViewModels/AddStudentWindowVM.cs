using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApplication.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DesktopApplication.ViewModels
{
    public partial class AddStudentWindowVM: ObservableObject
    {
        [ObservableProperty]
        public string fname;

        [ObservableProperty]
        public string lname;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public DateOnly bday;

        [ObservableProperty]
        public BitmapImage dp;

        [ObservableProperty]
        public string city;

        public Student Student { get; private set; }
        public Action CloseAction { get; internal set; }

        public AddStudentWindowVM()
        {
            
        }

        public AddStudentWindowVM(Student student)
        {
            Student = student;

            fname = Student.FirstName;
            lname = Student.LastName;
            email = Student.Email;
            gpa = Student.GPA;
            bday = Student.BirthDay;
            dp = Student.DisplayPicture;
            city = Student.City;
        }

        [RelayCommand]
        public void SelectDP()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files | *.bmp;*.png;*.jpg";
            openFileDialog.FilterIndex = 1;
            if(openFileDialog.ShowDialog() == true)
            {
                dp = new BitmapImage(new Uri(openFileDialog.FileName));

                MessageBox.Show("Profile Picture Succesfully Uploaded", "Uploaded", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        [RelayCommand]
        public void SaveChanges()
        {
            if(gpa<0 || gpa>4)
            {
                MessageBox.Show("GPA should be a value between 0 and 4","ERROR!",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(Student==null)
            {
                Student = new Student()
                {
                    FirstName = fname,
                    LastName = lname,
                    Email = email,
                    GPA = gpa,
                    DisplayPicture = dp,
                    City = city,
                    BirthDay = bday,
                };
            }
            else
            {
                Student.FirstName = fname;
                Student.LastName = lname;
                Student.Email = email;
                Student.GPA = gpa;
                Student.DisplayPicture = dp;
                Student.City = city;
                Student.BirthDay = bday;

            }
            if(Student.FirstName!= null)
            {
                //shutting down the application
                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
