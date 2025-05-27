using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
public class Chamado : EntidadeBase
{
    public int id;
    public string titulo;
    public string descricao;
    public DateTime dataAbertura;

    public Equipamento equipamento;

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Chamado chamadoAtualizado = (Chamado)registroAtualizado;

        this.titulo = chamadoAtualizado.titulo;
        this.descricao = chamadoAtualizado.descricao;
        this.dataAbertura = chamadoAtualizado.dataAbertura;
        this.equipamento = chamadoAtualizado.equipamento;
    }
}
