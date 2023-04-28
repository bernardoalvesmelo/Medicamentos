namespace GerenciamentoMedicamentos.ModuloCompartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }

        protected virtual void ObterId(ref int id)
        {
            id++;
            Id = id;
        }

        public abstract void Atualizar(EntidadeBase entidade);

        public abstract string[] ObterAtributos();

        public abstract EntidadeBase ObterNovaInstancia();
    }
}