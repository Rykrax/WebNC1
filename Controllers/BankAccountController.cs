using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/bank-accounts")]
[ApiController]
public class BankAccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public BankAccountController(AppDbContext context)
    {
        _context = context;
    }

    //Lấy danh sách tài khoản ngân hàng
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
    {
        return await _context.BankAccounts.ToListAsync();
    }

    //Lấy tài khoản theo AccountNumber
    [HttpGet("{accountNumber}/{bankId}")]
    public async Task<ActionResult<BankAccount>> GetBankAccount(string accountNumber, int bankId)
    {
        var account = await _context.BankAccounts.FindAsync(accountNumber, bankId);
        if (account == null) return NotFound();
        return account;
    }

    //Thêm tài khoản ngân hàng mới
    [HttpPost]
    public async Task<ActionResult<BankAccount>> CreateBankAccount(BankAccount account)
    {
        _context.BankAccounts.Add(account);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBankAccount), new { accountNumber = account.AccountNumber, bankId = account.BankID }, account);
    }

    //Cập nhật tài khoản ngân hàng
    [HttpPut("{accountNumber}/{bankId}")]
    public async Task<IActionResult> UpdateBankAccount(string accountNumber, int bankId, BankAccount account)
    {
        if (accountNumber != account.AccountNumber || bankId != account.BankID) return BadRequest();

        _context.Entry(account).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    //Xóa tài khoản ngân hàng
    [HttpDelete("{accountNumber}/{bankId}")]
    public async Task<IActionResult> DeleteBankAccount(string accountNumber, int bankId)
    {
        var account = await _context.BankAccounts.FindAsync(accountNumber, bankId);
        if (account == null) return NotFound();

        _context.BankAccounts.Remove(account);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
