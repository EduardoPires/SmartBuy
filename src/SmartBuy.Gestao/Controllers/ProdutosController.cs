using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Core.Entities;
using SmartBuy.Infrastructure;
using System.Security.Claims;

namespace SmartBuy.Gestao
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly UserManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //nota: melhorar a forma de validar o usuario logado, causando repeti��o de c�digo
            //obtenho o usuario logado no identt no momento
            var user = await _signInManager.GetUserAsync(User);

            //caso o user seja nulo, � pq n�o existe usuario logado. Assim, ir� direcionar para a lista geral de produtos, sen�o, direciona para a lista filtrada por IdVendedor
            if (user == null)
                return View(await _context.Produtos.ToListAsync());
            else
                return View(await _context.Produtos.Where(x => x.IdVendedor.Equals(user.Id)).ToListAsync());

        }

        [AllowAnonymous]
        public async Task<IActionResult> Imagem(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == id);
            if (produto?.Imagem != null)
                return File(produto.Imagem, produto.ImagemMimeType);
            return NotFound();
        }


        public IActionResult Create()
        {
            var produto = new Produto();
            //carregar o combobox de categorias
            CarregarCategorias();
            return View(produto);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] Produto produto, IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                //salvando a imagem
                if (imageUpload != null && imageUpload.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageUpload.CopyToAsync(memoryStream);
                        produto.Imagem = memoryStream.ToArray();
                        produto.ImagemMimeType = imageUpload.ContentType;
                    }
                }

                var usuarioLogado = User.FindFirstValue(ClaimTypes.NameIdentifier);
                produto.IdVendedor = usuarioLogado;
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return View(produto);
        }

        public async Task<IActionResult> Details(int id)
        {
            //obtenho o usuario logado no identt no momento
            var user = await _signInManager.GetUserAsync(User);

            if (_context.Produtos == null)
                return NotFound();

            //pesquisa idvendedor para garantir que o retorno seja somente dos vendedor logado
            var produto = await _context.Produtos.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.IdProduto == id && x.IdVendedor.Equals(user.Id));

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [Route("Produtos/editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            //carregar o combobox de categorias
            CarregarCategorias();
            //obtenho o usuario logado no identt no momento
            var user = await _signInManager.GetUserAsync(User);

            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == id && x.IdVendedor.Equals(user.Id));

            if (produto == null)
                return NotFound();


            return View(produto);

        }

        [HttpPost("Produtos/editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto, Nome, Descricao, Preco, Estoque, IdCategoria, Imagem")] Produto produto, IFormFile imageUpload) 
        { 
            var usuarioLogado = User.FindFirstValue(ClaimTypes.NameIdentifier);
            produto.IdVendedor = usuarioLogado;

            if (id != produto.IdProduto)
                return NotFound();

            if (ModelState.IsValid)
            {
                var produtoOriginal = await _context.Produtos.AsNoTracking()
                    .FirstOrDefaultAsync(p => p.IdProduto == id);

                if (produtoOriginal == null)
                    return NotFound();

                //salvando a imagem
                if (imageUpload != null && imageUpload.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageUpload.CopyToAsync(memoryStream);
                        produto.Imagem = memoryStream.ToArray();
                        produto.ImagemMimeType = imageUpload.ContentType;
                    }
                }
                else
                {
                    produto.Imagem = produtoOriginal.Imagem;
                    produto.ImagemMimeType = produtoOriginal.ImagemMimeType;
                }

                    _context.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToActionPermanent(nameof(Index));
            }
            else return View(produto);
        }

        [Route("Produtos/excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //obtenho o usuario logado no identt no momento
            var user = await _signInManager.GetUserAsync(User);

            if (_context.Produtos == null)
                return NotFound();

            var produto = await _context.Produtos.Where(x => x.IdProduto == id && x.IdVendedor.Equals(user.Id)).FirstOrDefaultAsync();

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost("Produtos/excluir/{id:int}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_context.Produtos == null)
                return Problem("Produto � nulo");
            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private void CarregarCategorias()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome");
        }
    }
}
