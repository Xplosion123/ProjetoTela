using ProjetoTela.Models;
using ProjetoTela.Repositorio;

namespace ProjetoTela.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Login? Validar(string email, string senha);
    }
}
