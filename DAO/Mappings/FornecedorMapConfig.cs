using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class FornecedorMapConfig : EntityTypeConfiguration<FornecedorDTO>
    {
         public FornecedorMapConfig()
         {
            this.ToTable("FORNECEDORES");
            this.Property(f => f.CNPJ).IsFixedLength().HasMaxLength(18);
            this.Property(f => f.Fornecedor).HasMaxLength(100);
            this.HasIndex(f => f.CNPJ).IsUnique(true).HasName("UQ_FORNECEDOR_CNPJ");
            this.Property(f => f.Email).HasMaxLength(100);
         }
    }
}
