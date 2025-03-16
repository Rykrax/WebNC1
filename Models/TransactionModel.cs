using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    [Key]
    public int TransactionID { get; set; }

    [Required]
    public int SenderUser { get; set; }

    [Required, Column(TypeName = "varchar(50)"), StringLength(50)]
    public string SenderAccount { get; set; }

    [Required]
    public int SendBank { get; set; }

    [Required]
    public int RecipientUser { get; set; }

    [Required, Column(TypeName = "varchar(50)"), StringLength(50)]
    public string RepAccount { get; set; }

    [Required]
    public int RepBank { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string TransactionType { get; set; }

    public int Amount { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;

    [Column(TypeName = "nvarchar(255)")]
    public string Description { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string StatusTransaction { get; set; }

    public BankAccount SenderBankAccount { get; set; }
    public BankAccount RecipientBankAccount { get; set; }
}
