using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("todo")]
    public class Todo : EntityBase
    {
        [Column("TAREFA")]
        public string Tarefa { get; set; }
        [Column("HORARIO")]
        public string Horario { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
