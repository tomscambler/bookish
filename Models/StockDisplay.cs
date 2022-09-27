using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookish.Models;

public class StockDisplay
{
    public int BookId { get; set; }
    public string Title{ get; set; }
    public string Author { get; set; }
    public int TotalStock { get; set; }
    public int StockAvailable { get; set; }
}