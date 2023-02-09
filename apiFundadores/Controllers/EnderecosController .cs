using apiFundadores.Models;
using apiFundadores.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace apiFundadores.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecosController(IEnderecoRepositorio enderecoRepositorio) 
        {
            _enderecoRepositorio = enderecoRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<EnderecoModel>>> GetAll()
        {
            List<EnderecoModel> enderecos = await _enderecoRepositorio.GetAllEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoModel>> GetById(int id)
        {
            EnderecoModel fornecedor = await _enderecoRepositorio.GetEndereco(id);
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoModel>> CreateFornecedor([FromBody]EnderecoModel fornecedorModel)
        {
            EnderecoModel fornecedor = await _enderecoRepositorio.AddEndereco(fornecedorModel);
            return Ok(fornecedor);
        }

        [HttpPut]
        public async Task<ActionResult<EnderecoModel>> EditFornecedor([FromBody] EnderecoModel fornecedorModel)
        {
            EnderecoModel fornecedor = await _enderecoRepositorio.EditEndereco(fornecedorModel);
            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoModel>> DeleteById(int id)
        {
            return Ok(await _enderecoRepositorio.DeleteEndereco(id));
        }

    }
}
