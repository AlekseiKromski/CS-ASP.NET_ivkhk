using System;

namespace StudentApp2
{
    
    class Program
    {
        class Student
        {
            //-- OPCIONAL --
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string group { get; set; }

            private int course;
            public int Course
            {
                get { return course; }
                set
                {
                    if (value >= 1 && value <= 5)
                    {
                        course = value;
                    }
                }
            }

            public string gender()
            {
                if(id[0] == '3' || id[0] == '5')
                {
                    return "male";
                }
                else
                {
                    return "female";
                }
            }

            public override String ToString()
            {
                string str = $"Student: {firstName} {lastName}, Group: {group}, Gender: {gender()}, Course: {Course}";
                return str;
            }

        }

        static void Main(string[] args)
        {
            Student s = new Student();
            s.firstName = "Aleksei";
            s.lastName = "Krosmki";
            s.id = "50208302215";
            s.group = "JPTVR18";
            s.Course = 3;

            Console.WriteLine(s.ToString());
            Console.ReadKey();
        }
    }
}
