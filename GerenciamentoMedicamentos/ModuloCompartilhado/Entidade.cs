namespace GerenciamentoMedicamentos.ModuloCompartilhado
{
    public class Entidade
    {
        public int Id { get; protected set; }

        protected void obterId(ref int id)
        {
            id++;
            Id = id;
        }

        public virtual void Atualizar(Entidade entidade)
        {
            Id = entidade.Id;
        }

        public virtual string[] getAtributos()
        {
            string[] atributos = { (Id + "") };
            return atributos;
        }

        public virtual Entidade getClass()
        {
            return new Entidade();
        }
    }
}