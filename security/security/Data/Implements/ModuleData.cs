
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

namespace Data.Implementations
{
    public class ModuleData : IModuleData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public ModuleData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.module.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                     CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar
                    FROM 
                        Security.Module 
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            var sql = @"SELECT
                    Id,
                    Nombre,
                    Descripcion,
                    State,
                  FROM 
                      Security.Module
                  WHERE p.deleted_at IS NULL
                  ORDER BY p.Id ASC";

            return await context.QueryAsync<ModuleDto>(sql);
        }


        public async Task<Module> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Module WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Module>(sql, new { Id = id });
        }


        public async Task<Module> Save(Module entity)
        {
            context.module.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    
        }
    }

