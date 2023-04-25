using GerenciamentoMedicamentos.ModuloCompartilhado;
using GerenciamentoMedicamentos.ModuloFornecedor;
using GerenciamentoMedicamentos.ModuloFuncionario;
using GerenciamentoMedicamentos.ModuloMedicamento;

namespace GerenciamentoMedicamentos.ModuloAquisicao
{
    public class Aquisicao : EntidadeBase
    {
        static private int id = 0;

        public Fornecedor AquisicaoFornecedor { get; set; }
        public Medicamento AquisicaoMedicamento { get; set; }
        public Funcionario AquisicaoFuncionario { get; set; }

        public DateTime Data { get; set; }
        public int QuantidadeMedicamento { get; set; }

        public Aquisicao()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos =
            {
            (Id + ""),
            AquisicaoFornecedor.Nome,
            AquisicaoMedicamento.Nome,
            AquisicaoFuncionario.Nome,
            Data.ToString("dd/MM/yyyy"),
            (QuantidadeMedicamento + "")
        };
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Aquisicao aquisicao = (Aquisicao)entidade;
            AquisicaoFornecedor = aquisicao.AquisicaoFornecedor;
            AquisicaoFuncionario = aquisicao.AquisicaoFuncionario;
        }

        public override EntidadeBase ObterClasse()
        {
            return new Aquisicao();
        }
    }
}