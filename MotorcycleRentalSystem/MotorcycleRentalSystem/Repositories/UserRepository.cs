using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Core;
using MotorcycleRentalSystem.Data;
using MotorcycleRentalSystem.Enuns;
using MotorcycleRentalSystem.Models;
using MotorcycleRentalSystem.Repositories.Interfaces;
using System.ComponentModel;
using System.Reflection;

namespace MotorcycleRentalSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MotorcycleRentalDBContext _dbContext;
        public UserRepository(MotorcycleRentalDBContext context) 
        { 
            _dbContext = context;
        }
        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> CnpjAlredyExist(string cnpj)
        {
            return await _dbContext.User.AnyAsync(u => u.CNPJ == cnpj.Trim());
        }
        public async Task<bool> CnhAlredyExist(string cnh)
        {
            return await _dbContext.User.AnyAsync(u => u.cnhNumber == cnh.Trim());
        }
        public async Task<UserModel> Add(UserModel user)
        {
            if (!(user.cnhType == CNHType.A.GetDescription()) || !(user.cnhType == CNHType.B.GetDescription()))
            {
                throw new Exception("The specified driver's license type is not valid");
            }
            if( await CnpjAlredyExist(user.CNPJ))
            {
                throw new Exception($"CNPJ {user.CNPJ} is already registered in the database ");
            }
            if( await CnhAlredyExist(user.cnhNumber))
            {
                throw new Exception($"CNH {user.cnhNumber} is already registered in the database ");
            }

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();          

            return user;
        }
        public async Task<UserModel> Update(UserModel user, int id, byte[] image)
        {
            UserModel dbUser = await GetById(id);
            if(dbUser == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }
            if (!ImageValidator.IsPngOrBmpOrEmpty(user.cnhImagePath))
            {
                throw new Exception("valid image formats are png or bmp");
            }

            _dbContext.User.Update(dbUser);
            await _dbContext.SaveChangesAsync();

            return dbUser;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel dbUser = await GetById(id);
            if (dbUser == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }

            _dbContext.User.Remove(dbUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsAdmin(int id)
        {
            UserModel dbUser = await GetById(id);
            if (dbUser == null)
            {
                throw new Exception($"User ID: {id} was not found in the database.");
            }

            return dbUser.profileId == 0 ? true : false;
        }        
    }
    public class ImageValidator
    {
        public static bool IsPngOrBmpOrEmpty(byte[] imageData)
        {
            if (imageData.Length < 2)
                return false;

            // Verifica se o cabeçalho corresponde ao formato PNG
            if (imageData[0] == 0x89 && imageData[1] == 0x50)
                return true;

            // Verifica se o cabeçalho corresponde ao formato BMP
            if (imageData[0] == 0x42 && imageData[1] == 0x4D)
                return true;

            if(imageData == null)
                return true;

            return false;
        }
    }
}
