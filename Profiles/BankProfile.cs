using System;
using AutoMapper;
using FairBankApi.Data.Entities;
using FairBankApi.Models;

namespace FairBankApi.Profiles
{
	public class BankProfile : Profile
	{
		public BankProfile()
		{
            CreateMap<BankDto, Bank>();
            CreateMap<Bank, BankDto>();
        }
	}
}

