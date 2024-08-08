using Data.DTO;
using Data.Interfaces;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class Rol_ViewData : IRole_ViewData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public Rol_ViewData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.role_view.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(RoleId, ' - ', ViewId) AS TextoMostrar 
                    FROM 
                        Security.Role_View
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<Rol_ViewDto>> GetAll()
        {
            var sql = @"SELECT 
                        Id,
                        RoleId,
                        role,
                        ViewId,
                        view,
                        State,
                    FROM 
                        Security.Role_View
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<Rol_ViewDto>(sql);
        }

        public async Task<Role_View> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Role_View WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role_View>(sql, new { Id = id });
        }


        public async Task<Role_View> Save(Role_View entity)
        {
            context.role_view.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Role_View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<View>> GetViewsForRole(int roleId)
        {
            var sql = @"SELECT v.* 
                FROM [View] AS v
                INNER JOIN [Role_View] AS rv ON v.Id = rv.ViewId
                WHERE rv.RoleId = @RoleId AND rv.State = 1 AND rv.Deleted_at IS NULL";

            return await context.QueryAsync<View>(sql, new { RoleId = roleId });
        }
    }
}

 