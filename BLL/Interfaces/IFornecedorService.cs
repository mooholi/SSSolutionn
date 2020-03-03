using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFornecedorService
    {
        Task Create(FornecedorDTO fornecedor);
        Task<List<FornecedorDTO>> GetSuppliers(int page, int size);
    }
}
