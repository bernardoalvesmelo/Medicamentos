using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloRequisicao
{
    public class RepositorioRequisicao : RepositorioBase
    {
        public RepositorioRequisicao()
        {

        }

        public override Requisicao EncontrarRegistro(int id)
        {
            return (Requisicao)base.EncontrarRegistro(id);
        }
    }
}
