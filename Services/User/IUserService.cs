using System;
using FairBankApi.Models;

namespace FairBankApi.Services.User
{
	public interface IUserService
	{
		Task<IEnumerable<UserDto>> GetUsers();

		Task<UserDto> GetUser(int id);

		Task<UserDto> CreateUser(UserDto user);

		Task<UserDto> UpdateUser(UserDto user);

		Task<UserDto> DeleteUser(int id);

		Task<UserDto> GetUserByUsername(string username);

		Task<bool> Login(UserDto user, string password);
    }
}

