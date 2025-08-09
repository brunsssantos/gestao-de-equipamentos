using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp;
internal class Program
{
    static void Main(string[] args)
    {
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            telaPrincipal.ApresentarMenuPrincipal();

            TelaBase telaEscolhida = telaPrincipal.ObterTela();

            if (telaEscolhida == null)
                break;

            char opcaoEscolhida = telaEscolhida.ApresentarMenu();

            if (opcaoEscolhida == 'S')
                break;

            switch (opcaoEscolhida)
            {
                case '1':
                    telaEscolhida.CadastrarRegistro();
                    break;

                case '2':
                    telaEscolhida.VisualizarRegistros(true);
                    break;
                case '3':
                    telaEscolhida.EditarRegistros();
                    break;
                case '4':
                    telaEscolhida.ExcluirRegistros();
                    break;
            }
        }
    }
}
