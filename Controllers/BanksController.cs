using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairBankApi.Models;
using FairBankApi.Services.Bank;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FairBankApi.Controllers
    
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankDto>>> GetBanks()
        {
            var banks = await _bankService.GetBanks();
            return Ok(banks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankDto>> GetBank(int id)
        {
            var bank = await _bankService.GetBank(id);
            if (bank is null)
            {
                return NotFound("Bank not found.");
            }
            return Ok(bank);
        }
    }
}

