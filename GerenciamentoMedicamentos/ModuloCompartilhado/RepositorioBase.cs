namespace GerenciamentoMedicamentos.ModuloCompartilhado
{
    using System.Collections;

    public class RepositorioBase
    {
        public ArrayList Lista { get; protected set; }

        public RepositorioBase()
        {
            this.Lista = new ArrayList();
        }

        public void InserirRegistro(EntidadeBase entidade)
        {
            Lista.Add(entidade);
        }

        public void EditarRegistro(
            EntidadeBase entidadeAtualizada, int id
        )
        {
            EncontrarRegistro(id).Atualizar(entidadeAtualizada);
        }

        public EntidadeBase EncontrarRegistro(int id, ArrayList lista)
        {
            foreach (EntidadeBase entidade in lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public EntidadeBase EncontrarRegistro(int id)
        {
            foreach (EntidadeBase entidade in Lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public void RemoverRegistro(EntidadeBase entidade)
        {
            Lista.Remove(entidade);
        }
    }
}
