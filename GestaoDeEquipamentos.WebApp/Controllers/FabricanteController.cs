using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class FabricanteController : Controller
{

    private RepositorioFabricanteEmArquivo repositorioFabricante;

    public FabricanteController()
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
    }

    public IActionResult Index()
    {
        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        return View(fabricantes);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(string nome, string email, string telefone)
    {
        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        if (fabricanteSelecionado == null)
            return RedirectToAction(nameof(Index));

        return View(fabricanteSelecionado);
    }

    [HttpPost]
    public IActionResult Editar(int id, string nome, string email, string telefone)
    {
        Fabricante fabricanteEditado = new Fabricante(nome, email, telefone);

        bool edicaoConcluida = repositorioFabricante.EditarRegistro(id, fabricanteEditado);

        if (!edicaoConcluida)
        {

            fabricanteEditado.Id = id;

            return View(fabricanteEditado);
        }

        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        if (fabricanteSelecionado == null)
            return RedirectToAction(nameof(Index));

        return View(fabricanteSelecionado);
    }

    [HttpPost]
    public IActionResult ExcluirConfirmado(int id)
    {
        repositorioFabricante.ExcluirRegistro(id);

       return RedirectToAction(nameof(Index));
    }
}
