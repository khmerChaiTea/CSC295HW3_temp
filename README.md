CSC 295: algorithms and Data Structure
Homework #3

I approached homework number three step by step. Initially, I created a "Student" class with properties for name (string) and GPA (double). To ensure the GPA falls within the valid range of 0 to 4, I used an "if" statement with an "ArgumentOutOfRangeException()". The student information was formatted using the "ToString()" method.

In the main method, I managed a list of students with their respective names and GPAs. If a GPA was outside the range of 0 to 4, an error was raised. I integrated a Scanner object to build an interactive console menu allowing users to select from various sorting algorithms for sorting students. A while loop controlled the menu, ensuring users could navigate the sorting options and exit cleanly upon making a valid choice. Choosing an invalid option triggered an error message.

For the third step of the assignment, I implemented sorting by GPA in descending order. I utilized an array of Student objects in the code and employed a "foreach" loop to display each student's details.

This implementation demonstrates how to integrate multiple sorting algorithms effectively into an existing console application for sorting Student objects based on GPA in descending order. It allows for further customization or enhancement based on specific needs or additional functionality requirements. When GPAs are identical, the names are sorted in ascending order.

Student Class:
- Represents a student with properties for Name and GPA.
- Includes a constructor to initialize students with name and GPA.
- Overrides ToString() to provide formatted student information.

Main Method (Program Class):
- Presents a menu for sorting Student objects by GPA in descending order using various algorithms.
- Utilizes the SortingAlgorithms class for sorting based on user selection.
- Handles user input validation and exceptions gracefully.

SortingAlgorithms Class:
- Contains static methods for sorting List<Student> objects by GPA in descending order using Bubble Sort, Selection Sort, Insertion Sort, and Merge Sort.
- Each method primarily compares Student objects by GPA and by name alphabetically if necessary.
- Merge Sort is implemented recursively with helper methods MergeSort and Merge.

PrintStudents Method:
- Helper method to print a list of Student objects to the console.

Output:
- Upon execution, prompts the user to select a sorting algorithm.
- Depending on the chosen algorithm, the list of Student objects is sorted by GPA in descending order and displayed accordingly.
