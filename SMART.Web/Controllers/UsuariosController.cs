using Microsoft.AspNetCore.Mvc;
using SMART.Web.Models;
using SMART.Web.Repositories;

namespace SMART.Web.Controllers
{
    public class UsuariosController : Controller
    {
        RepositoryUsuario _repositoryUsuario = new RepositoryUsuario();
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            _repositoryUsuario.Incluir(usuario);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var usuario = _repositoryUsuario.SelecionarPk(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            _repositoryUsuario.Alterar(usuario);
            return View();
        }

        public IActionResult List() 
        {
            var usuarios = _repositoryUsuario.SelecionarTodos();
            return View(usuarios);
        }

        public IActionResult Delete(int id)
        {
            var usuario = _repositoryUsuario.SelecionarPk(id);
            _repositoryUsuario.Excluir(usuario);
            return RedirectToAction("List");
        }



    }
}
