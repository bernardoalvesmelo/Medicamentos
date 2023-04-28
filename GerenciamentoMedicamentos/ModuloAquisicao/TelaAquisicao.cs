using GerenciamentoMedicamentos.ModuloCompartilhado;
using GerenciamentoMedicamentos.ModuloFornecedor;
using GerenciamentoMedicamentos.ModuloFuncionario;
using GerenciamentoMedicamentos.ModuloMedicamento;

namespace GerenciamentoMedicamentos.ModuloAquisicao
{

    public class TelaAquisicao : TelaBase
    {
        private TelaFornecedor telaFornecedor;
        private TelaFuncionario telaFuncionario;

        private TelaMedicamento telaMedicamento;

        public TelaAquisicao(RepositorioBase repositorio, TelaFornecedor telaFornecedor, TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento) : base(repositorio)
        {
            titulo = "Aquisições:";
            string[] cabecalho = {"Id:","Fornecedor:","Medicamento:","Funcionário:",
        "Data:","Medicamentos:"};
            Cabecalho = cabecalho;
            this.telaFornecedor = telaFornecedor;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
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
                        if (telaFornecedor.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        if (telaMedicamento.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe medicamentos registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        if (telaFuncionario.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe funcionários registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Aquisição registrada!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
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
            Aquisicao aquisicao = new Aquisicao();
            PreencherAtributos(aquisicao);
            return aquisicao;
        }

        public override void PreencherAtributos(EntidadeBase entidade)
        {
            Aquisicao aquisicao = (Aquisicao)entidade;
            Medicamento medicamento = (Medicamento)telaMedicamento.ValidarId();
            aquisicao.AquisicaoMedicamento = medicamento;
            aquisicao.AquisicaoFornecedor = medicamento.MedicamentoFornecedor;
            Funcionario funcionario = funcionarioLogado;
            aquisicao.AquisicaoFuncionario = funcionario;
            int quantidade = ValidarInt("Digite o número de medicamentos: ");
            aquisicao.QuantidadeMedicamento = quantidade;
            medicamento.Quantidade += quantidade;
            string data = DateTime.Now.ToString("dd/MM/yyyy");
            aquisicao.Data = DateTime.ParseExact(data, "dd/MM/yyyy", null);
        }

        protected override string[] ObterOpcoes()
        {
            string[] opcoes =
            {
            "Tela Aquisição",
            "0-Sair",
            "1-Registrar Aquisição",
            "2-Mostrar Aquisições"
            };
            return opcoes;
        }

    }
}