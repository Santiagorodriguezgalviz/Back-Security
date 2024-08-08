using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class User_RoleDto
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public Role role { get; set; }

        public int UserId { get; set; }

        public User user { get; set; }

        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }

    }
}
