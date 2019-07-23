using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Repositories;
using Repositories.Interfaces;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public HomeController(ITodoRepository todoRepository, 
                              IPessoaRepository pessoaRepository)
        {
            _todoRepository = todoRepository;
            _pessoaRepository = pessoaRepository;
        }

        public IActionResult Index()
        {
            return View(_todoRepository.GetAll());
        }

        public IActionResult Editar(int id)
        {
            Models.Todo.EditarTodoViewModel vm = new Models.Todo.EditarTodoViewModel();
            vm.Todo = _todoRepository.Get(id);
            
            foreach(var item in _pessoaRepository.GetAll()) {
                vm.Pessoas.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = item.Nome,
                    Value = item.Id.ToString()
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Editar(Models.Todo.EditarTodoViewModel vm)
        {
            _todoRepository.Update(vm.Todo);
            NotificationUtil.Set(TempData, new Notificacao()
            {
                mensagem = "Todo editado com sucesso!",
                status = EnumStatus.success
            });

            return View("Index", _todoRepository.GetAll());
        }

        public IActionResult Cadastrar()
        {
            Models.Todo.EditarTodoViewModel vm = new Models.Todo.EditarTodoViewModel();
            foreach (var item in _pessoaRepository.GetAll())
            {
                vm.Pessoas.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = item.Nome,
                    Value = item.Id.ToString()
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Cadastrar(Models.Todo.EditarTodoViewModel vm)
        {
            _todoRepository.Add(vm.Todo);
            NotificationUtil.Set(TempData, new Notificacao()
            {
                mensagem = "Todo cadastrado com sucesso!",
                status = EnumStatus.success
            });

            return View("Index", _todoRepository.GetAll());
        }

        public IActionResult Remover(int id)
        {
            _todoRepository.Remove(id);
            NotificationUtil.Set(TempData, new Notificacao()
            {
                mensagem = "Todo removido com sucesso!",
                status = EnumStatus.success
            });

            return View("Index", _todoRepository.GetAll());
        }
    }
}
