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
    public class CountryData : ICountryData
    {
        private readonly ApplicationDbContexts _context;
        protected readonly IConfiguration _configuration;

        public CountryData(ApplicationDbContexts context, IConfiguration configuration)
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
            _context.countries.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"
                SELECT 
                    Id,
                    CONCAT(Name, ' - ', Code) AS TextoMostrar
                FROM 
                    [Country]
                WHERE 
                    State = 1
                ORDER BY 
                    Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            var sql = @"
                SELECT
                    Id,
                    Name,
                    Code,
                    State,
                    Created_at,
                    Updated_at,
                    Deleted_at
                FROM 
                    [Country]
                ORDER BY 
                    Id ASC";
            return await _context.QueryAsync<CountryDto>(sql);
        }

        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM [Country] WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public async Task<Country> Save(Country entity)
        {
            _context.countries.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Country entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryDto>> GetListCountries()
        {
            var sql = @"
                SELECT 
                    country.Id,
                    country.Created_at,
                    country.Created_by,
                    country.Deleted_at,
                    country.Deleted_by,
                    country.State,
                    country.Updated_at,
                    country.Updated_by,
                    country.Code AS CodeCountry,
                    country.Name AS NameCountry
                FROM 
                    Country country
                WHERE 
                    country.State = 1
                ORDER BY 
                    country.Id ASC"
            ;

            return await _context.QueryAsync<CountryDto>(sql);
        }
    }
}
