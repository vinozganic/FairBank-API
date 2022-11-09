using System;
using AutoMapper;
using FairBankApi.Data;
using FairBankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FairBankApi.Services.Bank
{
    public class BankService : IBankService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BankService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BankDto> GetBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);

            if (bank is null)
            {
                return null;
            }

            var bankDto = _mapper.Map<BankDto>(bank);
            return bankDto;
        }

        public async Task<IEnumerable<BankDto>> GetBanks()
        {
            var banks = await _context.Banks.ToListAsync();
            var banksDto = _mapper.Map<List<BankDto>>(banks);
            return banksDto;
        }
    }
}

