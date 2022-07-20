using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaBrive.Datos;
using PracticaBrive.Models;
using System.Diagnostics;

namespace PracticaBrive.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public SucursalesController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Sucursal.ToListAsync());
        }

        [HttpGet]
        public IActionResult CrearSucursal()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearSucursal(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _contexto.Sucursal.Add(sucursal);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarSucursal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sucursal = _contexto.Sucursal.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarSucursal(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(sucursal);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursal);
        }

        [HttpGet]
        public IActionResult DetalleSucursal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sucursal = _contexto.Sucursal.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);
        }

        [HttpGet]
        public IActionResult BorrarSucursal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sucursal = _contexto.Sucursal.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);
        }
        [HttpPost, ActionName("BorrarSucursal")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarSuc(int? id)
        {
            var sucursal = await _contexto.Sucursal.FindAsync(id);
            if (sucursal == null)
            {
                return View();
            }
            _contexto.Sucursal.Remove(sucursal);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
