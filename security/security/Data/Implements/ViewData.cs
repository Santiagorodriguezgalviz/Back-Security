using Data.Dto;
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
    public class ViewData : IViewData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public ViewData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.view.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion , ' - ', Ruta) AS TextoMostrar 
                    FROM 
                        Security.View
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre,
                Descripcion,
                ruta,
                Modulo_id,
                Module,
                State,
            FROM Security.View
            WHERE p.deleted_at IS NULL
            ORDER BY p.Id ASC";

            return await context.QueryAsync<ViewDto>(sql);
        }

        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.View WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }



        public async Task<View> Save(View entity)
        {
            context.view.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<View> GetByName(string nombre)
        {
            return await this.context.view.AsNoTracking().Where(item => item.Nombre == nombre).FirstOrDefaultAsync();
        }

    }
}
