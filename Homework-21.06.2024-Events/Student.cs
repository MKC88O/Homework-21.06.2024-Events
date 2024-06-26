using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_21._06._2024_Events
{
    public class Student : IComparable<object>
    {
        protected string? name;
        protected string? lastName;
        protected string? patronymic;
        protected DateOnly dateOfBirth;
        protected string? homeAdres;
        protected string? phoneNumber;
        public List<int> tests = [];
        public List<int> courseWorks = [];
        public List<int> exams = [];
        protected string? speciality;

        public event StudentEventHandler? PassTheTest;
        public event StudentEventHandler? PassTheCourseWork;
        public event StudentEventHandler? PassTheExam;
        public event StudentEventHandler? DroppedOut;

        public event StudEventHandler? OversleptACouple;

        //////////////////////////            PROPERTIES            //////////////////////////////////////////////

        public string? Speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                speciality = value;
            }
        }

        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string? LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string? Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                patronymic = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public string? HomeAddress
        {
            get
            {
                return homeAdres;
            }
            set
            {
                homeAdres = value;
            }
        }

        public string? PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public Student() : this("Ivan", "Ivanovich", "Ivanov", new DateOnly(2000, 01, 01), "str.Bolharskaya, 87", "+38(068)1234567", "Software Developer") { }

        public Student(string? name, string? lastName) :
            this(name, "Patronymic", lastName, new DateOnly(2000, 01, 01), "Home Adres", "Phone Number", "Software Developer")
        { }

        public Student(string? name, string? patronymic, string? lastName) :
            this(name, lastName, patronymic, new DateOnly(2000, 01, 01), "Home Adres", "Phone Number", "Software Developer")
        { }

        public Student(string? name, string? lastName, DateOnly dateOfBirth) :
            this(name, "Patronymic", lastName, dateOfBirth, "Home Adres", "+38(068)1234567", "Software Developer")
        { }

        public Student(string? name, string? patronymic, string? lastName, DateOnly dateOfBirth, string? homeAdres, string? phoneNumber, string? speciality)
        {
            SetName(name);
            SetPatronymic(patronymic);
            SetLastName(lastName);
            SetDateOfBirth(dateOfBirth);
            SetHomeAdres(homeAdres);
            SetPhoneNumber(phoneNumber);
            SetSpeciality(speciality);
        }

        public void SetName(string? name)
        {
            this.name = name;
        }
        public void SetLastName(string? lastName)
        {
            this.lastName = lastName;
        }
        public void SetPatronymic(string? patronymic)
        {
            this.patronymic = patronymic;
        }
        public void SetDateOfBirth(DateOnly dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
        public void SetHomeAdres(string? homeAdres)
        {
            this.homeAdres = homeAdres;
        }
        public void SetPhoneNumber(string? phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SetSpeciality(string? speciality)
        {
            this.speciality = speciality;
        }
        public string? GetSpeciality()
        {
            return speciality;
        }

        public string? GetName()
        {
            return name;
        }
        public string? GetLastName()
        {
            return lastName;
        }
        public string? GetPatronymic()
        {
            return patronymic;
        }
        public DateOnly GetDateOfBirth()
        {
            return dateOfBirth;
        }
        public string? GetHomeAdres()
        {
            return homeAdres;
        }
        public string? GetPhoneNumber()
        {
            return phoneNumber;
        }

        public void OversleptACoupleEv()
        {
            if(OversleptACouple != null)
            {
                Console.WriteLine("Student " + name + " " + lastName + " overslept a couple\n");
            }
        }
        public override string ToString()
        {
            string? strings = "\tStudent Info: \n\n";
            strings += "Speciality: \t" + speciality + "\n";
            strings += "Name: \t\t" + name + "\n";
            strings += "Last name: \t" + lastName + "\n";
            strings += "Patronymic: \t" + patronymic + "\n";
            strings += "Date of birth: \t" + dateOfBirth + "\n";
            strings += "Home adres: \t" + homeAdres + "\n";
            strings += "Phone number: \t" + phoneNumber + "\n";
            strings += "Tests: \t\t";

            foreach (var test in tests)
            {
                strings += test + " ";
            }
            strings += " Average: " + tests.Average() + "\n";

            strings += "Course works: \t";
            foreach (var courseWork in courseWorks)
            {
                strings += courseWork + " ";
            }
            strings += " Average: " + courseWorks.Average() + "\n";

            strings += "Exams: \t\t";
            foreach (var exam in exams)
            {
                strings += exam + " ";
            }
            strings += " Average: " + exams.Average() + "\n";
            strings += "Total Average:  " + AverageRatings() + "\n";

            return strings;
        }

        public void PrintRatings()
        {
            Console.WriteLine("Student " + name + " " + lastName + ".");

            Console.Write("Tests: \t\t");
            foreach (var test in tests)
            {
                Console.Write(test + ", ");
            }
            Console.WriteLine();

            Console.Write("Course works: \t");
            foreach (var courseWork in courseWorks)
            {
                Console.Write(courseWork + ", ");
            }
            Console.WriteLine();

            Console.Write("Exams: \t\t");
            foreach (var exam in exams)
            {
                Console.Write(exam + ", ");
            }
            Console.WriteLine("\n");
        }

        public virtual void Study()
        {
            Console.WriteLine("Student " + name + " " + lastName + " studyes programming in C# language\n");
        }

        public virtual void TakeExam()
        {
            Console.WriteLine("Student " + name + " " + lastName + " passed the exams with " + exams.Average() + " points\n");
        }

        public void AddTestsRatings(int rating)
        {
            tests.Add(rating);
            if(PassTheTest != null)
            {
                Console.WriteLine("Student " + name + " " + lastName + " received " + rating + " points for test!\n");
            }
            if (DroppedOut != null && rating == 2)
            {
                Console.WriteLine("Student " + name + " " + lastName + " dropped out\n");
            }
        }

        public void AddCourseWorksRatings(int rating)
        {
            courseWorks.Add(rating);
            if (PassTheCourseWork != null)
            {
                Console.WriteLine("Student " + name + " " + lastName + " received " + rating + " points for course work!\n");
            }
            if (DroppedOut != null && rating == 2)
            {
                Console.WriteLine("Student " + name + " " + lastName + " dropped out\n");
            }
        }

        public void AddExamsRatings(int rating)
        {
            exams.Add(rating);
            if (PassTheExam != null)
            {
                Console.WriteLine("Student " + name + " " + lastName + " received " + rating + " points for exam!\n");
            }
            if(DroppedOut != null && rating == 2)
            {
                Console.WriteLine("Student " + name + " " + lastName + " dropped out\n");
            }
        }

        public void RemoveTestsRatings(int rating)
        {
            tests.Remove(rating);
        }

        public void RemoveCourseWorksRatings(int rating)
        {
            courseWorks.Remove(rating);
        }

        public void RemoveExamsRatings(int rating)
        {
            exams.Remove(rating);
        }

        public double AverageRatings()
        {

            if (tests.Count == 0 || courseWorks.Count == 0 || exams.Count == 0)
            {
                return 0;
            }

            double avg = (tests.Average() + courseWorks.Average() + exams.Average()) / 3;
            return Math.Round(avg, 2);
        }

        public int CompareTo(object? obj)
        {
            Student? stdnt = obj as Student;

            if (stdnt is null)
            {
                Console.WriteLine("Error!");
                return 0;
            }
            else
            {
                if (this.AverageRatings() > stdnt.AverageRatings())
                {
                    return 1;
                }
                if (this.AverageRatings() < stdnt.AverageRatings())
                {
                    return -1;
                }
                return 0;
            }
        }

        public class SortByName : IComparer
        {
            public int Compare(object? obj1, object? obj2)
            {
                Student? stud1 = (Student?)obj1;
                Student? stud2 = (Student?)obj2;
                return String.Compare(stud1?.Name, stud2?.Name);
            }
        }

        public class SortByLastName : IComparer
        {
            public int Compare(object? obj1, object? obj2)
            {
                Student? stud1 = (Student?)obj1;
                Student? stud2 = (Student?)obj2;
                return String.Compare(stud1?.LastName, stud2?.LastName);
            }
        }

        public class SortByDateOfBirth : IComparer
        {
            public int Compare(object? obj1, object? obj2)
            {
                Student? stud1 = (Student?)obj1;
                Student? stud2 = (Student?)obj2;

                if (stud1 is null || stud2 is null)
                {
                    Console.WriteLine("Error!");
                    return 0;
                }
                else
                {
                    return stud1.DateOfBirth.CompareTo(stud2.DateOfBirth);
                }
            }
        }

        public class SortByAvgRatings : IComparer
        {
            public int Compare(object? obj1, object? obj2)
            {
                Student? stud1 = (Student?)obj1;
                Student? stud2 = (Student?)obj2;

                if (stud1 is null || stud2 is null)
                {
                    Console.WriteLine("Error!");
                    return 0;
                }
                else
                {
                    double avg1 = stud1.AverageRatings();
                    double avg2 = stud2.AverageRatings();
                    return avg1.CompareTo(avg2);
                }
            }
        }

        //////////////////////////            OVERLOAD            //////////////////////////////////////////////

        public static bool operator <(Student left, Student right)
        {
            return left.AverageRatings() < right.AverageRatings();
        }

        public static bool operator >(Student left, Student right)
        {
            return !(left < right);
        }

        public static bool operator true(Student student)
        {
            return student.AverageRatings() >= 10;
        }

        public static bool operator false(Student student)
        {
            return student.AverageRatings() < 10;
        }

        public static bool operator ==(Student left, Student right)
        {
            return left.AverageRatings() == right.AverageRatings();
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student student)
            {
                return this == student;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return AverageRatings().GetHashCode();
        }

    }
}
