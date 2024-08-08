using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Data.DTO;
using Data.Implements;

namespace Data.Implementations
{
    public class DepartamentData : IDepartamentData
    {
        private readonly ApplicationDbContexts _context;
        protected readonly IConfiguration _configuration;

        public DepartamentData(ApplicationDbContexts context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            _context.Departaments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"
                SELECT 
                    Id,
                    CONCAT(Name, ' - ', Code) AS TextoMostrar
                FROM 
                    [Departament]
                WHERE 
                    State = 1
                ORDER BY 
                    Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<DepartamentDto>> GetAll()
        {
            var sql = @"
                SELECT
                    Id,
                    Name,
                    Code,
                    CountryId,
                    State,
                    Created_at,
                    Updated_at,
                    Deleted_at
                FROM 
                    [Departament]
                ORDER BY 
                    Id ASC";
            return await _context.QueryAsync<DepartamentDto>(sql);
        }

        public async Task<Departament> GetById(int id)
        {
            var sql = @"SELECT * FROM [Departament] WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<Departament>(sql, new { Id = id });
        }

        public async Task<Departament> Save(Departament entity)
        {
            _context.Departaments.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Departament entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartamentDto>> GetListDepartaments()
        {
            var sql = @"
                SELECT 
                    department.Id,
                    department.Created_at,
                    department.Created_by,
                    department.Deleted_at,
                    department.Deleted_by,
                    department.State,
                    department.Updated_at,
                    department.Updated_by,
                    department.Code AS CodeDepartment,
                    department.Name AS NameDepartment,
                    c.Name AS Country
                FROM 
                    Departament department
                INNER JOIN 
                    Country c ON department.CountryId = c.Id
                WHERE 
                    department.State = 1
                ORDER BY 
                    department.Id ASC";

            return await _context.QueryAsync<DepartamentDto>(sql);
        }
    }
}
