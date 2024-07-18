using System;
using System.Collections.Generic;

namespace CSC295HW3
{
    // Class representing a Student
    public class Student
    {
        // Properties
        public string Name { get; set; }
        private double gpa; // backing field for GPA

        // GPA property with validation
        public double GPA
        {
            get { return gpa; }
            set
            {
                // Validate GPA range (0 to 4)
                if (value < 0 || value > 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "GPA should be between 0 and 4.");
                }
                gpa = value; // Set GPA value if valid
            }
        }

        // Constructor
        public Student(string name, double gpa)
        {
            Name = name; // Initialize Name
            GPA = gpa;   // Initialize GPA (setter validates input)
        }

        // Override ToString() method to display student information
        public override string ToString()
        {
            return $"Student{{Name='{Name}', GPA={GPA}}}";
        }
    }

    // Static class containing sorting algorithms for Student objects
    public static class SortingAlgorithms
    {
        // Bubble sort algorithm to sort students by name (ascending)
        public static void BubbleSortByName(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Compare names of adjacent students
                    if (students[j].Name.CompareTo(students[j + 1].Name) > 0)
                    {
                        // Swap students if out of order by name
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                    // Secondary sort by GPA if names are equal
                    else if (students[j].Name.CompareTo(students[j + 1].Name) == 0 && students[j].GPA > students[j + 1].GPA)
                    {
                        // Swap students if out of order by GPA
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        // Selection sort algorithm to sort students by GPA (ascending)
        public static void SelectionSortByGPA(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare GPAs of students
                    if (students[j].GPA < students[minIndex].GPA)
                    {
                        minIndex = j; // Update minimum index if smaller GPA found
                    }
                    // Secondary sort by name if GPAs are equal
                    else if (students[j].GPA == students[minIndex].GPA && students[j].Name.CompareTo(students[minIndex].Name) < 0)
                    {
                        minIndex = j; // Update minimum index if alphabetical order by name needed
                    }
                }
                // Swap current minimum with current position
                var temp = students[minIndex];
                students[minIndex] = students[i];
                students[i] = temp;
            }
        }
    }

    // Main program class
    public class Program
    {
        // Main method where program execution begins
        static void Main(string[] args)
        {
            // List of students with initial data
            List<Student> students = new List<Student>
            {
                new Student("Alice", 3.5),
                new Student("Bob", 3.2),
                new Student("Charlie", 3.8),
                new Student("Jame", 3.5),
                new Student("Jack", 3.2),
                new Student("Jill", 3.0),
                // Uncomment the line below to see how exception is handled for invalid GPA
                // new Student("Sam", 4.9) // This will throw an ArgumentOutOfRangeException
            };

            // Infinite loop for user interaction
            while (true)
            {
                // Display menu options
                Console.WriteLine("Select a sorting algorithm:");
                Console.WriteLine("1. Bubble Sort by Name");
                Console.WriteLine("2. Selection Sort by GPA");
                Console.WriteLine("3. Exit");

                // Read user input
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    try
                    {
                        // Perform action based on user choice
                        switch (choice)
                        {
                            case 1:
                                SortingAlgorithms.BubbleSortByName(students); // Sort students by name
                                Console.WriteLine("Students sorted by name:");
                                PrintStudents(students); // Print sorted students
                                break;

                            case 2:
                                SortingAlgorithms.SelectionSortByGPA(students); // Sort students by GPA
                                Console.WriteLine("Students sorted by GPA:");
                                PrintStudents(students); // Print sorted students
                                break;

                            case 3:
                                Console.WriteLine("Exiting..."); // Exit the program
                                return;

                            default:
                                Console.WriteLine("Invalid choice. Please try again."); // Handle invalid input
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message); // Handle GPA validation exception
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number."); // Handle non-integer input
                    Console.ReadLine(); // Clear the input buffer
                }
            }
        }

        // Method to print list of students
        private static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student); // Output student information
            }
        }
    }
}
