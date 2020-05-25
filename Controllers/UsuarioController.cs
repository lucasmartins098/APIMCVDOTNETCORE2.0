using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudmysql.Models;
using Microsoft.CodeAnalysis.Semantics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using System.Text;

namespace crudmysql.Controllers
{
    [DisableCors]
    public class UsuarioController : Controller
    {
        private readonly LivroContexto _context;

        public UsuarioController(LivroContexto context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuario/Autenticar/teste&teste
        public async Task<IActionResult> Autenticar(string usuario, string senha)
        {
            var ObjtUsuario = _context.Usuario.Where(m => m.Login == usuario && m.Senha == senha).FirstOrDefault();

            if (ObjtUsuario == null)
            {
                return NotFound();
            }

            return Json(ObjtUsuario);
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Usuario
                .SingleOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return Json(livro);

            //return View(livro);
        }

        public async Task<IActionResult> TodosUsuario()
        {

            var livro = await _context.Usuario
                .SingleOrDefaultAsync();
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        //// GET: Usuario/Create
        //public IActionResult Create()
        //{


        //    return View();
        //}


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //POST: Livros/Create
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLixo([FromBody]Lixo record)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(record.image);

            return Json(record);
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string teste, string nomeRazaoSocial, string email, string telefone,
                                                string login, string senha, byte[] imagemPerfil, bool coletor, string CEP, string estado,
                                                string municipio, string bairro, string rua, string complemento)
        {
            Usuario usuario = new Usuario();
            ConfiguracaoPerfil configuracaoPerfil = new ConfiguracaoPerfil();
            Endereco endereco = new Endereco();
            Endereco_Usuario endereco_Usuario = new Endereco_Usuario();

            try
            {
                var sevenItems = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                configuracaoPerfil.imagemPerfil = sevenItems;
                configuracaoPerfil.TipoPerfil = (coletor) ? (byte)2 : (byte)1;
                _context.Add(configuracaoPerfil);
                await _context.SaveChangesAsync();

                usuario.NomeRazaoSocial = nomeRazaoSocial;
                usuario.Email = email;
                usuario.Telefone = telefone;
                usuario.Login = login;
                usuario.Senha = senha;
                usuario.DataCadastro = DateTime.Now;
                usuario.ConfiguracaoPerfil_ID = configuracaoPerfil.Id;

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                _context.Add(endereco);
                await _context.SaveChangesAsync();

                endereco_Usuario.Endereco_Id = endereco.Id;
                endereco_Usuario.Usuario_ConfiguracaoPerfil_Id = configuracaoPerfil.Id;
                endereco_Usuario.Usuario_Id = usuario.Id;
                endereco_Usuario.Bairro = bairro;
                endereco_Usuario.Estado = estado;
                endereco_Usuario.CEP = CEP;
                endereco_Usuario.Complemento = complemento;
                endereco_Usuario.Rua = rua;
                endereco_Usuario.Municipio = municipio;

                _context.Add(endereco_Usuario);
                await _context.SaveChangesAsync();

            }
            catch (ArgumentException e)
            {
                var erroMensage = e.Message;
                var erroInner = e.InnerException;

            }
            return Json(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Usuario.SingleOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string nome)
        {
            //if (id != livro.Id)
            //{
            //    return NotFound();
            //}

            var livro = await _context.Usuario
                .SingleOrDefaultAsync(m => m.Id == id);

            livro.NomeRazaoSocial = nome;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Usuario
                .SingleOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Usuario/Delete/5
        // [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Usuario.SingleOrDefaultAsync(m => m.Id == id);
            _context.Usuario.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool LivroExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }

    public class Lixo
    {
        public string Residuo { get; set; }
        public string image { get; set; }
        public string DescricaoResiduo { get; set; }
    }

}
