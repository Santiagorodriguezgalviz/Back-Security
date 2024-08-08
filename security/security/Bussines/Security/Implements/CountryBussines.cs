using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implements;
using Entity.Model.Security;

namespace Bunnisses.Security.Implemetations
{
    public class CountryBusiness : ICountryBusiness
    {
        private readonly ICountryData data;

        public CountryBusiness(ICountryData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<CountryDto> GetById(int id)
        {
            var country = await data.GetById(id);

            return new CountryDto
            {
                Id = country.Id,
                Nombre = country.Nombre,
                Codigo = country.Codigo,
                State = country.State,
                Created_at = country.Created_at,
                Updated_at = country.Updated_at,
                Deleted_at = country.Deleted_at
            };
        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country();
            country = this.MapearDatos(country, entity);

            return await data.Save(country);
        }

        public async Task Update(int id, CountryDto entity)
        {
            Country country = await this.data.GetById(id);
            if (country == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            country = this.MapearDatos(country, entity);

            await this.data.Update(country);
        }

        private Country MapearDatos(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.Nombre = entity.Nombre;
            country.Codigo = entity.Codigo;
            country.State = entity.State;
            country.Created_at = entity.Created_at;
            country.Updated_at = entity.Updated_at;
            country.Deleted_at = entity.Deleted_at;

            return country;
        }
    }
}
