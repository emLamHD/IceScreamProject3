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
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IAuthService _authService;
        public MembershipController(IMembershipService membershipService, IAuthService authService)
        {
            _membershipService = membershipService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAllMemberships()
        {
            var memberships = _membershipService.GetAllMemberships();
            return Ok(memberships);
        }

        [HttpGet("{id}")]
        public IActionResult GetMembershipById(int id)
        {
            var membership = _membershipService.GetMembershipById(id);
            if (membership == null) return NotFound();
            return Ok(membership);
        }

        [HttpPost]
        public async Task<IActionResult> AddMembership(Membership membership)
        {
            try
            {
                await _membershipService.CreateAsync(membership);
                return CreatedAtAction(nameof(GetMembershipById), new { id = membership.MembershipId }, membership);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMembership(int id, Membership membership)
        {
            if (id != membership.MembershipId) return BadRequest();

            _membershipService.UpdateMembershipAsync(membership);
            return Ok("Membership updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            await _membershipService.DeleteMembershipAsync(id);
            return Ok("User deleted successfully");
        }
    }
}
