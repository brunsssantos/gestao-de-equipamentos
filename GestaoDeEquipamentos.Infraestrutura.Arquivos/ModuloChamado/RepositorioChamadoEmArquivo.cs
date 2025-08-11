using GestaoDeEquipamentos.Dominio.ModuloChamado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloChamado;

public class RepositorioChamadoEmArquivo : RepositorioBaseEmArquivo<Chamado>
{
    public RepositorioChamadoEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Chamado> ObterRegistros()
    {
        return contexto.Chamados;
    }
}
