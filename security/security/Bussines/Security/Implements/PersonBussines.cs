using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implementations;
using Data.Implements;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implemetations
{
    public class PersonBusiness : IPersonBussines
    {
        private readonly IPersonData data;

        public PersonBusiness(IPersonData data)
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
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<PersonDto> GetById(int id)
        {
            var person = await data.GetById(id);

            return new PersonDto
            {
                Id = person.Id,
                Primer_nombre = person.Primer_nombre,
                Segundo_nombre = person.Segundo_nombre,
                Primer_aPellido = person.Primer_aPellido,
                Segundo_apellido = person.Segundo_apellido,
                Email = person.Email,
                Fecha_nacimiento = person.Fecha_nacimiento,
                Genero = person.Genero,
                Direccion = person.Direccion,
                Tipo_documento = person.Tipo_documento,
                Documento = person.Documento
            };


        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person persona = new Person();
            persona = this.mapearDatos(persona, entity);

            return await data.Save(persona);
        }

        public async Task Update(int Id, PersonDto entity)
        {
            Person person = await this.data.GetById(Id);
            if (person == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            person = this.mapearDatos(person, entity);

            await this.data.Update(person);
        }

        public async Task<Person> GetByFirst_name(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(firstName));

            return await data.GetByFirst_name(firstName);
        }

        private Person mapearDatos(Person persona, PersonDto entity)
        {
            persona.Id = entity.Id;
            persona.Primer_nombre = entity.Primer_nombre;
            persona.Segundo_nombre = entity.Segundo_nombre;
            persona.Primer_aPellido = entity.Primer_aPellido;
            persona.Segundo_apellido = entity.Segundo_apellido;
            persona.Email = entity.Email;
            persona.Fecha_nacimiento = entity.Fecha_nacimiento;
            persona.Genero = entity.Genero;
            persona.Direccion = entity.Direccion;
            persona.Tipo_documento = entity.Tipo_documento;
            persona.Documento = entity.Documento;
            persona.State = entity.State;


            return persona;
        }

    
    }
}
