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
                Console.WriteLine();    // Added a line to separate the first output and the menu
                Console.WriteLine("Select a sorting algorithm:");
                Console.WriteLine("1. Bubble Sort by GPA (Descending)");
                Console.WriteLine("2. Selection Sort by GPA (Descending)");
                Console.WriteLine("3. Insertion Sort by GPA (Descending)");
                Console.WriteLine("4. Merge Sort by GPA (Descending)");
                Console.WriteLine("5. Exit");

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
                                SortingAlgorithms.BubbleSortByGPADescending(students); // Sort students by GPA descending using Bubble Sort
                                Console.WriteLine("Students sorted by GPA (descending) using Bubble Sort:");
                                PrintStudents(students); // Print sorted students
                                break;

                            case 2:
                                SortingAlgorithms.SelectionSortByGPADescending(students); // Sort students by GPA descending using Selection Sort
                                Console.WriteLine("Students sorted by GPA (descending) using Selection Sort:");
                                PrintStudents(students); // Print sorted students
                                break;

                            case 3:
                                SortingAlgorithms.InsertionSortByGPADescending(students); // Sort students by GPA descending using Insertion Sort
                                Console.WriteLine("Students sorted by GPA (descending) using Insertion Sort:");
                                PrintStudents(students); // Print sorted students
                                break;

                            case 4:
                                SortingAlgorithms.MergeSortByGPADescending(students); // Sort students by GPA descending using Merge Sort
                                Console.WriteLine("Students sorted by GPA (descending) using Merge Sort:");
                                PrintStudents(students); // Print sorted students
                                break;

                            case 5:
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

    // Static class containing sorting algorithms for Student objects
    public static class SortingAlgorithms
    {
        // Bubble sort algorithm to sort students by GPA (descending), name (ascending)
        public static void BubbleSortByGPADescending(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Compare GPAs of adjacent students
                    if (students[j].GPA < students[j + 1].GPA)
                    {
                        // Swap students if out of order by GPA
                        Swap(students, j, j + 1);
                    }
                    else if (students[j].GPA == students[j + 1].GPA)
                    {
                        // If GPA is the same, compare names (ascending order)
                        if (string.Compare(students[j].Name, students[j + 1].Name) > 0)
                        {
                            // Swap students if out of order alphabetically by name
                            Swap(students, j, j + 1);
                        }
                    }
                }
            }
        }

        // Selection sort algorithm to sort students by GPA (descending), name (ascending)
        public static void SelectionSortByGPADescending(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Compare GPAs of students
                    if (students[j].GPA > students[maxIndex].GPA)
                    {
                        maxIndex = j; // Update maximum index if larger GPA found
                    }
                    else if (students[j].GPA == students[maxIndex].GPA)
                    {
                        // If GPA is the same, compare names (ascending order)
                        if (string.Compare(students[j].Name, students[maxIndex].Name) < 0)
                        {
                            maxIndex = j; // Update maximum index if alphabetical order by name needed
                        }
                    }
                }
                // Swap current maximum with current position
                Swap(students, maxIndex, i);
            }
        }

        // Insertion sort algorithm to sort students by GPA (descending), name (ascending)
        public static void InsertionSortByGPADescending(List<Student> students)
        {
            int n = students.Count;
            for (int i = 1; i < n; ++i)
            {
                Student key = students[i];
                int j = i - 1;

                // Move elements of students[0..i-1], that are greater than key, to one position ahead of their current position
                while (j >= 0 && students[j].GPA < key.GPA)
                {
                    students[j + 1] = students[j];
                    j = j - 1;
                }
                students[j + 1] = key;
            }
        }

        // Merge sort algorithm to sort students by GPA (descending), name (ascending)
        public static void MergeSortByGPADescending(List<Student> students)
        {
            MergeSort(students, 0, students.Count - 1);
        }

        // Helper method for Merge Sort
        private static void MergeSort(List<Student> students, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                // Sort first and second halves
                MergeSort(students, left, middle);
                MergeSort(students, middle + 1, right);

                // Merge the sorted halves
                Merge(students, left, middle, right);
            }
        }

        // Helper method to merge two halves sorted by GPA
        private static void Merge(List<Student> students, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temporary arrays
            List<Student> LeftArray = new List<Student>();
            List<Student> RightArray = new List<Student>();

            // Copy data to temporary arrays
            for (int i = 0; i < n1; ++i)
                LeftArray.Add(students[left + i]);
            for (int j = 0; j < n2; ++j)
                RightArray.Add(students[middle + 1 + j]);

            // Merge the temporary arrays

            // Initial indexes of first and second subarrays
            int iL = 0, iR = 0;

            // Initial index of merged subarray array
            int k = left;
            while (iL < n1 && iR < n2)
            {
                if (LeftArray[iL].GPA >= RightArray[iR].GPA)
                {
                    students[k] = LeftArray[iL];
                    iL++;
                }
                else
                {
                    students[k] = RightArray[iR];
                    iR++;
                }
                k++;
            }

            // Copy remaining elements of LeftArray if any
            while (iL < n1)
            {
                students[k] = LeftArray[iL];
                iL++;
                k++;
            }

            // Copy remaining elements of RightArray if any
            while (iR < n2)
            {
                students[k] = RightArray[iR];
                iR++;
                k++;
            }
        }

        // Helper method to swap two students in a list
        private static void Swap(List<Student> students, int i, int j)
        {
            var temp = students[i];
            students[i] = students[j];
            students[j] = temp;
        }
    }
}
