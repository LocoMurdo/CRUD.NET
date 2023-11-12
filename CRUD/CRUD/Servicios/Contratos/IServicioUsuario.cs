using CRUD.Models;

namespace CRUD.Servicios.Contratos
{
    public interface IServicioUsuario
    {
        Task<Usuario> GetUsuarios(string correo,string clave);
        Task<Usuario> saveUsuarios(Usuario modelo);

    }
}
