using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BankAccount
{
    [Key, Column(TypeName = "varchar(50)"), StringLength(50)]
    public string AccountNumber { get; set; }

    [Required]
    public int UserID { get; set; }
    public User User { get; set; }

    [Required]
    public int BankID { get; set; }
    public Bank Bank { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string StatusAccount { get; set; }

    public ICollection<Transaction> SentTransactions { get; set; }
    public ICollection<Transaction> ReceivedTransactions { get; set; }
}
