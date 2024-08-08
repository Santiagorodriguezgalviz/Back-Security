using Data.Dto;
using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IUserBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> Save(UserDto entity);
        Task Update(int id, UserDto entity);
        Task<User> GetByUsername(User user, int Id);
        Task<User> GetByPassword(User user, int Id);
        Task<UserDto> Login(string Nombre_usuario, string Contraseña);




    }
}
