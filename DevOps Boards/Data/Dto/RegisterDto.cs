using System.Diagnostics.CodeAnalysis;

namespace DevOps_Boards.Data.Dto
{
	public class RegisterDto
	{
		public string FName { get; set;}
		public string LName { get; set;}
		public string UserName { get; set;}
		public string Email { get; set;}
		public string Password { get; set;}
		public string ConfirmedPassword { get; set;}
		public string phone { get; set; }
		public int CardId { get; set;}  
		public int Age { get; set; }
		public IFormFile ? image { get; set; }
	}
}
