using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante : TelaBase
{  
    private RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante) : base("Fabricantes", repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
    }

    public void EditarFabricantes()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Fabricantes");
        Console.WriteLine();

        VisualizarFabricantes(false);

        Console.WriteLine("Digite o id do fabricante que deseja selecionar:");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Fabricante fabricanteAtualizado = ObterDados();

        repositorioFabricante.EditarRegistro(idSelecionado, fabricanteAtualizado);

        Console.WriteLine($"\nFabricante: \"{fabricanteAtualizado.nome}\" editado com sucesso");
        Console.ReadLine();
    }

    public void ExcluirFabricantes()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Fabricantes");

        Console.WriteLine();

        VisualizarFabricantes(false);

        Console.WriteLine("Digite o id do fabricante que deseja selecionar:");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExluir = repositorioFabricante.ExcluirRegistro(idSelecionado);

        if (!conseguiuExluir)
        {
            Console.WriteLine("Não foi possível encontrar o fabricante selecionado");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\nFabricante excluído com sucesso");
        Console.ReadLine();
    }

    public void VisualizarFabricantes(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualizaçao de Fabricantes");
        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -10}",
            "Id", "Nome", "E-mail", "Telefone"
        );

        EntidadeBase[] fabricantes = repositorioFabricante.SelecionarRegistros();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Object objetoFabricante = fabricantes[i];

            Fabricante f = (Fabricante)fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.ReadLine();
    }

    protected override Fabricante ObterDados()
    {
        Console.WriteLine("Digite o nome do fabricante: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o e-mail do fabricante: ");
        string email = Console.ReadLine();

        Console.WriteLine("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        return fabricante;
    }
}

