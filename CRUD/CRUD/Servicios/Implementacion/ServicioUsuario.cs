using CRUD.Models;
using CRUD.Servicios.Contratos;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Servicios.Implementacion
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly CrudbContext _dbContext;
        public ServicioUsuario(CrudbContext dbContext) { 
            _dbContext = dbContext; 
        }
        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
           Usuario UsuarioEncontrado = await _dbContext.Usuarios.Where(u=> u.Correo==correo && u.Clave==clave).FirstOrDefaultAsync();
            return UsuarioEncontrado;
        }

        public async Task<Usuario> saveUsuarios(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);    
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
