using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class View
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string descripcion { get; set; }

        public string ruta { get; set; }

        public int ModuleId { get; set; }
        public Module module { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }

        public ICollection<Role_View> Role_Views { get; set; }
    }
}
