using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_21._06._2024_Events
{
    class GroupEnumerator : IEnumerator
    {
        public List<Student> students;
        public int position = -1;

        public GroupEnumerator(List<Student> students)
        {
            this.students = students;
        }

        object IEnumerator.Current
        {
            get
            {
                return students[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < students.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
