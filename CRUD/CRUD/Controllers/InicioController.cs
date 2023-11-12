using CRUD.Models;
using CRUD.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD.Controllers
{
    public class InicioController : Controller
    {
        private readonly IServicioUsuario _serviciousuario;
        public InicioController(IServicioUsuario serviciusuario) {
              _serviciousuario = serviciusuario;
        }
        public IActionResult Registrar()
        {

            return View();
        }
        
        [HttpPost] 
         
        public async Task <IActionResult> Registrar(Usuario modelo)
        {
            
            
                Usuario usuario_creado = await _serviciousuario.saveUsuarios(modelo);


                if (usuario_creado.Id > 0)
                    return RedirectToAction("IniciarSesion", "Inicio");


                ViewData["mensaje"] = "no se pudo iniciarseccion";

               
            
             
            
            return View();
        }
        
        
        [HttpPost]
        public async Task <IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuario_creado = await _serviciousuario.GetUsuarios(correo,clave);
            if(usuario_creado == null)
            {
                ViewData["mensaje"] = "no se encontarron usuarios";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           



            return View();
        }
        public async Task <IActionResult> IniciarSesion()
        {
           


            return View();
        }
    }
}
