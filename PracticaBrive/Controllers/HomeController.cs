using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaBrive.Datos;
using PracticaBrive.Models;
using System.Diagnostics;

namespace PracticaBrive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public HomeController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Compra.ToListAsync());
        }

        [HttpGet]
        public IActionResult CrearCompra()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCompra(Compra compra)
        {
            if (!ModelState.IsValid)
            {
                _contexto.Compra.Add(compra);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var compra = _contexto.Compra.Find(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCompra(Compra compra)
        {
            if (!ModelState.IsValid)
            {
                _contexto.Update(compra);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        [HttpGet]
        public IActionResult DetalleCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var compra = _contexto.Compra.Find(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        [HttpGet]
        public IActionResult BorrarCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var compra = _contexto.Compra.Find(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }
        [HttpPost, ActionName("BorrarCompra")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarCom(int? id)
        {
            var compra = await _contexto.Compra.FindAsync(id);
            if (compra == null)
            {
                return View();
            }
            _contexto.Compra.Remove(compra);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}