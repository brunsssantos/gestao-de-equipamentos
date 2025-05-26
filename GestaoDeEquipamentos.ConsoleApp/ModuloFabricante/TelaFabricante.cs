using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        private RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioF)
        {
            repositorioFabricante = repositorioF;
        }
        private void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine();
        }
        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastro de Fabricante");
            Console.WriteLine("2 - Visualizar Fabricantes");
            Console.WriteLine("3 - Editar Fabricante");
            Console.WriteLine("3 - Excluir Fabricante");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public void CadastrarFabricante()
        {
            ExibirCabecalho();  

            Console.WriteLine("Cadastro de Fabricantes");
            Console.WriteLine();

            Fabricante novoFabricante = ObterDados();

            string erros = novoFabricante.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(erros);
                Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine("\nDigite ENTER para contnuar...");
                Console.ReadLine();

                return;
            }

            repositorioFabricante.CadastrarFabricante(novoFabricante);

            Console.WriteLine($"\nFabricante: \"{novoFabricante.nome}\" cadastrado com sucesso");
            Console.ReadLine();
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

            repositorioFabricante.EditarFabricante(idSelecionado, fabricanteAtualizado);

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

            bool conseguiuExluir = repositorioFabricante.ExcluirFabricante(idSelecionado);

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

            Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante f = fabricantes[i];

                if (f == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -10}",
                    f.id, f.nome, f.email, f.telefone
                );

                Console.ReadLine();
            }
        }



        private Fabricante ObterDados()
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
}
