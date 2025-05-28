using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

// Apresentação
public class TelaEquipamento
{
    private RepositorioEquipamento repositorioEquipamento;
    private RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(
        RepositorioEquipamento repositorioEquipamento,
        RepositorioFabricante repositorioFabricante
    ) : base("Equipamento", repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioFabricante = repositorioFabricante;
    }
    public Equipamento ObterDados()
    {
        Console.WriteLine("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o preço de aquisição do equipamento: ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o número de série do equipamento: ");
        string numeroSerie = Console.ReadLine();

        Console.WriteLine("Digite o nome do fabricante do equipamento: ");
        string fabricante = Console.ReadLine();

        VisualizarFabricantes();

        Console.WriteLine("Digite o id do fabricante do equipamento: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteSelecionado = (Fabricante)repositorioFabricante.SelecionarRegistroPorId(idFabricante);

        Console.WriteLine("Digite a data de fabricação do equipamento: ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisicao = precoAquisicao;
        equipamento.numeroSerie = numeroSerie;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = dataFabricacao;

        return equipamento;
    }

    private void VisualizarFabricantes()
    {
        Console.WriteLine();

        Console.WriteLine("Visualização de Fabricantes");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Nome", "Email", "Telefone"
        );

        EntidadeBase[] fabricantes = repositorioFabricante.SelecionarRegistros();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = (Fabricante)fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualizaçao de Equipamentos");
        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} ",
            "Id", "Nome", "Preço de Aquisição", "Nro. Série", "Fabricante", "Data Fabricação"
        );

        EntidadeBase[] equipamentos = repositorioEquipamento.SelecionarRegistros();

        for ( int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e =  (Equipamento)equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -20} | {5, -15} ",
                e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
            );

            Console.ReadLine();
        }
    }

    public void EditarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Equipamentos");
        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar:");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Equipamento equipamentoAtualizado = ObterDados();

        bool conseguiuEditar = repositorioEquipamento.EditarRegistro(idSelecionado, equipamentoAtualizado); 

        if(!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\nEquipamento: \"{equipamentoAtualizado.nome}\" editado com sucesso");
        Console.ReadLine();
    }
}

