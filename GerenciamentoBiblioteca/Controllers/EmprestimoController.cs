using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBiblioteca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public EmprestimoController(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmprestimoModel>>> BuscarTodosEmprestimos()
        {
            List<EmprestimoModel> emprestimo = await _emprestimoRepositorio.BuscarTodosEmprestimos();
            return Ok(emprestimo);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<EmprestimoModel>> BuscarPorId(int id)
        {
            EmprestimoModel emprestimo = await _emprestimoRepositorio.BuscarPorId(id);
            return Ok(emprestimo);
        }

        [HttpPost]

        public async Task<ActionResult<EmprestimoModel>> Adicionar([FromBody] EmprestimoModel emprestimoModel)
        {
            EmprestimoModel emprestimo = await _emprestimoRepositorio.Adicionar(emprestimoModel);
            return Ok(emprestimo);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<EmprestimoModel>> Atualizar(int id, [FromBody] EmprestimoModel emprestimoModel)
        {
            emprestimoModel.Id = id;
            EmprestimoModel emprestimo = await _emprestimoRepositorio.Atualizar(emprestimoModel, id);
            return Ok(emprestimo);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<EmprestimoModel>> Apagar(int id)
        {
            bool apagado = await _emprestimoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
