using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre_usuario { get; set; }
        public string Contraseña { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public Person person { get; set; }

        public Role role { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
