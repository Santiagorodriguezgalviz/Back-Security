using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {
        public int Id { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public string Primer_aPellido {  get; set; }
        public string Segundo_apellido { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Genero {  get; set; }
        public string Direccion { get; set; }
        public string Tipo_documento { get; set; }
        public string Documento { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }

        public ICollection<User> Users { get; set; }
    }
    
}
