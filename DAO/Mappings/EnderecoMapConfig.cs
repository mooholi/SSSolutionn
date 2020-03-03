using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    class EnderecoMapConfig : ComplexTypeConfiguration<Endereco>
    {
        public EnderecoMapConfig()
        {
            this.Property(e => e.Bairro).HasMaxLength(50);
            this.Property(e => e.CEP).IsFixedLength().HasMaxLength(9);
            this.Property(e => e.Cidade).HasMaxLength(70);
            this.Property(e => e.Complemento).IsOptional().HasMaxLength(200);
            this.Property(e => e.Numero).HasMaxLength(6);
            this.Property(e => e.UF).IsFixedLength().HasMaxLength(2);
            this.Property(e => e.Rua).HasMaxLength(100);
        }
    }
}
