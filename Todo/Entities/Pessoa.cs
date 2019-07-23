using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("pessoa")]
    public class Pessoa : EntityBase
    {
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
