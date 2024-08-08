
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
    public class PersonData : IPersonData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public PersonData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.person.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
               Id,
                CONCAT(Primer_nombre, ' - ', Segundo_nombre) AS TextoMostrar
            FROM 
                [person]
            WHERE /*deleted_at*/ State = 1 /*IS NULL AND estado = 1*/
            ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Primer_nombre,
                Segundo_nombre,
                Primer_aPellido,
                Segundo_apellido,
                Email,
                Fecha_nacimiento,
                Genero,
                Direccion,
                Tipo_documento,
                Documento,
                State
            FROM [person]
           
            ORDER BY Id ASC";

            return await context.QueryAsync<PersonDto>(sql);
        }


        /*public async Task<IEnumerable<PersonaDto>> GetAll()
        {
            var sql = @"SELECT
                p.Id,
                p.primer_apellido,
                p.segundo_apellido,
                p.correo_electronico,
                p.fecha_de_nacimiento,
                p.genero,
                p.direccion,
                p.tipo_de_documento,
                p.documento
            FROM Security.Persona p
            WHERE p.deleted_at IS NULL
            ORDER BY p.Id ASC";

            return await context.QueryAsync<PersonaDto>(sql);
        }
        */

        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM [person] WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }


        public async Task<Person> Save(Person entity)
        {
            context.person.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        /*Task<PagedListDto<PersonaDto>> IPersonaData.GetDataTable(QueryFilterDto filter)
         {
             throw new NotImplementedException();
         }
        */

        public Task<Person> GetByFirst_name(string first_name)
        {
            throw new NotImplementedException();
        }

        
    }
}
