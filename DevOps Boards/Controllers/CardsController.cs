using AutoMapper;
using DevOps_Boards.Data;
using DevOps_Boards.Data.Dto;
using DevOps_Boards.Data.Model;
using DevOps_Boards.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevOps_Boards.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardsController : ControllerBase
	{
		private readonly ICardServices _cardServices;
		private readonly IMapper _mapper;

		public CardsController(ICardServices cardServices, IMapper mapper)
		{
			_cardServices = cardServices;
			_mapper = mapper;
		}
		//[Authorize]
		[HttpGet("getAllCards")]
		public async Task<IActionResult> GetAllCards()
		{
			try
			{
				var cards = await _cardServices.GetAllCard();
                if (cards==null)
					return NotFound();
				var CardDtos = new List<CardDto>();
                  
				foreach (var card in cards)
				{
					CardDtos.Add(_mapper.Map<CardDto>(card));	
				}
				return Ok(CardDtos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[Authorize]
		[HttpGet("GwtCardById")]
		public async Task<IActionResult> GetCardById(int id)
		{
			try
			{
				var card = await _cardServices.GetCardById(id);
				if (card == null)
				{
					return NotFound($"this id {id} is not exist");
				}
				var CardDtos = _mapper.Map<CardDto>(card);
				return Ok(CardDtos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Authorize]
		[HttpGet("GwtCardByName")]
		public async Task<IActionResult> GetCardByName(string name)
		{
			try
			{
				var card = await _cardServices.GetCardByName(name);
				if (card == null)
				{
					return NotFound($"this name {name} is not exist");
				}
				var CardDtos = _mapper.Map<CardDto>(card);
				return Ok(CardDtos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	//	[Authorize(Roles ="TeamLeader")]
		[HttpGet("GetCardIsDone")]
		public async Task<IActionResult> GetCardIsDone()
		{
			try
			{
				var cards = await _cardServices.GetCardIsDone();
                if (cards==null)
                {
					return NotFound();
                }
				var CardDtos = new List<CardDto>();

				foreach (var card in cards)
				{
					CardDtos.Add(_mapper.Map<CardDto>(card));
				}
				return Ok(CardDtos);
	        }
			
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
            } 
		}

		[Authorize(Roles ="TeamLeader")]
		[HttpPost("AddCard")]
		public async Task<IActionResult> AddCard([FromForm]CardDto cardDto)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var newCard = _mapper.Map<Card>(cardDto);
					var card = await _cardServices.AddCard(newCard);
					return Ok(card);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

	//	[Authorize(Roles ="User")]
		[HttpPut("UpdateCard")]
		public async Task<IActionResult> UpdateCard(int id,[FromForm] CardDto cardDto)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Card card = _mapper.Map<Card>(cardDto);
					var newCard = await _cardServices.UpdateCard(id, card);
					if (newCard == false)
						return NotFound($"this id {id} is not exist");
					return Ok("Updated Successfully");
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
			else
				return BadRequest("someThing is wrong");
		}

		[Authorize(Roles = "TeamLeader")]
		[HttpDelete("DeleteCard")]
		public async Task<IActionResult> DeleteCard(int id)
		{
			try
			{
				var std = await _cardServices.DeleteCard(id);
				if (std == false)
				{
					return NotFound($"this id {id} is not exist");
				}
				return Ok("Deleted Successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
