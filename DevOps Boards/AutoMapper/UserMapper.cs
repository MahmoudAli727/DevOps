using AutoMapper;
using DevOps_Boards.Data.Dto;
using DevOps_Boards.Data.Model;

namespace DevOps_Boards.AutoMapper
{
	public class UserMapper:Profile
	{
		public UserMapper() 
		{
			CreateMap<AppUser, RegisterDto>().
				ForMember(user => user.FName, src => src.MapFrom(src => src.firstName)).
				ForMember(user => user.LName, src => src.MapFrom(src => src.lastName)).
				ForMember(src => src.image, opt => opt.Ignore());
		}
	}
}
