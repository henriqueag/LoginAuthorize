using LoginAuthorize.Data;
using LoginAuthorize.Models;
using LoginAuthorize.ViewModel;
using System.Web.Mvc;
using LoginAuthorize.Utilitarios;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace LoginAuthorize.Controllers
{
    public class AutenticacaoController : Controller
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

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue o login.";

            return RedirectToAction(nameof(Login));
        }

        public ActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                UrlRemota = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Username == viewModel.Username);
            if (usuario is null)
            {
                ModelState.AddModelError("Username", "Nome de usuário inválido");
                return View(viewModel);
            }
            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Username)
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!string.IsNullOrWhiteSpace(viewModel.UrlRemota) || Url.IsLocalUrl(viewModel.UrlRemota))
                return Redirect(viewModel.UrlRemota);
            else
                return RedirectToAction("Index", "Painel");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

    }
}