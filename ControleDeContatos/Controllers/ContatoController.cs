using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            //Injetar o contatoRepositorio
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int ID)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(ID);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            //Injetar o contatoRepositorio
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(int ID)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(ID);
            return View(contato);
        }

        public IActionResult Apagar(int ID)
        {
            _contatoRepositorio.Apagar(ID);
            return RedirectToAction("Index");
        }

    }
}
