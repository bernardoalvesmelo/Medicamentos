using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        static private int id = 0;

        public string Nome { get; set; }
        public string Cpf { get; set; }


        public string Cartao { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Paciente()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, Cpf, Cartao, Telefone, Endereco };
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Paciente paciente = (Paciente)entidade;
            Nome = paciente.Nome;
            Cpf = paciente.Cpf;
            Cartao = paciente.Cartao;
            Telefone = paciente.Telefone;
            Endereco = paciente.Endereco;
        }

        public override EntidadeBase ObterNovaInstancia()
        {
            return new Paciente();
        }

    }
}