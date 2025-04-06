using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Models;

namespace SmartBuy.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
                return View(categoria);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            return View(categoria);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(categoria);
                await _context.SaveChangesAsync();
                return RedirectToActionPermanent(nameof(Index));
            }
            else return View(categoria);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Categorias == null)
                return NotFound();

            var categoria = await _context.Categorias.Where(x => x.IdCategoria == id).FirstOrDefaultAsync();

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost("excluir/{id:int}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categorias == null)
                return Problem("Categoria � nula");
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria != null && !_context.Produtos.Any(x => x.IdCategoria == id))
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Alerta"] = "";
                return View(categoria);
            }
        }
    }
}
