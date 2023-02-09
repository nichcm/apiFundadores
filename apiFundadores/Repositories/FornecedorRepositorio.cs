using apiFundadores.Data;
using apiFundadores.Models;
using apiFundadores.Models.dto;
using apiFundadores.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace apiFundadores.Repositories
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private SistemaDBCOntext _dBCOntext;
        public FornecedorRepositorio(SistemaDBCOntext sistemaTarefasDBCOntext) 
        {
            _dBCOntext = sistemaTarefasDBCOntext;
        }

        public async Task<List<FornecedorModel>> GetAllFornecedores(FilterFornecedoresDto filterFornecedoresDto)
        {
            List<FornecedorModel> lista = await _dBCOntext.Fornecedores.ToListAsync();
            if(filterFornecedoresDto.Nome != null)
                lista.Where(x => x.Nome == filterFornecedoresDto.Nome);

            if (filterFornecedoresDto.CNPJ != null)
                lista.Where(x => x.Cnpj == filterFornecedoresDto.CNPJ);

            if (filterFornecedoresDto.Cidade != null)
            {
                foreach(var item in lista)
                {
                    item.EnderecoModels.Select(a => a.Cidade == filterFornecedoresDto.Cidade);
                }
            }
            return lista;
        }

        public async Task<FornecedorModel> GetFornecedor(int id)
        {
            return await _dBCOntext.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FornecedorModel> AddFornecedor(FornecedorModel fornecedor)
        {
            await _dBCOntext.Fornecedores.AddAsync(fornecedor);
            await _dBCOntext.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<bool> DeleteFornecedor(int id)
        {
            FornecedorModel fornecedorPorId = await GetFornecedor(id);
            if (fornecedorPorId == null)
                throw new Exception("Fornecedor nao encontrado");
            _dBCOntext.Fornecedores.Remove(fornecedorPorId);
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

            _dBCOntext.Fornecedores.Update(fornecedorPorId);
            await _dBCOntext.SaveChangesAsync();

            return fornecedorPorId;

        }


    }
}
