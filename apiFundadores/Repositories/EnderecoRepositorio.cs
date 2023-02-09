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
            return await _dBCOntext.Fornecedores.ToListAsync();
        }

        public async Task<EnderecoModel> GetFornecedor(int id)
        {
            return await _dBCOntext.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<EnderecoModel> AddFornecedor(EnderecoModel fornecedor)
        {
            await _dBCOntext.Fornecedores.AddAsync(fornecedor);
            await _dBCOntext.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<bool> DeleteFornecedor(int id)
        {
            EnderecoModel fornecedorPorId = await GetFornecedor(id);
            if (fornecedorPorId == null)
                throw new Exception("Fornecedor nao encontrado");
            _dBCOntext.Fornecedores.Remove(fornecedorPorId);
            await _dBCOntext.SaveChangesAsync();
            return true;


        }

        public async Task<EnderecoModel> EditFornecedor(EnderecoModel fornecedor)
        {
            EnderecoModel fornecedorPorId = await GetFornecedor(fornecedor.Id);
            if (fornecedorPorId == null)
                throw new Exception("Fornecedor nao encontrado");

            fornecedorPorId.Telefone = fornecedor.Telefone;
            fornecedorPorId.Nome = fornecedor.Nome;
            fornecedorPorId.Cnpj = fornecedor.Cnpj;
            fornecedorPorId.Email = fornecedor.Email;

            _dBCOntext.Fornecedores.Update(fornecedorPorId);
            await _dBCOntext.SaveChangesAsync();

            return fornecedorPorId;

        }


    }
}
