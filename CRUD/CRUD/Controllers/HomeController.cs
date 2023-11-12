using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CRUD.Models.ViewModels;
using System.Collections.Generic;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly CrudbContext  _dbcontext;

        public HomeController(CrudbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task <IActionResult> Index()
        {
            List<Producto> lista = await _dbcontext.Productos.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Detalle_Producto(int id)
        {
            var productoVM = new ProductoVM();

            if (id != 0)
            {
                productoVM.oproducto = _dbcontext.Productos.FirstOrDefault(e => e.Id == id);
            }
            else
            {
                productoVM.oproducto = new Producto();
            }

            return View(productoVM);
        }

        [HttpPost]
        public async Task<IActionResult> Detalle_Producto(ProductoVM oproductovm)
        {
            if (ModelState.IsValid)
            {
                if (oproductovm.oproducto.Id == 0)
                {
                    await _dbcontext.AddAsync(oproductovm.oproducto);
                }
                else
                {
                    _dbcontext.Update(oproductovm.oproducto);
                }

                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // El modelo no es válido, vuelve a mostrar el formulario con errores
                return View(oproductovm);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Producto oproducto = _dbcontext.Productos.FirstOrDefault(e => e.Id == id);
            if (oproducto == null)
            {
                // Manejo de producto no encontrado
                return NotFound();
            }
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto oproducto)
        {
            if (oproducto == null)
            {
                // Manejo de producto no encontrado
                return NotFound();
            }

            _dbcontext.Productos.Remove(oproducto);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}


    
