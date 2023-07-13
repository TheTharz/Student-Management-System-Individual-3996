using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DesktopApplication.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public DateOnly BirthDay { get; set; }
        public BitmapImage? DisplayPicture { get; set; }
        public double GPA { get; set; }
        public string  ImageURL
        {
            get
            {
                return $"/Images/{DisplayPicture}";
            }
        }

        public Student(string? firstName, string? lastName, string? email, string? city, DateOnly birthDay, BitmapImage? displayPicture, double gPA)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            BirthDay = birthDay;
            DisplayPicture = displayPicture;
            GPA = gPA;
        }

        public Student()
        {
            
        }
    }
}
