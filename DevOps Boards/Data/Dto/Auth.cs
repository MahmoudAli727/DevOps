﻿using System.Text.Json.Serialization;

namespace DevOps_Boards.Data.Dto
{
	public class Auth
	{
		public string? Message { get; set; }
		public bool IsAuthenticated { get; set; }
		public string? Username { get; set; }
		public string? Email { get; set; }
		public List<string>? Roles { get; set; }
		public string? Token { get; set; }
		public DateTime? ExpiresOn { get; set; }
	}
}
