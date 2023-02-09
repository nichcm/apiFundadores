using apiFundadores.Data;
using apiFundadores.Models;
using apiFundadores.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiFundadores.Repositories
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private SistemaDBCOntext _dBCOntext;
        public FornecedorRepositorio(SistemaDBCOntext sistemaTarefasDBCOntext) 
        {
            _dBCOntext = sistemaTarefasDBCOntext;
        }

        public async Task<List<FornecedorModel>> GetAllFornecedores()
        {
            return await _dBCOntext.Fonrnecedores.ToListAsync();
        }

        public async Task<FornecedorModel> GetFornecedor(int id)
        {
            return await _dBCOntext.Fonrnecedores.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FornecedorModel> AddFornecedor(FornecedorModel fornecedor)
        {
            await _dBCOntext.Fonrnecedores.AddAsync(fornecedor);
            await _dBCOntext.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<bool> DeleteFornecedor(int id)
        {
            FornecedorModel fornecedorPorId = await GetFornecedor(id);
            if (fornecedorPorId == null)
                throw new Exception("Fornecedor nao encontrado");
            _dBCOntext.Fonrnecedores.Remove(fornecedorPorId);
            await _dBCOntext.SaveChangesAsync();
            return true;


        }

        public async Task<FornecedorModel> EditFornecedor(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorPorId = await GetFornecedor(fornecedor.Id);
            if (fornecedorPorId == null)
                throw new Exception("Fornecedor nao encontrado");

            fornecedorPorId.Telefone = fornecedor.Telefone;
            fornecedorPorId.Nome = fornecedor.Nome;
            fornecedorPorId.Cnpj = fornecedor.Cnpj;
            fornecedorPorId.Email = fornecedor.Email;

            _dBCOntext.Fonrnecedores.Update(fornecedorPorId);
            await _dBCOntext.SaveChangesAsync();

            return fornecedorPorId;

        }


    }
}
