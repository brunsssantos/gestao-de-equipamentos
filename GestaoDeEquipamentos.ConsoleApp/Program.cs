namespace GestaoDeEquipamentos.ConsoleApp;
internal class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();

        while (true)
        {
           char opcaoEscolhida = telaEquipamento.ApresentarMenu();

            if (opcaoEscolhida == 'S')
                break;

            switch (opcaoEscolhida)
            {
                case '1':
                    telaEquipamento.CadastrarRegistro();
                    break;
            }
        }
    }
}

public class TelaEquipamento
{
    public char ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;


    }

    public void CadastrarRegistro()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine();

        Console.WriteLine("Cadastro de Equipamentos");

        Console.WriteLine();

        Console.WriteLine("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o preço de aquisição do equipamento: ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o número de série do equipamento: ");
        string numeroSerie = Console.ReadLine();

        Console.WriteLine("Digite o nome do fabricante do equipamento: ");
        string fabricante = Console.ReadLine();

        Console.WriteLine("Digite a data de fabricação do equipamento: ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisicao = precoAquisicao;
        equipamento.numeroSerie = numeroSerie;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = dataFabricacao;

        Console.WriteLine($"\nEquipamento: \"{equipamento.nome}\" cadastrado com sucesso");
        Console.ReadLine();
    }
}

// Regras de negócio
public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public string fabricante;
    public DateTime dataFabricacao;

}

