using System.Globalization;
using GerenciamentoMedicamentos.ModuloFuncionario;

namespace GerenciamentoMedicamentos.ModuloCompartilhado
{
    public class TelaBase
    {
        protected RepositorioBase repositorio;
        protected string titulo;
        protected string nomeEntidade;

        public static Funcionario funcionarioLogado;
        public int Quantidade
        {
            get { return repositorio.Lista.Count; }
        }
        public string[] Cabecalho { get; protected set; }

        public TelaBase(RepositorioBase repositorio)
        {
            this.repositorio = repositorio;
            titulo = "Entidades";
            nomeEntidade = "Entidade";
            string[] cabecalho = { "Id:" };
            Cabecalho = cabecalho;
        }
        public virtual EntidadeBase RegistrarEntidade()
        {
            EntidadeBase entidade = new EntidadeBase();
            PreencherAtributos(entidade);
            return entidade;
        }

        public void MostrarEntidades()
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
            foreach (EntidadeBase entidade in repositorio.Lista)
            {
                foreach (string atributo in entidade.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }

        public void AtualizarEntidade()
        {
            EntidadeBase entidadeAtualizada = ValidarId();
            int id = entidadeAtualizada.Id;
            entidadeAtualizada = entidadeAtualizada.ObterClasse();
            PreencherAtributos(entidadeAtualizada);
            repositorio.EditarRegistro(entidadeAtualizada, id);
        }

        public virtual void PreencherAtributos(EntidadeBase entidade)
        {
            entidade.Atualizar(entidade);
            Console.WriteLine('d');
        }

        public void RemoverEntidade()
        {
            EntidadeBase entidade = ValidarId();
            repositorio.RemoverRegistro(entidade);
        }

        public EntidadeBase ValidarId()
        {
            EntidadeBase entidade;
            while (true)
            {
                MostrarEntidades();
                int indice = ValidarInt("Digite o id: ");
                entidade = repositorio.EncontrarRegistro(indice);
                if (entidade == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return entidade;
            }
        }
        public void MostrarMenu()
        {
            Console.Clear();
            foreach (string opcao in ObterOpcoes())
            {
                Console.WriteLine(opcao);
            }
            Console.Write("Digite a opção desejada: ");
        }

        protected int ValidarInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();
                int numero;
                if (Int32.TryParse(valor, out numero))
                {
                    return numero;
                }
                Console.WriteLine("Digite apenas um número inteiro!");
                Console.ReadLine();
            }
        }

        protected DateTime ValidarData(string mensagem)
        {
            DateTime data;
            while (true)
            {
                Console.Write(mensagem);
                string dataInput = Console.ReadLine();
                if (
                    DateTime.TryParseExact(
                        dataInput,
                        "dd/MM/yyyy",
                        new CultureInfo("pt-BR"),
                        DateTimeStyles.None,
                        out data
                    )
                )
                {
                    return data;
                }
                else
                {
                    Console.WriteLine("Digite a data no formato dd/mm/yyyy!");
                    Console.ReadLine();
                }
            }
        }

        protected virtual string[] ObterOpcoes()
        {
            string[] opcoes =
            {
            "Tela Aquisição",
            "0-Sair",
            $"1-Registrar {this.nomeEntidade}",
            $"2-Mostrar {this.titulo}",
            $"3-Editar {this.nomeEntidade}",
            $"4-Remover {this.nomeEntidade}",
            };
            return opcoes;
        }
    }
}