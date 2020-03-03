using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    class ProdutoMapConfig : EntityTypeConfiguration<ProdutoDTO>
    {
        public ProdutoMapConfig()
        {
            this.ToTable("PRODUTOS");
            this.Property(p => p.Descricao).HasMaxLength(150);

            this.HasRequired(c => c.Categoria).WithMany(c => c.Produtos).HasForeignKey(c => c.CategoriaID).WillCascadeOnDelete(false);
        }
    }
}
