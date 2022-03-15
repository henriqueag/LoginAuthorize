using LoginAuthorize.Data;
using LoginAuthorize.Models;
using LoginAuthorize.ViewModel;
using System.Web.Mvc;
using LoginAuthorize.Utilitarios;
using System.Data.Entity.Validation;
using System.Linq;

namespace LoginAuthorize.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AppDbContext _context = new AppDbContext();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (_context.Usuarios.Count(model => model.Username == viewModel.Username) > 0)
            {
                ModelState.AddModelError("Username", "Esse nome de usuário já está em uso");
                return View(viewModel);
            }

            Usuario user = new Usuario
            {
                Nome = viewModel.Nome,
                Username = viewModel.Username,
                Senha = Hash.GerarHash(viewModel.Senha)
            };
            _context.Usuarios.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}