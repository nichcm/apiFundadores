using apiFundadores.Models;
using apiFundadores.Models.dto;

namespace apiFundadores.Repositories.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<FornecedorModel>> GetAllFornecedores(FilterFornecedoresDto filterFornecedoresDto);
        Task<FornecedorModel> GetFornecedor(int id);
        Task<FornecedorModel> AddFornecedor(FornecedorModel fornecedor);
        Task<FornecedorModel> EditFornecedor(FornecedorModel fornecedor);
        Task<bool> DeleteFornecedor(int id);
    }
}
