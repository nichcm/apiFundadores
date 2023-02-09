using apiFundadores.Models;
using apiFundadores.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace apiFundadores.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedoresController(IFornecedorRepositorio fornecedorRepositorio) 
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<FornecedorModel>>> GetAll()
        {
            List<FornecedorModel> fornecedores = await _fornecedorRepositorio.GetAllFornecedores();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorModel>> GetById(int id)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.GetFornecedor(id);
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorModel>> CreateFornecedor([FromBody]FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.AddFornecedor(fornecedorModel);
            return Ok(fornecedor);
        }

        [HttpPut]
        public async Task<ActionResult<FornecedorModel>> EditFornecedor([FromBody] FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.EditFornecedor(fornecedorModel);
            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorModel>> DeleteById(int id)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.GetFornecedor(id);
            return Ok(fornecedor);
        }

    }
}
