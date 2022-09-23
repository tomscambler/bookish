using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookish.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    [DisplayName("Book Title")]
    public string Title { get; set; }
    public string Author { get; set; }
    // public string ISBN;
    
}