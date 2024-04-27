using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SMART.Web.Models;
using SMART.Web.Repositories;
using SMART.Web.ViewModel;

namespace SMART.Web.Controllers
{
    public class EnderecoController : Controller
    {
        RepositoryEndereco _repositoryEndereco = new RepositoryEndereco();
        RepositoryUsuario _repositoryUsuario = new RepositoryUsuario();

        public void CarregaViewBag()
        {
            ViewBag.usuarios = _repositoryUsuario.SelecionarTodos();
        }

        public IActionResult List()
        {
           
            var enderecos = EnderecoVM.ListarEnderecos();
            return View(enderecos);
        }

        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        public IActionResult Edit(int id) 
        {
            CarregaViewBag();
            var endereco = _repositoryEndereco.SelecionarPk(id);
            return View(endereco);
        }

        [HttpPost]
        public IActionResult Edit(Endereco endereco)
        {
            CarregaViewBag();
            _repositoryEndereco.Alterar(endereco);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var endereco = _repositoryEndereco.SelecionarPk(id);
            _repositoryEndereco.Excluir(endereco);
            return RedirectToAction("List");
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Endereco endereco)
        {
            CarregaViewBag();
            _repositoryEndereco.Incluir(endereco);
            return View();
        }

        
    }
}
