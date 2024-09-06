using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DevOps_Boards.Data.Model
{
	public class Card
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Status status{ get; set; }
		public string[]? Comment { get; set; }
		[JsonIgnore]
		[IgnoreDataMember]
		public virtual ICollection<AppUser> appUsers { get; set; }

	}

	public enum Status
    {
	   To=1,
       In_Progress,
	   Done,
    }
}
