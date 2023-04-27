using System.Collections;
using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase
    {
        public RepositorioMedicamento()
        {

        }

        public ArrayList ObterMedicamentosDisponiveis()
        {
            ArrayList medicamentos = new ArrayList();
            foreach (Medicamento medicamento in Lista)
            {
                if (medicamento.Quantidade > 0)
                {
                    medicamentos.Add(medicamento);
                }
            }
            return medicamentos;
        }
        public ArrayList ObterMedicamentosEmFalta()
        {
            ArrayList medicamentos = new ArrayList();
            foreach (Medicamento medicamento in Lista)
            {
                if (medicamento.Limite > medicamento.Quantidade)
                {
                    medicamentos.Add(medicamento);
                }
            }
            return medicamentos;
        }

        public ArrayList ObterMedicamentosRequisitados()
        {
            ArrayList ListaOrdenada = (ArrayList)Lista.Clone();
            ListaOrdenada.Sort(new ComparadorMedicamento());
            return ListaOrdenada;
        }
    }

    public class ComparadorMedicamento : IComparer
    {
        public int Compare(object? a, object? b)
        {
            Medicamento x = (Medicamento)a;
            Medicamento y = (Medicamento)b;
            return y.Retiradas.CompareTo(x.Retiradas);
        }
    }
}
