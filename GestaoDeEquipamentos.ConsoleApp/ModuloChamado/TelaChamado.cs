using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        public RepositorioEquipamento repositorioEquipamento;
        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine();
        }
        public char ApresentarMenu()
        {
            ExibirCabecalho();
            Console.WriteLine("1 - Cadastro de Chamado");
            Console.WriteLine("2 - Visualizar Chamados");
            Console.WriteLine("3 - Editar Chamado");
            Console.WriteLine("3 - Excluir Chamado");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("Cadastro de Chamados");

            Console.WriteLine();
            Chamado chamado = ObterDados();

            Console.WriteLine($"\nChamado: \"{chamado.titulo}\" cadastrado com sucesso");
            Console.ReadLine();
        }

        public void EditarRegistros()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistros()
        {
            throw new NotImplementedException();
        }

        public void VisualizarRegistros(bool exibirCabecalho)
        {
            throw new NotImplementedException();
        }
        public Chamado ObterDados()
        {
            Console.WriteLine("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            DateTime dataAbertura = DateTime.Now; // data e hora de agora

            VisualizarEquipamentos();

            Console.WriteLine("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            return null;

        }

        public void VisualizarEquipamentos()
        {
            Console.WriteLine("Visualizaçao de Equipamentos");
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} ",
                "Id", "Nome", "Preço de Aquisição", "Nro. Série", "Fabricante", "Data Fabricação"
            );

            Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamentos();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} ",
                    e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
                );

                Console.ReadLine();
            }
        }
    }
}
