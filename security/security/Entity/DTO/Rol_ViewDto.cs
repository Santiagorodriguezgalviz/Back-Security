using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class Rol_ViewDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ViewId { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }


    }
}
