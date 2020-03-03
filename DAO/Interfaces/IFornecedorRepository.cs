using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IFornecedorRepository 
    {
        Task Create(FornecedorDTO fornecedor);
        Task<List<FornecedorDTO>> GetFornecedors();

    }
}
