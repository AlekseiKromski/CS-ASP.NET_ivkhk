using System;

namespace StudentApp
{
    class Program
    {
        class Student
        {
            //Var 1
            public string firstName;
            public string lastName;
            public string group;

            public void GetInfo()
            {
                Console.WriteLine($"\nStudent: {firstName} {lastName}, group: {group}");
            }

            public void student(string fn, string ln, string g)
            {
                this.firstName = fn;
                this.lastName = ln;
                this.group = g;
            }

        }

        static void Main(string[] args)
        {
            //New student object
            Student s1 = new Student();
            s1.firstName = "Aleksei";
            s1.lastName = "Kromski";
            s1.group = "JPTVR18";
            s1.GetInfo();

            //New student2 object
            Student s2 = new Student();
            s2.student("Aleskei2", "Kromski2", "JPTVR18");
            s2.GetInfo();

            Console.Write("Press any key ...");
            Console.ReadKey(); 
        }
    }
}
