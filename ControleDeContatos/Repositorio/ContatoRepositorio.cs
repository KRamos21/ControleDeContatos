using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    //como estou impementando (usando) sou obirgado a assinar este contrato
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ContatoRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _applicationDbContext.Contatos.Add(contato);
            _applicationDbContext.SaveChanges();
            return contato;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _applicationDbContext.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int ID)
        {
            return _applicationDbContext.Contatos.FirstOrDefault(x => x.ID == ID);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.ID);
            if (contatoDb == null) throw new System.Exception("Houve um erro de atualização");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _applicationDbContext.Contatos.Update(contatoDb);
            _applicationDbContext.SaveChanges();
            return contatoDb;

        }
    }
}

