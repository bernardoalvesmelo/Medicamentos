using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase
    {
        static private int id = 0;

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
        public string Endereco { get; set; }

        public Fornecedor()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, Cnpj, Telefone, Email, Endereco };
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Fornecedor fornecedor = (Fornecedor)entidade;
            Nome = fornecedor.Nome;
            Cnpj = fornecedor.Cnpj;
            Telefone = fornecedor.Telefone;
            Email = fornecedor.Email;
            Endereco = fornecedor.Endereco;
        }

        public override EntidadeBase ObterNovaInstancia()
        {
            return new Fornecedor();
        }

    }
}