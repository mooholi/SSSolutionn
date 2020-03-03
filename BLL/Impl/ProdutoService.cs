using BLL.Interfaces;
using Common;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task Insert(ProdutoDTO produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Descricao))
            {
                base.AddError("Descricao", "Descrição deve ser informada.");
            }
            else
            {
                produto.Descricao = produto.Descricao.Trim();
                if (produto.Descricao.Length < 5 || produto.Descricao.Length > 150)
                {
                    base.AddError("Descricao", "Descrição deve ter entre 5 e 150 caracteres.");
                }
            }

            if (produto.Preco <= 0)
            {
                base.AddError("Preco", "O preço não pode ser menor ou igual a zero.");
            }
            base.CheckErrors();
            try
            {
                using (SSContext context = new SSContext())
                {
                    context.Produtos.Add(produto);
                    await context.SaveChangesAsync();
                }//context.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco de dados.");
            }
        }

        public Task Update(ProdutoDTO produto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ProdutoDTO produto)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoDTO> GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProdutoDTO>> GetProducts(int page, int size)
        {
            throw new NotImplementedException();
        }


    }
}
