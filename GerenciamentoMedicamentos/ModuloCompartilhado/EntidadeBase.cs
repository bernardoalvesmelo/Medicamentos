namespace GerenciamentoMedicamentos.ModuloCompartilhado
{
    public class EntidadeBase
    {
        public int Id { get; protected set; }

        protected void ObterId(ref int id)
        {
            id++;
            Id = id;
        }

        public virtual void Atualizar(EntidadeBase entidade)
        {
            Id = entidade.Id;
        }

        public virtual string[] ObterAtributos()
        {
            string[] atributos = { (Id + "") };
            return atributos;
        }

        public virtual EntidadeBase ObterClasse()
        {
            return new EntidadeBase();
        }
    }
}