using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Todo
{
    public class EditarTodoViewModel
    {
        public EditarTodoViewModel()
        {
            Pessoas = new List<SelectListItem>();
        }

        public Entities.Todo Todo { get; set; }
        public List<SelectListItem> Pessoas { get; set; }
        public int idPessoa { get; set; }
    }
}
