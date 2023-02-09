using apiFundadores.Data;
using apiFundadores.Models;
using apiFundadores.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiFundadores.Repositories
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private SistemaDBCOntext _dBCOntext;
        public EnderecoRepositorio(SistemaDBCOntext sistemaTarefasDBCOntext) 
        {
            _dBCOntext = sistemaTarefasDBCOntext;
        }

        public async Task<List<EnderecoModel>> GetAllEnderecos()
        {
            return await _dBCOntext.Enderecos.ToListAsync();
        }

        public async Task<EnderecoModel> GetEndereco(int id)
        {
            return await _dBCOntext.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<EnderecoModel> AddEndereco(EnderecoModel endereco)
        {
            await _dBCOntext.Enderecos.AddAsync(endereco);
            await _dBCOntext.SaveChangesAsync();

            return endereco;
        }

        public async Task<bool> DeleteEndereco(int id)
        {
            EnderecoModel enderecoPorId = await GetEndereco(id);
            if (enderecoPorId == null)
                throw new Exception("Endereco nao encontrado");
            _dBCOntext.Enderecos.Remove(enderecoPorId);
            await _dBCOntext.SaveChangesAsync();
            return true;


        }

        public async Task<EnderecoModel> EditEndereco(EnderecoModel endereco)
        {
            EnderecoModel enderecoPorId = await GetEndereco(endereco.Id);
            if (enderecoPorId == null)
                throw new Exception("Endereco nao encontrado");

            enderecoPorId.Cep = endereco.Cep;
            enderecoPorId.Rua = endereco.Rua;
            enderecoPorId.Complemento = endereco.Complemento;
            enderecoPorId.Cidade = endereco.Cidade;
            enderecoPorId.Estado = endereco.Estado;
            enderecoPorId.Pais = endereco.Pais;

            _dBCOntext.Enderecos.Update(enderecoPorId);
            await _dBCOntext.SaveChangesAsync();

            return enderecoPorId;

        }


    }
}
