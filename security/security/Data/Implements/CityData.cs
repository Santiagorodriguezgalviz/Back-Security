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
    public class CityData : ICityData
    {
        private readonly ApplicationDbContexts _context;
        protected readonly IConfiguration _configuration;

        public CityData(ApplicationDbContexts context, IConfiguration configuration)
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
            _context.Cities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"
                SELECT 
                    Id,
                    CONCAT(Name, ' - ', Code) AS TextoMostrar
                FROM 
                    [City]
                WHERE 
                    State = 1
                ORDER BY 
                    Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var sql = @"
                SELECT
                    Id,
                    Name,
                    Code,
                    DepartmentId,
                    State,
                    Created_at,
                    Updated_at,
                    Deleted_at
                FROM 
                    [City]
                ORDER BY 
                    Id ASC";
            return await _context.QueryAsync<CityDto>(sql);
        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM [City] WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<City> Save(City entity)
        {
            _context.Cities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CityDto>> GetListCities()
        {
            var sql = @"
                SELECT 
                    city.Id,
                    city.Created_at,
                    city.Created_by,
                    city.Deleted_at,
                    city.Deleted_by,
                    city.State,
                    city.Updated_at,
                    city.Updated_by,
                    city.Code AS CodeCity,
                    city.Name AS NameCity,
                    d.Name AS Department
                FROM 
                    City city
                INNER JOIN 
                    Department d ON city.DepartmentId = d.Id
                WHERE 
                    city.State = 1
                ORDER BY 
                    city.Id ASC";

            return await _context.QueryAsync<CityDto>(sql);
        }
    }
}
