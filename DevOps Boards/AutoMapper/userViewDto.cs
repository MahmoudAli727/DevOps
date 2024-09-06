using AutoMapper;
using DevOps_Boards.Data.Dto;
using DevOps_Boards.Data.Model;

namespace DevOps_Boards.AutoMapper
{
	public class userViewDto:Profile
	{
        public userViewDto()
        {
			CreateMap<AppUser, UserDto>().
			ForMember(user => user.FName, src => src.MapFrom(src => src.firstName)).
			ForMember(user => user.LName, src => src.MapFrom(src => src.lastName));
		}
    }
}
