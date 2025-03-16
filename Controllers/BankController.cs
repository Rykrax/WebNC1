using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BankController : Controller
{
    private readonly AppDbContext _context;

    public BankController(AppDbContext context)
    {
        _context = context;
    }

    // Lấy danh sách bank
    [HttpGet("/get-banks")]
    public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
    {
        return await _context.Banks.ToListAsync();
    }

    // [HttpDelete("delete-bank/{bankCode}")]
    // public async Task<IActionResult> DeleteBank(string bankCode)
    // {
    //     var bank = await _context.Banks.FindAsync(bankCode);
    //     if (bank == null)
    //     {
    //         return NotFound(new { message = "Bank không tồn tại!" });
    //     }

    //     _context.Banks.Remove(bank);
    //     await _context.SaveChangesAsync();
    //     return Ok(new { message = "Xóa thành công!", bank });
    // }

    // [HttpPost("create-bank")]
    // public async Task<ActionResult<Bank>> CreateBank([FromBody] Bank bank)
    // {
    //     // Kiểm tra nếu bank đã tồn tại
    //     var existingBank = await _context.Banks.FindAsync(bank.BankCode);
    //     if (existingBank != null)
    //     {
    //         return Conflict(new { message = "Bank đã tồn tại!" });
    //     }

    //     _context.Banks.Add(bank);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction(nameof(GetBanks), new { bankCode = bank.BankCode }, bank);
    // }
}