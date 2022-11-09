using AutoMapper;
using FairBankApi.Data;
using FairBankApi.Helpers;
using FairBankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FairBankApi.Services.User
{
    public class UserService : IUserService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            user.Id = 0;
            var userEntity = _mapper.Map<Data.Entities.User>(user);
            UserHelper.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            _context.Add(userEntity);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity is null)
            {
                return null;
            }
            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(userEntity);

            return userDto;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var userEntity = await _context.Users.FindAsync(user.Id);
            if (userEntity is null)
            {
                return null;
            }
            _mapper.Map(user, userEntity);
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<bool> Login(UserDto user, string password)
        {
            var userEntity = await _context.Users.FindAsync(user.Id);
            if (userEntity is not null && UserHelper.VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                return true;
            }

            return false;
        }
    }
}

