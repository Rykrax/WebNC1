using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Thiết lập khóa chính của BankAccounts (Composite Key)
        modelBuilder.Entity<BankAccount>()
            .HasKey(ba => new { ba.AccountNumber, ba.BankID });

        // Thiết lập quan hệ cho Transactions
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.SenderBankAccount)
            .WithMany(b => b.SentTransactions)
            .HasForeignKey(t => new { t.SenderAccount, t.SendBank });

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.RecipientBankAccount)
            .WithMany(b => b.ReceivedTransactions)
            .HasForeignKey(t => new { t.RepAccount, t.RepBank });

        base.OnModelCreating(modelBuilder);
    }
}
