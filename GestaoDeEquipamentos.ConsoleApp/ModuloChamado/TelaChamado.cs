using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        public RepositorioEquipamento repositorioEquipamento;
        public RepositorioChamado repositorioChamado;
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

            repositorioChamado.CadastrarRegistro(chamado);

            Console.WriteLine($"\nChamado: \"{chamado.titulo}\" cadastrado com sucesso");
            Console.ReadLine();
        }

        public void EditarRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("Edição de Chamados");
            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine("Digite o id do chamado que deseja selecionar:");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Chamado chamadoAtualizado = ObterDados();

            bool conseguiuEditar = repositorioChamado.EditarChamado(idSelecionado, chamadoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o chamado selecionado");
                Console.ReadLine();

                return;
            }
            Console.WriteLine($"\nEquipamento: \"{chamadoAtualizado.titulo}\" editado com sucesso");
            Console.ReadLine();
        }

        public void ExcluirRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("Exclusão de Chamados");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine("Digite o id do registro que deseja selecionar:");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            bool conseguiuExluir = repositorioChamado.ExcluirChamado(idSelecionado);

            if (!conseguiuExluir)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado");
                Console.ReadLine();

                return;
            }
            Console.WriteLine($"\nChamado excluído com sucesso");
            Console.ReadLine();
        }

        public void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualizaçao de Chamados");
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20}",
                "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
            );

            Chamado[] chamados = repositorioChamado.SelecionarChamados();

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado c = chamados[i];

                if (c == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20}",
                    c.id, c.titulo, c.descricao, c.dataAbertura.ToShortDateString, c.equipamento.nome
                );

                Console.ReadLine();
            }
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

            Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarRegistroPorId(idEquipamento);

            Chamado chamado = new Chamado();
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura; 
            chamado.equipamento = equipamentoSelecionado;

            return chamado;

        }

        public void VisualizarEquipamentos()
        {
            Console.WriteLine("Visualizaçao de Equipamentos");
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} ",
                "Id", "Nome", "Preço de Aquisição", "Nro. Série", "Fabricante", "Data Fabricação"
            );

            EntidadeBase[] equipamentos = repositorioEquipamento.SelecionarRegistros();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = (Equipamento)equipamentos[i];

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
