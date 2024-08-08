using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bunnisses.Security.Interface;

using Data.DTO;
using Data.Implements;
using Entity.Model.Security;

namespace Bunnisses.Security.Implemetations
{
    public class CityBusiness : ICityBusiness
    {
        private readonly ICityData data;

        public CityBusiness(ICityData data)
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

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<CityDto> GetById(int id)
        {
            var city = await data.GetById(id);

            return new CityDto
            {
                Id = city.Id,
                Nombre = city.Nombre,
                Codigo = city.Codigo,
                DepartmentId = city.DepartmentId,
                State = city.State,
                Created_at = city.Created_at,
                Updated_at = city.Updated_at,
                Deleted_at = city.Deleted_at
            };
        }

        public async Task<City> Save(CityDto entity)
        {
            City city = new City();
            city = this.MapearDatos(city, entity);

            return await data.Save(city);
        }

        public async Task Update(int id, CityDto entity)
        {
            City city = await this.data.GetById(id);
            if (city == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            city = this.MapearDatos(city, entity);

            await this.data.Update(city);
        }

        private City MapearDatos(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.Nombre = entity.Nombre;
            city.Codigo = entity.Codigo;
            city.DepartmentId = entity.DepartmentId;
            city.State = entity.State;
            city.Created_at = entity.Created_at;
            city.Updated_at = entity.Updated_at;
            city.Deleted_at = entity.Deleted_at;

            return city;
        }
    }
}
