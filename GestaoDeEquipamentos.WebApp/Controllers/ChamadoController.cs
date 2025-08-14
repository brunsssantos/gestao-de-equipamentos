using GestaoDeChamados.WebApp.Models;
using GestaoDeEquipamentos.Dominio.ModuloChamado;
using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloChamado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloEquipamento;
using GestaoDeEquipamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class ChamadoController : Controller
{
    private RepositorioChamadoEmArquivo repositorioChamado;
    private RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public ChamadoController()
    {
        ContextoDados contexto = new ContextoDados(true);

        this.repositorioChamado = new RepositorioChamadoEmArquivo(contexto);
        this.repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
    }

    public IActionResult Index()
    {
        List<Chamado> chamados = repositorioChamado.SelecionarRegistros();

        VisualizarChamadosViewModel visualizarVm = new VisualizarChamadosViewModel(chamados);

        return View(visualizarVm);
    }

    public IActionResult Cadastrar()
    {
        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        CadastrarChamadoViewModel cadastrarVm = new CadastrarChamadoViewModel(equipamentos);

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarChamadoViewModel cadastrarVm)
    {
        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(cadastrarVm.EquipamentoId);

        if (equipamentoSelecionado == null)
            return RedirectToAction(nameof(Index));

        Chamado novoChamado = new Chamado(
            cadastrarVm.Titulo,
            cadastrarVm.Descricao,
            cadastrarVm.DataAbertura,
            equipamentoSelecionado
        );

        repositorioChamado.CadastrarRegistro(novoChamado);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Editar(int id) // como mostra as informações no formulário
    {

        Chamado chamadoSelecionado = repositorioChamado.SelecionarRegistroPorId(id);

        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        EditarChamadoViewModel editarVm = new EditarChamadoViewModel(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo,
            chamadoSelecionado.Descricao,
            chamadoSelecionado.DataAbertura,
            chamadoSelecionado.Equipamento.Id,
            equipamentos

        );

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(int id, EditarChamadoViewModel editarVm) // para salvar as modifições/de fato atualizar
    {

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(editarVm.EquipamentoId);

        Chamado chamadoEditado = new Chamado(
            editarVm.Descricao,
            editarVm.Descricao,
            editarVm.DataAbertura,
            equipamentoSelecionado
        );

        repositorioChamado.EditarRegistro(id, chamadoEditado);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excluir(int id)
    {

        Chamado chamadoSelecionado = repositorioChamado.SelecionarRegistroPorId(id);

        ExcluirChamadoViewModel excluirVm = new ExcluirChamadoViewModel(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo
        );

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult ExcluirConfirmado(int id)
    {
        repositorioChamado.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }
}
