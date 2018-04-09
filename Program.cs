using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CornerstoneAssessment
{
    public class Program
    {
        static List<Person> _peopleList = new List<Person>();

        private static void Main(string[] args)
        {
            LoadJson();
        }
        //Reads data from json file into a PersonList object. Calls methods to display info from PersonList
        public static void LoadJson()
        {
            using (var r = new StreamReader(@"code_test.json"))
            {
                var json = r.ReadToEnd();
                _peopleList = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            ListOfPeople();
            CountOfPeople();
            ListMenBlueEyes();
            CountMenBlueEyes();
            CountFriends();
        }
        //Lists all the people from the PersonList object. Lists an ordered list of all people by age from oldest to youngest
        public static void ListOfPeople()
        {
            Console.WriteLine("Display all the people:");
            Console.ReadLine();

            foreach (var p in _peopleList)
            {
                Console.WriteLine("{0} | {1}, {2} | {3} | {4}", p.Age, p.LastName, p.FirstName, p.EyeColor, p.Gender);
            }

            Console.WriteLine("\nDisplay all the people order by age (oldest to youngest)");
            Console.ReadLine();

            var orderedAge = _peopleList.OrderByDescending(o => o.Age).ToList();
            foreach (var p in orderedAge)
            {
                Console.WriteLine("{0}, {1}, {2}", p.Age, p.LastName, p.FirstName);
            }
            Console.ReadLine();
        }
        //Displays a count of the total number of people in the PeopleList object
        public static void CountOfPeople()
        {
            Console.WriteLine("\nCount of total number of people: ");
            Console.ReadLine();

            Console.WriteLine(_peopleList.Count);
            Console.ReadLine();
        }
        //Lists active men with blue eyes over the age of 30 from the PeopleList object. Lists an ordered list of active men with blue eyes over the age of 30 by age from oldest to youngest
        public static void ListMenBlueEyes()
        {
            Console.WriteLine("Display active men with blue eyes over the age of 30:");
            Console.ReadLine();

            foreach (var p in _peopleList)
            {
                if ((p.EyeColor == "blue") && (p.Gender == "male") && (p.IsActive) && p.Age > 30)
                {
                    Console.WriteLine("{0} | {1}, {2} | {3} | {4}", p.Age, p.LastName, p.FirstName, p.EyeColor, p.Gender);
                }
            }

            Console.WriteLine("\nDisplay active men with blue eyes over the age of 30 order by age (oldest to youngest)");
            Console.ReadLine();

            var orderedAge = _peopleList.OrderByDescending(o => o.Age).ToList();
            foreach (var p in orderedAge)
            {
                if ((p.EyeColor == "blue") && (p.Gender == "male") && (p.IsActive) && p.Age > 30)
                {
                    Console.WriteLine("{0}, {1}, {2}", p.Age, p.LastName, p.FirstName);
                }
            }
            Console.ReadLine();
        }
        //Displays a count of total active men with blue eyes over the age of 30
        public static void CountMenBlueEyes()
        {
            Console.WriteLine("Display count of total active men with blue eyes over the age of 30: ");
            Console.ReadLine();

            var countActiveBlueEyedMen = _peopleList.Where(p => (p.EyeColor == "blue") && (p.Gender == "male") && (p.IsActive) && p.Age > 30).ToList();
            Console.WriteLine(countActiveBlueEyedMen.Count);
            Console.ReadLine();

        }
        //Displays a count of total number of people with less than 3 friends 
        public static void CountFriends()
        {
            Console.WriteLine("Display the number of people with less than 3 friends: ");
            Console.ReadLine();

            var countFriendsLessThanThree = _peopleList.Where(p => (p.Friends.Count < 3)).ToList();
            Console.WriteLine(countFriendsLessThanThree.Count);
            Console.ReadLine();
        }
    }
}
