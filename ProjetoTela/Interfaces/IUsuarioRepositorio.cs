using ProjetoTela.Models;

namespace ProjetoTela.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Login Validar(string email, string senha);

        void Adicionar(Login usuario);
    }
}