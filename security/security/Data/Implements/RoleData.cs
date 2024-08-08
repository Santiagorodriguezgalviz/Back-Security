
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
using Data.DTO;
using Data.Implements;
using Data.Dto;

namespace Data.Implements
{
    public class RoleData : IRoleData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public RoleData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.role.Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar 
                    FROM 
                        [role]
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            var sql = @"SELECT * FROM [role]
            WHERE Deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<RoleDto>(sql);
        }

        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM [role] WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }


        public async Task<Role> Save(Role entity)
        {
            context.role.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(Role entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }


        public async Task<Role> GetByNombre(string nombre)
        {
            return await this.context.role.AsNoTracking().Where(item => item.Nombre == nombre).FirstOrDefaultAsync();
        }

    }
}
