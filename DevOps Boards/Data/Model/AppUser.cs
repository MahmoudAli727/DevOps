using DevOps_Boards.Data.Dto;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DevOps_Boards.Data.Model
{
	public class AppUser : IdentityUser
	{
        public string firstName { get; set; }
		public string lastName { get; set; }
        public string phone { get; set; }
        public int Age { get; set; }
        public byte[]? image { get; set; }
		
		[ForeignKey(nameof(CardId))]
		public int? CardId { get; set; }
		public virtual Card card { get; set; }
	}
	
	public static class Role
	{
		public static string UserRole = "User"; 
		public static string TeamLeaderRole = "TeamLeader"; 
	}
}
