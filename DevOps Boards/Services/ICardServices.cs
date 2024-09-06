using DevOps_Boards.Data.Model;
using Microsoft.Win32;

namespace DevOps_Boards.Services
{
	public interface ICardServices
	{
		public Task<List<Card>> GetAllCard();
		public Task<Card> GetCardById(int id);
		public Task<Card> GetCardByName(string name);
		public Task<List<Card>> GetCardIsDone();
		public Task<Card> AddCard(Card card);
		public Task<bool> UpdateCard(int id,Card card);
		public Task<bool> DeleteCard(int id);

	}
}
