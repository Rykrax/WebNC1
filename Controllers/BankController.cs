using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/banks")]
[ApiController]
public class BankController : ControllerBase
{
    private readonly AppDbContext _context;

    public BankController(AppDbContext context)
    {
        _context = context;
    }

    //Lấy danh sách Bank
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
    {
        return await _context.Banks.ToListAsync();
    }

    //Lấy Bank theo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Bank>> GetBank(int id)
    {
        var bank = await _context.Banks.FindAsync(id);
        if (bank == null) return NotFound();
        return bank;
    }

    //Thêm Bank mới
    [HttpPost]
    public async Task<ActionResult<Bank>> CreateBank(Bank bank)
    {
        _context.Banks.Add(bank);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBank), new { id = bank.BankID }, bank);
    }

    //Cập nhật Bank
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBank(int id, Bank bank)
    {
        if (id != bank.BankID) return BadRequest();

        _context.Entry(bank).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    //Xóa Bank
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBank(int id)
    {
        var bank = await _context.Banks.FindAsync(id);
        if (bank == null) return NotFound();

        _context.Banks.Remove(bank);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
