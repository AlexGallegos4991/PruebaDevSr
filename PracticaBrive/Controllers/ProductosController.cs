using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaBrive.Datos;
using PracticaBrive.Models;

namespace PracticaBrive.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public ProductosController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Producto.ToListAsync());
        }

        [HttpGet]
        public IActionResult CrearProducto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            //producto.Sucursal = new Sucursal();
            if (!ModelState.IsValid)
            {
                _contexto.Producto.Add(producto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = _contexto.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                _contexto.Update(producto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        [HttpGet]
        public IActionResult DetalleProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = _contexto.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpGet]
        public IActionResult BorrarProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = _contexto.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        [HttpPost, ActionName("BorrarProducto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarPro(int? id)
        {
            var producto = await _contexto.Producto.FindAsync(id);
            if (producto == null)
            {
                return View();
            }
            _contexto.Producto.Remove(producto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
