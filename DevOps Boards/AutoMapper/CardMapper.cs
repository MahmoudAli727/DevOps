using AutoMapper;
using DevOps_Boards.Data.Dto;
using DevOps_Boards.Data.Model;

namespace DevOps_Boards.AutoMapper
{
	public class CardMapper : Profile
	{
		public CardMapper()
		{
			CreateMap<CardDto, Card>().ReverseMap();
		}
	}
}
