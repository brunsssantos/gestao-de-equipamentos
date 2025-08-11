using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloFabricante;

public class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>
{
    public RepositorioFabricanteEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Fabricante> ObterRegistros()
    {
        return contexto.Fabricantes;
    }
}
