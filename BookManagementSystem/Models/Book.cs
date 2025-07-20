using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
