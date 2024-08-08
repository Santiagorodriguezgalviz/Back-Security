using Data.DTO;
using Data.Interfaces;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class User_RoleData : IUser_roleData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public User_RoleData(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.user_role.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(RoleId, ' - ', UserId) AS TextoMostrar 
                    FROM 
                        Security.User_role
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<User_RoleDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                UserId,
                RoleId,
                user,
                role,
                State,
            FROM Security.User_role
            WHERE p.deleted_at IS NULL
            ORDER BY p.Id ASC";

            return await context.QueryAsync<User_RoleDto>(sql);
        }

        public async Task<User_role> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.User_role WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User_role>(sql, new { Id = id });
        }


        public async Task<User_role> Save(User_role entity)
        {
            context.user_role.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(User_role entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
