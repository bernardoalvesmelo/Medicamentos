using System.Collections;
using GerenciamentoMedicamentos.ModuloCompartilhado;
using GerenciamentoMedicamentos.ModuloFornecedor;
using GerenciamentoMedicamentos.ModuloRequisicao;

namespace GerenciamentoMedicamentos.ModuloMedicamento
{
public class Medicamento : EntidadeBase
{
    static private int id = 0;

    public string Nome { get; set; }

    public string Descricao { get; set; }
    public int Quantidade { get; set; }

    public ArrayList Requisicoes { get; set; }
    public int Limite { get; set; }
    public Fornecedor MedicamentoFornecedor { get; set; }

    public int Retiradas
    {
        get
        {
            int soma = 0;
            foreach (Requisicao requisicao in Requisicoes)
            {
                soma += requisicao.QuantidadeMedicamento;
            }
            return soma;
        }
    }

    public Medicamento()
    {
        ObterId(ref id);
    }

    public override string[] ObterAtributos()
    {
        string[] atributos = {(Id + ""), Nome, Descricao, (Quantidade + ""),(Retiradas + ""),
       (Limite + ""), MedicamentoFornecedor.Nome};
        return atributos;
    }

    public override void Atualizar(EntidadeBase entidade)
    {
        Medicamento medicamento = (Medicamento)entidade;
        Nome = medicamento.Nome;
        Descricao = medicamento.Descricao;
        Limite = medicamento.Limite;
        MedicamentoFornecedor = medicamento.MedicamentoFornecedor;
    }

    public override EntidadeBase ObterClasse()
    {
        return new Medicamento();
    }

}
}