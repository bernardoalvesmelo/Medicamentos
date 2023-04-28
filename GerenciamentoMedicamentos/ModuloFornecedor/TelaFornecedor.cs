using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloFornecedor
{

    public class TelaFornecedor : TelaBase
    {


        public TelaFornecedor(RepositorioBase repositorio) : base(repositorio)
        {
            titulo = "Fornecedores";
            nomeEntidade = "Fornecedor";
            string[] cabecalho = { "Id:", "Nome:", "CNPJ:", "Telefone:", "Email", "Endereço:" };
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
                        Console.WriteLine("Fornecedor registrado!");
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
                            Console.WriteLine("Fornecedor atualizado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Fornecedor removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
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
            Fornecedor fornecedor = new Fornecedor();
            PreencherAtributos(fornecedor);
            return fornecedor;
        }

        public override void PreencherAtributos(EntidadeBase entidade)
        {
            Fornecedor fornecedor = (Fornecedor)entidade;
            Console.Write("Digite o nome do fornecedor: ");
            string nome = Console.ReadLine();
            fornecedor.Nome = nome;
            Console.Write("Digite o CNPJ do fornecedor: ");
            string cnpj = Console.ReadLine();
            fornecedor.Cnpj = cnpj;
            Console.Write("Digite o telefone do fornecedor: ");
            string telefone = Console.ReadLine();
            fornecedor.Telefone = telefone;
            Console.Write("Digite o email do fornecedor: ");
            string email = Console.ReadLine();
            fornecedor.Email = email;
            Console.Write("Digite o endereço do fornecedor: ");
            string endereco = Console.ReadLine();
            fornecedor.Endereco = endereco;
        }
    }
}
