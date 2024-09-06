using DevOps_Boards.Data.Model;

namespace DevOps_Boards.Data.Dto
{
	public class CardDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public Status status { get; set; }
		public string[]? Comment { get; set; }
	}
}
