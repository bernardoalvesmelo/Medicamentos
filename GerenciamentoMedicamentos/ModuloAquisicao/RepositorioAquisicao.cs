using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloAquisicao
{
    public class RepositorioAquisicao : RepositorioBase
    {
        public RepositorioAquisicao()
        {

        }

        public override Aquisicao EncontrarRegistro(int id)
        {
            return (Aquisicao)base.EncontrarRegistro(id);
        }
    }
}