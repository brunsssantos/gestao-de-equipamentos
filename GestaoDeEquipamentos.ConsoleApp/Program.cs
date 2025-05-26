using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp;
internal class Program
{
    static void Main(string[] args)
    {
        RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante);

        TelaEquipamento telaEquipamento = new TelaEquipamento();
        telaEquipamento.repositorioEquipamento = repositorioEquipamento;

        TelaChamado telaChamado = new TelaChamado();
        telaChamado.repositorioChamado = repositorioChamado;
        telaChamado.repositorioEquipamento = repositorioEquipamento; 

        while (true)
        {
            char telaEscolhida = ApresentarMenuPrincipal();

            if (telaEscolhida == '1')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaEquipamento.CadastrarRegistro();
                        break;

                    case '2':
                        telaEquipamento.VisualizarRegistros(true);
                        break;
                    case '3':
                        telaEquipamento.EditarRegistros();
                        break;
                    case '4':
                        telaEquipamento.ExcluirRegistros();
                        break;
                }
            }

            else if (telaEscolhida == '2')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaChamado.CadastrarRegistro();
                        break;

                    case '2':
                        telaChamado.VisualizarRegistros(true);
                        break;
                    case '3':
                        telaChamado.EditarRegistros();
                        break;
                    case '4':
                        telaChamado.ExcluirRegistros();
                        break;
                }
            }

            else if (telaEscolhida == '3')
            {
                char opcaoEscolhida = telaFabricante.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaFabricante.CadastrarFabricante();
                        break;

                    case '2':
                        telaFabricante.VisualizarFabricantes(true);
                        break;
                    case '3':
                        telaFabricante.EditarFabricantes();
                        break;
                    case '4':
                        telaFabricante.ExcluirFabricantes();
                        break;
                }
            }

        }
    }

    public static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("         Gestão de Equipamentos         ");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Equipamentos");
        Console.WriteLine("2 - Controle de Chamados");
        Console.WriteLine("2 - Controle de Fabricantes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.WriteLine("Escolha uma das opções");
        char opcaoEscolhida = Console.ReadLine()[0];//pegar primeiro caractere

        return opcaoEscolhida;



    }
}

