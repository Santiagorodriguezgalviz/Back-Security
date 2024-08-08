using Data.Dto;
using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public interface IUserData
    {
        public Task Delete(int id);
        public  Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<UserDto>> GetAll();
        public Task<User> Save(User entity);
        public Task Update(User entity);

        public Task<UserDto> Login(string Nombre_usuario, string Contraseña);
        public Task<User> GetByUsername(User user, int Id);
        public Task<User> GetByPassword(User user, int Id);
        public Task<User> GetById(int id);


    }
}
