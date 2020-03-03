using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoriaService
    {
        Task Insert(CategoriaDTO categoria);
        Task Update(CategoriaDTO categoria);
        Task Delete(CategoriaDTO categoria);
        Task<List<CategoriaDTO>> GetCategories(int page, int size);
        Task<CategoriaDTO> GetCategorieByID(int id);
    }
}