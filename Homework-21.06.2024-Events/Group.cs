using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_21._06._2024_Events
{
    public class Group : IEnumerable
    {
        public List<Student> students = [];
        private string? nameOfGroup;
        private string? specializationOfGroup;
        private int numberOfCourse = 0;

        public event GroupEventHandler? StudentAddInGroup;
        public event GroupEventHandler? StudentRemoveFromGroup;
        public event GroupEventHandlerChange? StudentChangeGroup;

        //////////////////////////            PROPERTIES            //////////////////////////////////////////////

        public string? Name
        {
            get
            {
                return nameOfGroup;
            }
            set
            {
                nameOfGroup = value;
            }
        }

        public string? SpecializationOfGroup
        {
            get
            {
                return specializationOfGroup;
            }
            set
            {
                specializationOfGroup = value;
            }
        }

        public int NumberOfCourse
        {
            get
            {
                return numberOfCourse;
            }
            set
            {
                numberOfCourse = value;
            }
        }

        public Group() : this("PV312", "Software Development", 1) { }

        public Group(string? nameOfGroup, string? specializationOfGroup) : this(nameOfGroup, specializationOfGroup, 1) { }

        public Group(string? nameOfGroup, string? specializationOfGroup, int numberOfCourse)
        {
            SetNameOfGroup(nameOfGroup);
            SetSpecializationOfGroup(specializationOfGroup);
            SetNumberOfCourse(numberOfCourse);
        }
        public void SetNameOfGroup(string? nameOfGroup)
        {
            this.nameOfGroup = nameOfGroup;
        }

        public void SetSpecializationOfGroup(string? specializationOfGroup)
        {
            this.specializationOfGroup = specializationOfGroup;
        }

        public void SetNumberOfCourse(int numberOfCourse)
        {
            this.numberOfCourse = numberOfCourse;
        }

        public string? GetNameOfGroup()
        {
            return nameOfGroup;
        }

        public string? GetSpecializationOfGroup()
        {
            return specializationOfGroup;
        }

        public int GetNumberOfCourse()
        {
            return numberOfCourse;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            if(StudentAddInGroup != null)
            {
                Console.WriteLine("Student " + student.GetName() + " " + student.GetLastName() + " added to group " + nameOfGroup + "\n");
            }
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
            if (StudentRemoveFromGroup != null)
            {
                Console.WriteLine("Student " + student.GetName() + " " + student.GetLastName() + " removed from group " + nameOfGroup + "\n");
            }
        }

        public override string ToString()
        {
            string? strings = "\tGROUP:\n\n";
            strings += nameOfGroup + "\n" + specializationOfGroup + "\n";
            strings += "№" + "  Name:" + "\tLastname:\n";

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                strings += i + 1 + "  " + student.GetName() + " \t" + student.GetLastName() + "\n";
            }

            return strings;
        }
        
        public void StudentTransfer(Student student, Group newGroup)
        {
            RemoveStudent(student);
            newGroup.AddStudent(student);
            Console.WriteLine("Student " + student.GetName() + " " + student.GetLastName() + " was transferred to the group " + newGroup.GetNameOfGroup());
            Console.WriteLine();
            if (StudentChangeGroup != null)
            {
                Console.WriteLine("Student " + student.GetName() + " " + student.GetLastName() + " changed group from " + nameOfGroup + " to " + newGroup.nameOfGroup);
            }
        }

        public void EditingGroupData(string newName, string newSpecialization, int newNumber)
        {
            nameOfGroup = newName;
            specializationOfGroup = newSpecialization;
            numberOfCourse = newNumber;
        }

        public void RemoveMostUnderachieverStudent()
        {
            try
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("Group is empty.");
                    return;
                }

                var MostUnderachieverStudent = students[0];
                foreach (var student in students)
                {
                    if (student.AverageRatings() < MostUnderachieverStudent.AverageRatings())
                    {
                        MostUnderachieverStudent = student;
                    }
                }

                students.Remove(MostUnderachieverStudent);
                Console.WriteLine("Student " + MostUnderachieverStudent.GetName() + " " + MostUnderachieverStudent.GetLastName() + " removed from group " + nameOfGroup);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void Sort(List<Student> students, IComparer comparer)
        {
            students.Sort(comparer.Compare);
        }

        public Student? Search(string value)
        {
            foreach (var student in students)
            {
                if (student.Name == value || student.LastName == value)
                {
                    return student;
                }
            }
            return null;
        }

        public void SearchByName(string studentName)
        {
            if (studentName != null)
            {
                Student? searchByName = Search(studentName);
                Console.WriteLine("\nSearch result: ");

                if (searchByName is null)
                {
                    Console.WriteLine("Student " + studentName + " not found");
                }
                else
                {
                    Console.WriteLine(searchByName.Name + ", " + " Ratings: " + searchByName.AverageRatings());
                }
            }
            else
            {
                Console.WriteLine("ERROR! Student name is null!");
            }
        }

        public void SearchByLastName(string studentLastName)
        {
            if (studentLastName != null)
            {
                Student? searchByLastName = Search(studentLastName);
                Console.WriteLine("\nSearch result: ");

                if (searchByLastName is null)
                {
                    Console.WriteLine("Student " + studentLastName + " not found");
                }
                else
                {
                    Console.WriteLine(searchByLastName.LastName + ", " + " Ratings: " + searchByLastName.AverageRatings());
                }
            }
            else
            {
                Console.WriteLine("ERROR! Student name is null!");
            }
        }

        public void SearchMaxRating()
        {
            Student? topStudent = null;
            double maxRatings = 0;

            foreach (var student in students)
            {
                double average = student.AverageRatings();
                if (average > maxRatings)
                {
                    topStudent = student;
                    maxRatings = average;
                }
            }

            if (topStudent is null)
            {
                Console.WriteLine("ERROR!");
            }
            else
            {
                Console.WriteLine("\nSearch result: ");
                Console.WriteLine(topStudent.Name + " " + topStudent.LastName + ", " + topStudent.AverageRatings());
            }
        }

        public void SearchMinRating()
        {
            double minRatings = 12;
            Student? lowStudent = null;

            foreach (var student in students)
            {
                double average = student.AverageRatings();
                if (average < minRatings)
                {
                    minRatings = average;
                    lowStudent = student;
                }
            }

            if (lowStudent is null)
            {
                Console.WriteLine("ERROR!");
            }
            else
            {
                Console.WriteLine("\nSearch result: ");
                Console.WriteLine(lowStudent.Name + " " + lowStudent.LastName + ", " + lowStudent.AverageRatings());

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GroupEnumerator(students);
        }

        //////////////////////////            OVERLOAD            //////////////////////////////////////////////

        public Student this[int index]
        {
            get
            {
                if (index >= students.Count)
                {
                    throw new Exception("Error index");
                }
                return students[index];
            }
            set
            {
                if (index >= students.Count)
                {
                    throw new Exception("Error index");
                }
                students[index] = value;
            }
        }

        public static bool operator ==(Group left, Group right)
        {
            return left.students.Count == right.students.Count;
        }

        public static bool operator !=(Group left, Group right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Group group)
            {
                return this == group;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return students.Count;
        }
    }
}
