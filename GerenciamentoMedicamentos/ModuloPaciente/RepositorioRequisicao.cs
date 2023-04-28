using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase
    {
        public RepositorioPaciente()
        {

        }

        public override Paciente EncontrarRegistro(int id)
        {
            return (Paciente)base.EncontrarRegistro(id);
        }
    }
}