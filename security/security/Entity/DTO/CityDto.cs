using Entity.Model.Security;
using System;

namespace Data.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int DepartmentId { get; set; }
        public Departament Departament { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
