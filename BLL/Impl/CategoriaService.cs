using BLL.Interfaces;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        public async Task Insert(CategoriaDTO categoria)
        {
            #region VALIDAÇÃO NOME
            if (string.IsNullOrWhiteSpace(categoria.Nome))
            {
                base.AddError("A categoria deve ser informada.", "Categoria");
            }
            else
            {
                categoria.Nome = categoria.Nome.Trim();
                if (categoria.Nome.Length < 5 || categoria.Nome.Length > 40)
                {
                    base.AddError("O nome da categoria deve conter entre 5 e 40 caracteres.", "Categoria");
                }
            }
            #endregion

            base.CheckErrors();

            #region VALIDAÇÃO ERROS
            try
            {
                using (SSContext context = new SSContext())
                {
                    context.Categoria.Add(categoria);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate do administrador.");
            }
            #endregion
        }

        public async Task Update(CategoriaDTO categoria)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(CategoriaDTO categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoriaDTO>> GetCategories(int page, int size)
        {
            try
            {
                using (SSContext context = new SSContext())
                {
                    //List<ClienteDTO> clientes = context.Clientes.ToListAsync();
                    //return clientes;
                    return await context.Categoria.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate do administrador.");
            }
        }

        public async Task<CategoriaDTO> GetCategorieByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}