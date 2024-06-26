using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_21._06._2024_Events
{
    public delegate void StudentEventHandler(int x);
    public delegate void StudEventHandler();
    public delegate void GroupEventHandler(Student student);
    public delegate void GroupEventHandlerChange(Student student, Group group);
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new();
            student.OversleptACouple += student.OversleptACoupleEv;
            student.OversleptACoupleEv();
            

            Student student1 = new("Evgeniya", "Sadova", new DateOnly(2001, 01, 01));
            student1.PassTheTest += student1.AddTestsRatings;
            student1.AddTestsRatings(11);
            student1.AddTestsRatings(11);
            student1.AddTestsRatings(11);
            student1.AddTestsRatings(11);
            student1.PrintRatings();

            Student student2 = new("Irina", "Strat", new DateOnly(2002, 02, 02));
            student2.PassTheCourseWork += student2.AddCourseWorksRatings;
            student2.AddCourseWorksRatings(12);
            student2.AddCourseWorksRatings(12);
            student2.AddCourseWorksRatings(12);
            student2.AddCourseWorksRatings(12);
            student2.PrintRatings();

            Student student3 = new("Liliya", "Khachatryan", new DateOnly(2003, 03, 03));
            student3.PassTheExam += student3.AddExamsRatings;
            student3.AddExamsRatings(12);
            student3.AddExamsRatings(12);
            student3.AddExamsRatings(12);
            student3.AddExamsRatings(12);
            student3.PrintRatings();

            Student student4 = new("Artem", "Karp", new DateOnly(2004, 04, 04));
            student4.PassTheTest += student4.AddTestsRatings;
            student4.PassTheCourseWork += student4.AddCourseWorksRatings;
            student4.PassTheExam += student4.AddExamsRatings;
            student4.AddTestsRatings(11);
            student4.AddCourseWorksRatings(12);
            student4.AddExamsRatings(12);
            student4.PrintRatings();

            Student student5 = new("Vitaly", "Ogorodnikov", new DateOnly(2006, 06, 06));

            student5.PassTheTest += student5.AddTestsRatings;
            student5.PassTheCourseWork += student5.AddCourseWorksRatings;
            student5.PassTheExam += student5.AddExamsRatings;

            student5.DroppedOut += student5.AddTestsRatings;
            student5.DroppedOut += student5.AddCourseWorksRatings;
            student5.DroppedOut += student5.AddExamsRatings;

            student5.AddTestsRatings(2);
            student5.AddCourseWorksRatings(2);
            student5.AddExamsRatings(2);
            student5.PrintRatings();

            Group group = new ();
            group.StudentAddInGroup += group.AddStudent;
            group.AddStudent(student);
            group.AddStudent(student1);
            group.AddStudent(student2);
            group.AddStudent(student3);
            group.AddStudent(student4);
            group.AddStudent(student5);
            
            group.StudentRemoveFromGroup += group.AddStudent;
            group.RemoveStudent(student5);

            Group group1 = new("PV415", "CyberSecurity");
            group.StudentChangeGroup += group.StudentTransfer;
            group.StudentTransfer(student, group1);

            /////////////////////////////////////////////////////////////////
            
            //void Test()
            //{
            //    if (OversleptACouple != null)
            //    {
            //        Console.WriteLine("TEST!\n");
            //    }
            //}
            //Test();

        }
    }
}
