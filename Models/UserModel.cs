using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserID { get; set; }

    [Required, Column(TypeName = "varchar(15)"), StringLength(15)]
    public string PhoneNumber { get; set; }

    [Required, Column(TypeName = "varchar(255)")]
    public string PasswordHash { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string FullName { get; set; }

    [Column(TypeName = "char(12)"), StringLength(12)]
    public string CCCD { get; set; }

    public DateTime? BirthDate { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; }

    public int Balance { get; set; } = 0;

    [Required, Column(TypeName = "char(6)"), StringLength(6)]
    public string PinCode { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;

    [Column(TypeName = "nvarchar(255)")]
    public string StatusUser { get; set; }

    [Required, Column(TypeName = "nvarchar(20)")]
    public string RoleUser { get; set; } = "user";

    public ICollection<BankAccount> BankAccounts { get; set; }
}
