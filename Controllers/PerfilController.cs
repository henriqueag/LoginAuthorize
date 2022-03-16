using LoginAuthorize.ViewModel;
using System.Security.Claims;
using System.Web.Mvc;
using System.Linq;
using LoginAuthorize.Data;
using LoginAuthorize.Utilitarios;

namespace LoginAuthorize.Controllers
{
    public class PerfilController : Controller
    {
        private readonly AppDbContext _context = new AppDbContext();

        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identity = User.Identity as ClaimsIdentity;
            var username = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Username == username);

            if (Hash.GerarHash(viewModel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                return View();
            }

            usuario.Senha = Hash.GerarHash(viewModel.NovaSenha);
            _context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            TempData["Mensagem"] = "Senha alterada com sucesso.";

            return RedirectToAction("Index", "Painel");
        }
    }
}