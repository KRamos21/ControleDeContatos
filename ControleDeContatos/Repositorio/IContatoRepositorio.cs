using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);

        List<ContatoModel> BuscarTodos();

        ContatoModel ListarPorId(int ID);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int ID);
    }
}
