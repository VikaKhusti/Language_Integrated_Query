﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        List<Student> students;
        List<Session> sessions;

        class Student
        {
            public int ID { get; set; }
            public string LastName { get; set; }
            public string Group { get; set; }
        }

        class Session
        {
            public int ID { get; set; }
            public string Subject { get; set; }
            public string FormOfControl { get; set; }
            public int Mark { get; set; }
            public DateTime Data { get; set; }
        }

        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student() {ID = 1, LastName = "Smith", Group = "A"},
                new Student() {ID = 2, LastName = "Taylor", Group = "A"},
                new Student() {ID = 3, LastName = "Thomas", Group = "B"},
                new Student() {ID = 4, LastName = "Jackson", Group = "A"},
                new Student() {ID = 5, LastName = "James", Group = "B"}
            };

            var sessions = new List<Session>()
            {
                //1
                new Session()
                {   ID = 1, Subject = "OOP", FormOfControl = "credit", Mark = 80, Data = new DateTime(2018, 05, 20)},
                new Session()
                {   ID = 1, Subject = "Math", FormOfControl = "exam", Mark = 75, Data = new DateTime(2018, 05, 23)},
                new Session()
                {   ID = 2, Subject = "Programming", FormOfControl = "credit",  Mark = 45, Data = new DateTime(2018, 05, 25)},

                //2
                new Session()
                {   ID = 2, Subject = "OOP", FormOfControl = "credit", Mark = 60, Data = new DateTime(2018, 05, 20)},
                new Session()
                {   ID = 2, Subject = "Math", FormOfControl = "exam", Mark = 55, Data = new DateTime(2018, 05, 23)},

                //3
                new Session()
                {   ID = 3, Subject = "Proramming", FormOfControl = "credit", Mark = 35, Data = new DateTime(2018, 05, 25)},

                //4
                new Session()
                {   ID = 4, Subject = "OOP", FormOfControl = "credit", Mark = 95, Data = new DateTime(2018, 05, 20)},
                new Session()
                {   ID = 4, Subject = "Math", FormOfControl = "exam", Mark = 90, Data = new DateTime(2018, 05, 23)},
                new Session()
                {   ID = 4, Subject = "Programming", FormOfControl = "credit", Mark = 90, Data = new DateTime(2018, 05, 25)},

                //5
                new Session()
                {   ID = 5, Subject = "OOP", FormOfControl = "credit", Mark = 60, Data = new DateTime(2018, 05, 20)},
                new Session()
                {   ID = 5, Subject = "Math", FormOfControl = "exam", Mark = 75, Data = new DateTime(2018, 05, 23)},
                new Session()
                {   ID = 5, Subject = "Programming", FormOfControl = "credit", Mark = 70, Data = new DateTime(2018, 05, 25)},
            };

            //Console.WriteLine("Enter a letter: ");
            //string letter = Console.ReadLine();
            //letter = letter.ToUpper();
            //var query1 = from student in students
            //             where student.LastName.StartsWith(letter)
            //             select student.ID;
            //foreach (var student in query1)
            //{
            //    Console.WriteLine(student);
            //}

            var query2 = from session in sessions
                         where session.Mark < 60
                         group session by session.ID into temp
                         where temp.Count() < 2
                         orderby temp.Key
                         select temp;
            //PrintCollection(query2);

            var query3 = from student in students
                         from session in sessions
                         where student.Group == "A" && session.ID == student.ID
                         select student.ID;
            
            //PrintCollection(query3);
            var query4 = from student in students
                         from session in sessions
                         where session.ID == student.ID
                         group session.Mark by session.ID into mark
                         select new { ID = mark.Key, sum = mark.Sum() / 3 };
            //select mark.Sum() / 3;
            var query5 = from s in students
                         from q in query4
                         where s.ID == q.ID
                         orderby q.sum descending
                         select new { Name = s.LastName, Mark = q.sum };
            //var query6 = from q in query5
            //             orderby q.su
            PrintCollection(query4);
            PrintCollection(query5);
            
            


        }
        static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }
    }
}