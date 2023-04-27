
using System.Collections;
using GerenciamentoMedicamentos.ModuloCompartilhado;
using GerenciamentoMedicamentos.ModuloFornecedor;

namespace GerenciamentoMedicamentos.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase
    {
        private TelaFornecedor telaFornecedor;
        private RepositorioMedicamento repositorioMedicamento;

        public TelaMedicamento(RepositorioMedicamento repositorio, TelaFornecedor telaFornecedor) : base(repositorio)
        {
            repositorioMedicamento = repositorio;
            titulo = "Medicamentos:";
            string[] cabecalho = {"Id:","Nome:","Descrição:","Quantidade:",
        "Retiradas:","Limite:","Fornecedor:"};
            Cabecalho = cabecalho;
            this.telaFornecedor = telaFornecedor;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Medicamento",
            "0-Sair",
            "1-Registrar Medicamento",
            "2-Mostrar Medicamentos",
            "3-Atualizar Medicamento",
            "4-Remover Medicamento",
            "5-Mostrar Medicamentos Requisitados",
            "6-Mostrar Medicamentos em Falta"
        };
            while (true)
            {
                MostrarMenu(opcoes);
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        if (telaFornecedor.Quantidade > 0)
                        {
                            repositorioMedicamento.InserirRegistro(RegistrarEntidade());
                            Console.WriteLine("Medicamento registrado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorioMedicamento.Lista.Count > 0)
                        {
                            if (telaFornecedor.Quantidade > 0)
                            {
                                AtualizarEntidade();
                                Console.WriteLine("Medicamento atualizado!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Não existe fornecedores registrados no sistema!");
                                Console.ReadLine();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Não existe medicamentos registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorioMedicamento.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Medicamento removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe medicamentos registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        MostrarMedicamentosRequisitados();
                        Console.ReadLine();
                        break;
                    case "6":
                        MostrarMedicamentosEmFalta();
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
            Medicamento medicamento = new Medicamento();
            PreencherAtributos(medicamento);
            return medicamento;
        }

        public override void PreencherAtributos(EntidadeBase entidade)
        {
            Medicamento medicamento = (Medicamento)entidade;
            Fornecedor fornecedor = (Fornecedor)telaFornecedor.ValidarId();
            medicamento.MedicamentoFornecedor = fornecedor;
            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();
            medicamento.Nome = nome;
            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();
            medicamento.Descricao = descricao;
            int limite = ValidarInt("Digite o número limite do medicamento: ");
            medicamento.Limite = limite;
            medicamento.Quantidade = 0;
            medicamento.Requisicoes = new ArrayList();
        }

        public EntidadeBase ValidarIdDisponivel()
        {
            EntidadeBase entidade;
            while (true)
            {
                MostrarMedicamentosDisponiveis();
                int indice = ValidarInt("Digite o id: ");
                entidade = repositorioMedicamento.EncontrarRegistro(indice, repositorioMedicamento.ObterMedicamentosDisponiveis());
                if (entidade == null)
                {
                    Console.WriteLine("O id escolhido não está disponível!");
                    Console.ReadLine();
                    continue;
                }
                return entidade;
            }
        }

        public ArrayList ObterMedicamentosDisponiveis()
        {
            return (ArrayList)repositorioMedicamento.ObterMedicamentosDisponiveis().Clone();
        }

        public void MostrarMedicamentosDisponiveis()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Medicamento medicamento in repositorioMedicamento.ObterMedicamentosDisponiveis())
            {
                foreach (string atributo in medicamento.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }

        public void MostrarMedicamentosEmFalta()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Medicamento medicamento in repositorioMedicamento.ObterMedicamentosEmFalta())
            {
                foreach (string atributo in medicamento.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }

        public void MostrarMedicamentosRequisitados()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Medicamento medicamento in repositorioMedicamento.ObterMedicamentosRequisitados())
            {
                foreach (string atributo in medicamento.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }
    }
}