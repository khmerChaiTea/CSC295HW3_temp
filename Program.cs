using System;
using System.Collections.Generic;

namespace CSC295HW3
{
    // Class representing a Student
    public class Student
    {
        // Properties to store the name and GPA of a student
        public string Name { get; set; }
        public double GPA { get; set; }

        // Constructor to initialize a student with a name and GPA
        public Student(string name, double gpa)
        {
            Name = name;
            GPA = gpa;
        }

        // Override ToString method to display student information
        public override string ToString()
        {
            return $"Student{{Name='{Name}', GPA={GPA}}}";
        }

        // Main method where the program execution begins
        static void Main(string[] args)
        {
            // List of students for demonstration
            List<Student> students = new List<Student>
            {
                new Student("Alice", 3.5),
                new Student("Bob", 3.2),
                new Student("Charlie", 3.8)
            };

            // Infinite loop to display the menu until the user chooses to exit
            while (true)
            {
                Console.WriteLine("Select a sorting algorithm:");
                Console.WriteLine("1. Bubble Sort by Name");
                Console.WriteLine("2. Selection Sort by GPA");
                Console.WriteLine("3. Exit");

                // Read the user's choice
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    // Perform action based on user's choice
                    switch (choice)
                    {
                        case 1:
                            // Sort students by name using Bubble Sort
                            SortingAlgorithms.BubbleSortByName(students);
                            Console.WriteLine("Students sorted by name:");
                            PrintStudents(students);
                            break;

                        case 2:
                            // Sort students by GPA using Selection Sort
                            SortingAlgorithms.SelectionSortByGPA(students);
                            Console.WriteLine("Students sorted by GPA:");
                            PrintStudents(students);
                            break;

                        case 3:
                            // Exit the program
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            // Handle invalid choices
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    // Handle invalid input that is not a number
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        // Method to print the list of students
        private static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    // Class containing sorting algorithms
    public static class SortingAlgorithms
    {
        // Bubble Sort algorithm to sort students by name
        public static void BubbleSortByName(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (students[j].Name.CompareTo(students[j + 1].Name) > 0)
                    {
                        // Swap students[j] and students[j + 1]
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        // Selection Sort algorithm to sort students by GPA
        public static void SelectionSortByGPA(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (students[j].GPA < students[minIndex].GPA)
                    {
                        minIndex = j;
                    }
                }
                // Swap students[minIndex] and students[i]
                var temp = students[minIndex];
                students[minIndex] = students[i];
                students[i] = temp;
            }
        }
    }
}
