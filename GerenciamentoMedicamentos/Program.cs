using GerenciamentoMedicamentos.ModuloAquisicao;
using GerenciamentoMedicamentos.ModuloCompartilhado;
using GerenciamentoMedicamentos.ModuloFornecedor;
using GerenciamentoMedicamentos.ModuloFuncionario;
using GerenciamentoMedicamentos.ModuloMedicamento;
using GerenciamentoMedicamentos.ModuloPaciente;
using GerenciamentoMedicamentos.ModuloRequisicao;

namespace GerenciamentoMedicamentos
{
    internal class Program
    {
        static RepositorioBase repositorioPaciente = new RepositorioBase();
        static TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
        static RepositorioBase repositorioFornecedor = new RepositorioBase();
        static TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
        static RepositorioBase repositorioFuncionario = new RepositorioBase();
        static TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
        static RepositorioBase repositorioMedicamento = new RepositorioBase();
        static TelaMedicamento telaMedicamento = new TelaMedicamento(
            repositorioMedicamento,
            telaFornecedor
        );
        static RepositorioBase repositorioAquisicao = new RepositorioBase();
        static TelaAquisicao telaAquisicao = new TelaAquisicao(
            repositorioAquisicao,
            telaFornecedor,
            telaFuncionario,
            telaMedicamento
        );
        static RepositorioBase repositorioRequisicao = new RepositorioBase();
        static TelaRequisicao telaRequisicao = new TelaRequisicao(
            repositorioRequisicao,
            telaPaciente,
            telaFuncionario,
            telaMedicamento
        );

        static public void Main(string[] args)
        {
            LoginOpcoes();
        }

        static void Opcoes()
        {
            bool continuar = true;
            string[] opcoes =
            {
            "Gerenciamento do Posto de Saúde",
            "0-Sair",
            "1-Cadastrar Paciente",
            "2-Cadastrar Fornecedor",
            "3-Cadastrar Funcionário",
            "4-Cadastrar Medicamento",
            "5-Cadastrar Aquisição",
            "6-Cadastrar Requisição"
        };
            while (continuar)
            {
                MostrarMenu(opcoes);
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        continuar = false;
                        break;
                    case "1":
                        telaPaciente.Opcoes();
                        break;
                    case "2":
                        telaFornecedor.Opcoes();
                        break;
                    case "3":
                        telaFuncionario.Opcoes();
                        break;
                    case "4":
                        telaMedicamento.Opcoes();
                        break;
                    case "5":
                        telaAquisicao.Opcoes();
                        break;
                    case "6":
                        telaRequisicao.Opcoes();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        static void LoginOpcoes()
        {
            bool continuar = true;
            string[] opcoes = { "Tela de Login", "0-Sair", "1-Realizar Login", };
            string[] opcoesEntrada = { "Tela de Login", "0-Sair", "1-Cadastrar Login", };
            while (continuar)
            {
                if (telaFuncionario.Quantidade > 0)
                {
                    MostrarMenu(opcoes);
                }
                else
                {
                    MostrarMenu(opcoesEntrada);
                }
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        continuar = false;
                        break;
                    case "1":
                        if (telaFuncionario.Quantidade > 0)
                        {
                            RealizarLogin();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Insira as informações do funcionário!");
                            Console.WriteLine("Atenção com login e senha!");
                            Console.ReadLine();
                            repositorioFuncionario.InserirRegistro(telaFuncionario.RegistrarEntidade());
                        }
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        public static void RealizarLogin()
        {
            Funcionario funcionario = telaFuncionario.VerificarLogin();
            if (funcionario == null)
            {
                Console.WriteLine("Usuário (login) e/ou senha não reconhecidos!");
                Console.ReadLine();
                return;
            }
            TelaBase.funcionarioLogado = funcionario;
            Opcoes();
        }

        static void MostrarMenu(string[] menu)
        {
            Console.Clear();
            foreach (string opcao in menu)
            {
                Console.WriteLine(opcao);
            }

            Console.Write("Digite a opção desejada: ");
        }
    }
}