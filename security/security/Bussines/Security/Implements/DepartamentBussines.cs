using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implements;
using Entity.Model.Security;

namespace Bunnisses.Security.Implemetations
{
    public class DepartamentBusiness : IDepartamentBusiness
    {
        private readonly IDepartamentData data;

        public DepartamentBusiness(IDepartamentData data)
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

        public async Task<IEnumerable<DepartamentDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<DepartamentDto> GetById(int id)
        {
            var departament = await data.GetById(id);

            return new DepartamentDto
            {
                Id = departament.Id,
                Nombre = departament.Nombre,
                Codigo = departament.Codigo,
                CountryId = departament.CountryId,
                State = departament.State,
                Created_at = departament.Created_at,
                Updated_at = departament.Updated_at,
                Deleted_at = departament.Deleted_at
            };
        }

        public async Task<Departament> Save(DepartamentDto entity)
        {
            Departament departament = new Departament();
            departament = this.MapearDatos(departament, entity);

            return await data.Save(departament);
        }

        public async Task Update(int id, DepartamentDto entity)
        {
            Departament departament = await this.data.GetById(id);
            if (departament == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            departament = this.MapearDatos(departament, entity);

            await this.data.Update(departament);
        }

        private Departament MapearDatos(Departament departament, DepartamentDto entity)
        {
            departament.Id = entity.Id;
            departament.Nombre = entity.Nombre;
            departament.Codigo = entity.Codigo;
            departament.CountryId = entity.CountryId;
            departament.State = entity.State;
            departament.Created_at = entity.Created_at;
            departament.Updated_at = entity.Updated_at;
            departament.Deleted_at = entity.Deleted_at;

            return departament;
        }
    }
}
