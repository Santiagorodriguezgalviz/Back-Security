using Data.Dto;
using Data.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interface
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<ViewDto>> GetAll();
        Task<ViewDto> GetById(int id);
        Task<View> Save(ViewDto entity);
        Task Update(int id, ViewDto entity);
        Task<ViewDto> GetByNombre(string nombre);
    }
}
