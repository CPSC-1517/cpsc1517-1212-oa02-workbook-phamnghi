// See https://aka.ms/new-console-template for more information
using OOPDemo01;
using static System.Console; // Allows you to access the static methods in Console class directly

//Create a new Course object
Course cpsc1517Course = new Course("CPSC1517","Introduction to Application Development");
//var cpsc1517Course = new Course("CPSC1517", "Introduction to Application Development");
//Course cpsc1517Course = new ("CPSC1517", "Introduction to Application Development");

WriteLine($"CourseNo: {cpsc1517Course.CourseNo}");
WriteLine($"CourseName: {cpsc1517Course.CourseName}");

//Add some students to the course
cpsc1517Course.AddStudent("Aaron Fong");
cpsc1517Course.AddStudent("David L. McKinley");
cpsc1517Course.AddStudent("Hamza Said");
cpsc1517Course.AddStudent("Haseeb Memon");
cpsc1517Course.AddStudent("Allaine Paredes");

cpsc1517Course.LoadFromFile(@"C:\SCHOOL\CPSC1517\cpsc1517-1212-oa02-workbook-phamnghi\OOPDemo01\OOPDemo01");

//Display all the students in the course
foreach (var currentStudent in cpsc1517Course.Students)
{
    WriteLine(currentStudent);
}

// Remove 2 students from the course
cpsc1517Course.RemoveStudent("Hamza Said");
cpsc1517Course.RemoveStudent("Haseeb Memon");

cpsc1517Course.SaveToFile("cpsc1517Course.csv");

//Display the number of student
WriteLine($"There are now {cpsc1517Course.StudentCount} students");
