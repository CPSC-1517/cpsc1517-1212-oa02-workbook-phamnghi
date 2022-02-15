using System.Text.RegularExpressions;


namespace HockeyTeamSystem
{
    public class Person
    {
        // Define an auto implemented property with a pricate set for the FullName
        // A private set property cannot be assigned a value in the
        //constructor or an instance method
        public string FullName { get; private set; }
        // Define a greedy contructor that takes a fullName as parameter
        // Constructors are used to create instance of an object
        //and also to assign meaningful values to the fields/properties of the class.
        public Person(string fullName)
        {
            // Validate that the fullName parameter is not null, whitespaces,
            //or an empty string
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException("Person FullName is required.");
            }

            // Validate that the fullName parameter contains only letters a-z
            //and one or space character
            // @"" is literal string where there is no meaning to any of the characters
            // ^ start of input
            // $ end of input
            // [] range of characters
            // {3,} at least 3
            // {,2} up to 2
            var fullNameCheck = new Regex(@"^[a-zA-Z]{3,}$");
            if (fullNameCheck.IsMatch(fullName) == false)
            {
                throw new ArgumentException("Person FullName must contain at least 3 characters.");
            }

            // The "this" keyword refers to the current object and
            //it is used to to access a field or property of the current object
            this.FullName = fullName.Trim();
        }
    }
}
