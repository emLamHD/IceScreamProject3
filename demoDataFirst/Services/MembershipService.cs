using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IGenericRepository<Membership> _membershipRepository;

        public MembershipService(IGenericRepository<Membership> membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _membershipRepository.GetAll();
        }

        public Membership GetMembershipById(int id)
        {
            return _membershipRepository.GetById(id);
        }

        public async Task CreateAsync(Membership membership)
        {
            // Kiểm tra người dùng đã đăng ký chưa thông qua userId
            var existingMembership = await _membershipRepository.GetByConditionAsync(m => m.UserId == membership.UserId);

            bool check = false; // Mặc định là false

            if (existingMembership != null)
            {
                // Kiểm tra EndDate
                if (existingMembership.EndDate > DateTime.Now)
                {
                    check = true;
                }
            }

            // Nếu check là true, ném ngoại lệ
            if (check)
            {
                throw new Exception("Gói đăng ký của bạn vẫn còn thời hạn, bạn muốn gia hạn chứ?");
            }

            //sẽ thêm đợi thông tin payment thành công rồi add vào bảng

            // Thêm membership mới vào cơ sở dữ liệu
            await _membershipRepository.AddAsync(membership);
            await _membershipRepository.SaveAsync();
        }


        public async Task UpdateMembershipAsync(Membership membership)
        {
            _membershipRepository.UpdateAsync(membership); // Cập nhật thông tin membership
            await _membershipRepository.SaveAsync(); // Lưu thay đổi xuống cơ sở dữ liệu
        }

        public async Task DeleteMembershipAsync(int id)
        {
            await _membershipRepository.DeleteAsync(id);
        }

        public async Task<Membership?> GetMembershipByUserIdAsync(int? userId)
        {
            return await _membershipRepository.GetByConditionAsync(u => u.UserId == userId);
        }
    }
}
