using DevOps_Boards.Data.Dto;
using DevOps_Boards.Data.Model;
using Microsoft.Win32;

namespace DevOps_Boards.Services
{
	public interface IAuthServices
	{
		Task<Auth> RegisterAsync(RegisterDto model);
		Task<Auth> LoginAsync(LoginDto model);
		Task<AppUser> GetUserByEmail(string email);
		Task<List<AppUser>> GetUses();
		Task<bool> UpdateUserAsync(string email,RegisterDto model);
		Task<bool> DeleteUserAsync(string email);
	}
}
