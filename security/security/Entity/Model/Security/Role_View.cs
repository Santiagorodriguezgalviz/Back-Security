using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Role_View
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role role { get; set; }
        public int ViewId { get; set; }
        public View view { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }

    }
}
