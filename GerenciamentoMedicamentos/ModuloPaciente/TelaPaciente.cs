using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloPaciente
{

    public class TelaPaciente : TelaBase
    {


        public TelaPaciente(RepositorioBase repositorio) : base(repositorio)
        {
            titulo = "Pacientes";
            nomeEntidade = "Paciente";
            string[] cabecalho = { "Id:", "Nome:", "CPF:", "Cartão do SUS:", "Telefone", "Endereço:" };
            Cabecalho = cabecalho;
        }

        public void Opcoes()
        {
            while (true)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Paciente registrado!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorio.Lista.Count > 0)
                        {
                            AtualizarEntidade();
                            Console.WriteLine("Paciente atualizado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe pacientes registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Paciente removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe pacientes registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public override EntidadeBase RegistrarEntidade()
        {
            Paciente paciente = new Paciente();
            PreencherAtributos(paciente);
            return paciente;
        }

        public override void PreencherAtributos(EntidadeBase entidade)
        {
            Paciente paciente = (Paciente)entidade;
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();
            paciente.Nome = nome;
            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();
            paciente.Cpf = cpf;
            Console.Write("Digite o cartão do SUS do paciente: ");
            string cartao = Console.ReadLine();
            paciente.Cartao = cartao;
            Console.Write("Digite o telefone do paciente: ");
            string telefone = Console.ReadLine();
            paciente.Telefone = telefone;
            Console.Write("Digite o endereço do paciente: ");
            string endereco = Console.ReadLine();
            paciente.Endereco = endereco;
        }
    }
}