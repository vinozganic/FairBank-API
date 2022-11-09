using System;
using AutoMapper;
using FairBankApi.Data.Entities;
using FairBankApi.Models;

namespace FairBankApi.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
	}
}

