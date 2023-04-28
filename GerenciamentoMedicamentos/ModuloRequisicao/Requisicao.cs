using System.Collections;
using GerenciamentoMedicamentos.ModuloCompartilhado;
using GerenciamentoMedicamentos.ModuloFuncionario;
using GerenciamentoMedicamentos.ModuloMedicamento;
using GerenciamentoMedicamentos.ModuloPaciente;

namespace GerenciamentoMedicamentos.ModuloRequisicao
{

    public class Requisicao : EntidadeBase
    {
        static private int id = 0;

        public Paciente RequisicaoPaciente { get; set; }
        public Medicamento RequisicaoMedicamento { get; set; }
        public Funcionario RequisicaoFuncionario { get; set; }

        public DateTime Data { get; set; }
        public int QuantidadeMedicamento { get; set; }

        public Requisicao()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = {(Id + ""), RequisicaoPaciente.Nome, RequisicaoMedicamento.Nome, RequisicaoFuncionario.Nome,
        Data.ToString("dd/MM/yyyy"), (QuantidadeMedicamento + "")};
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Requisicao requisicao = (Requisicao)entidade;
            RequisicaoPaciente = requisicao.RequisicaoPaciente;
            RequisicaoFuncionario = requisicao.RequisicaoFuncionario;
        }

        public ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();
            if (QuantidadeMedicamento > RequisicaoMedicamento.Quantidade)
            {
                erros.Add("Digite uma quantidade menor");
            }
            return erros;
        }

        public override EntidadeBase ObterClasse()
        {
            return new Requisicao();
        }

    }
}