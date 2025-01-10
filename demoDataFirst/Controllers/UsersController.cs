using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demoDataFirst.Data;
using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.CodeAnalysis.Scripting;
using demoDataFirst.DTO;
using BCrypt.Net;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                await _userService.CreateAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.UserId) return BadRequest();

            _userService.UpdateUserAsync(user);
            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);  // Gọi phương thức DeleteUserAsync bất đồng bộ
            return Ok("User deleted successfully");  // Trả về NoContent khi xóa thành công
        }

        //Authentication
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var newUser = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = hashedPassword
            };

            await _userService.CreateAsync(newUser);
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var user = await _authService.Authenticate(dto.Email, dto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("{userId}/upload-avatar")]
        public async Task<IActionResult> UploadAvatar(int userId, IFormFile? avatarFile)
        {
            if (avatarFile == null || avatarFile.Length == 0)
            {
                return BadRequest("File không hợp lệ.");
            }

            // Kiểm tra định dạng file
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(avatarFile.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Chỉ chấp nhận các file định dạng JPG, JPEG, PNG hoặc GIF.");
            }

            // Tạo đường dẫn lưu file
            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/avatars");

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, uniqueFileName);

            // Lưu file vào server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await avatarFile.CopyToAsync(fileStream);
            }

            // Đường dẫn lưu file trong server
            var avatarUrl = $"/uploads/avatars/{uniqueFileName}";

            try
            {
                // Gọi service để cập nhật avatar
                await _userService.UpdateAvatarAsync(userId, avatarUrl);
                return Ok(new { message = "Avatar đã được cập nhật thành công.", avatarUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}