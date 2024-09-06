using AutoMapper;
using DevOps_Boards.Data;
using DevOps_Boards.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Boards.Services
{
	public class CardServices : ICardServices
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<AppUser> _userManager;

		public CardServices(IMapper mapper, AppDbContext appDbContext, UserManager<AppUser> userManager)
		{
			_appDbContext = appDbContext;
			_userManager = userManager;
		}
		public async Task<List<Card>> GetAllCard()
		{
			var cards = await _appDbContext.cards.ToListAsync();
			if (cards == null)
				return null;
			return cards;
		}
		
		public async Task<Card> GetCardById(int id)
		{
			var card= await _appDbContext.cards.FindAsync(id);
			if (card == null)
				return null;
			return card;
		}

		public async Task<Card> GetCardByName(string title)
		{
			var card = await _appDbContext.cards.FirstOrDefaultAsync(x => x.Title == title);
				if (card == null)
					return null;
			return card;
		}

		public async Task<List<Card>> GetCardIsDone()
		{
			var cards = await _appDbContext.cards.Where(x => x.status == Status.Done).ToListAsync();
			if (cards == null)
				return null;
			return cards;
		}
		public async Task<Card> AddCard(Card card)
		{
            await _appDbContext.AddAsync(card);
			await _appDbContext.SaveChangesAsync();
			return card;
		}
		
		public async Task<bool> UpdateCard(int id, Card card)
		{
			var Findcard = await _appDbContext.cards.FindAsync(id);
			var caedUserId = await _userManager.Users.FirstOrDefaultAsync(x => x.CardId == id); 
	
			if (Findcard==null)
				return false;

			if (caedUserId == null)
				return false;
			
			Findcard.Title = card.Title;
			Findcard.Description = card.Description;
			Findcard.status = card.status;
			var newComments = new string[card.Comment.Length+Findcard.Comment.Length] ;
			var s = 0;
			for (int i = 0; i < Findcard.Comment.Length; i++)
            {
				newComments[i] = Findcard.Comment[i];
				s++;
            }
            for (int i = s ,j=0 ; i < newComments.Length; i++,j++)
            {
				newComments[i] = card.Comment[j];
            }
            Findcard.Comment = newComments;
			
			_appDbContext.cards.Update(Findcard);
			await _appDbContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteCard(int id)
		{
			var Findcard = await _appDbContext.cards.FindAsync(id);
	
			if (Findcard==null)
				return false;
			
			_appDbContext.cards.Remove(Findcard);
			await _appDbContext.SaveChangesAsync();
			return true;
		}
	}
}
