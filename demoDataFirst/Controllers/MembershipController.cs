using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
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
            if (membership == null)
                return NotFound("Không tìm thấy membership này.");
            return Ok(membership);
        }

        [HttpPost]
        public async Task<IActionResult> AddMembership(Membership membership)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _membershipService.CreateMembershipAsync(membership);
            return CreatedAtAction(nameof(GetMembershipById), new { id = membership.MembershipId }, membership);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembership(int id, Membership membership)
        {
            if (id != membership.MembershipId)
                return BadRequest("ID không khớp.");

            await _membershipService.UpdateMembershipAsync(membership);
            return Ok("Cập nhật thành công.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            await _membershipService.DeleteMembershipAsync(id);
            return Ok("Xóa thành công.");
        }
    }
}
