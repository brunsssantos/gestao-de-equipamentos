using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

// Regras de negócio
public class Equipamento : EntidadeBase
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public string fabricante;
    public DateTime dataFabricacao;

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Equipamento equipamentoAtualizado =(Equipamento)registroAtualizado;

        this.nome = equipamentoAtualizado.nome;
        this.fabricante = equipamentoAtualizado.fabricante;
        this.dataFabricacao = equipamentoAtualizado.dataFabricacao;
        this.precoAquisicao = equipamentoAtualizado.precoAquisicao;
        this.numeroSerie = equipamentoAtualizado.numeroSerie;

    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome))
            erros += "O campo \"Nome\" é obrigatório.\n";

        else if (nome.Length < 3)
            erros += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

        if (precoAquisicao <= 0)
            erros += "O campo \"Preço de Aquisição\" deve ser maior que zero.\n";

        if (dataFabricacao > DateTime.Now)
            erros += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

        return erros;
    }
}

