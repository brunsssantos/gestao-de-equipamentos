using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado : TelaBase
    {
        public RepositorioEquipamento repositorioEquipamento;
        public RepositorioChamado repositorioChamado;

        public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento) : base("Chamado", repositorioChamado)
        {
            this.repositorioChamado = repositorioChamado;
            this.repositorioEquipamento = repositorioEquipamento;
        }
        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualizaçao de Chamados");
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20}",
                "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
            );

            EntidadeBase[] chamados = repositorioChamado.SelecionarRegistros();

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado c = (Chamado)chamados[i];

                if (c == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20}",
                    c.id, c.titulo, c.descricao, c.dataAbertura.ToShortDateString, c.equipamento.nome
                );

                Console.ReadLine();
            }
        }
        protected override Chamado ObterDados()
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
