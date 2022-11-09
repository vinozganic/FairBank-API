using System;
using FairBankApi.Models;

namespace FairBankApi.Services.Bank
{
	public interface IBankService
	{
        Task<IEnumerable<BankDto>> GetBanks();

        Task<BankDto> GetBank(int id);
    }
}

