namespace DevOps_Boards.Data.Dto
{
	public class UserDto
	{
		public string FName { get; set; }
		public string LName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string phone { get; set; }
		public int CardId { get; set; }
		public int Age { get; set; }
		public byte[]? image { get; set; }
	}
}
