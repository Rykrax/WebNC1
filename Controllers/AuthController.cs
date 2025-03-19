using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    // [HttpPost("login")]
    // public async Task<IActionResult> Login([FromBody] LoginModel model)
    // {
    //     var user = await _context.Users
    //         .FirstOrDefaultAsync(u => u.Email == model.Email);

    //     if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
    //     {
    //         return Unauthorized(new { message = "Email hoặc mật khẩu không đúng" });
    //     }

    //     return Ok(new { message = "Đăng nhập thành công", userId = user.Id });
    // }
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {

        if (await _context.Users.AnyAsync(u => u.Email == model.Email))
        {
            return BadRequest(new { message = "Email đã tồn tại!" });
        }

        
        // return Ok(new { message = "Đăng ký thành công!" });
        var user = new User
        {
            Email = model.Email,
            PasswordHash = model.Password
            // PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password), // Mã hóa mật khẩu
            // CreateAt = DateTime.Now
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Đăng ký thành công!" });
    }
}
