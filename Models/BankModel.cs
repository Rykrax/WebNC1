using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bank
{
    [Key]
    public int BankID { get; set; }

    [Required, Column(TypeName = "nvarchar(255)"), StringLength(255)]
    public string BankName { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string BankImage { get; set; }

    public ICollection<BankAccount> BankAccounts { get; set; }
}
