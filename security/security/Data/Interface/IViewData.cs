using Data.Dto;
using Data.DTO;
using Data.Implements;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IViewData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<ViewDto>> GetAll();
        public Task<View> GetById(int id);
        public Task<View> Save(View entity);
        public Task Update(View entity);
        public Task<View> GetByName(string nombre);
    }
}
