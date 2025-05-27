
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

    public class RepositorioFabricante : RepositorioBase
    {
        private Fabricante[] fabricantes = new Fabricante[100];
        private int contadorFabricantes = 0;
    }