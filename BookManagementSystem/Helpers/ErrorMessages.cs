using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Helpers
{
    public class ErrorMessages
    {
        // Menu
        public const string InvalidMenuOption = "\nInvalid input/option :(. Please enter a number between 1 and 6.";

        // Book ID
        public const string EnterBookId = "Enter the Book ID: ";
        public const string InvalidId = "Invalid ID:(. Book ID must be an Integer.";

        public const string InvalidUpdateId = "Invalid ID. Please enter a valid integer :(.";
        public const string EnterBookIdToRemove = "Enter a Book ID to remove: ";

        // Title
        public const string InvalidTitle = "Title cannot be empty :(.";

        // Author
        public const string InvalidAuthor = "Author's name must contain only letters and spaces, and be at least 3 letters long :(.";

        // Publication Year
        public static string GetInvalidYearMessage(int currentYear) =>
            $"Publication Year must be a 4-digit number between Year 1000 and {currentYear} :(.";

        // Availability
        public const string InvalidAvailability = "Please enter 'yes' or 'no' :(.";

        // Search
        public const string NoBooksFound = "No books found matching the keyword.";
    }
}
