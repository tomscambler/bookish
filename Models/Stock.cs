using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookish.Models;

public class Stock
{
    public int Id { get; set; }
    public Book? Book { get; set; }
    public Customer? Customer { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ReturnDate { get; set; }
}