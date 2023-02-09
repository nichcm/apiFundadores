using apiFundadores.Models;

namespace apiFundadores.Repositories.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<FornecedorModel>> GetAllFornecedores();
        Task<FornecedorModel> GetFornecedor(int id);
        Task<FornecedorModel> AddFornecedor(FornecedorModel fornecedor);
        Task<FornecedorModel> EditFornecedor(FornecedorModel fornecedor);
        Task<bool> DeleteFornecedor(int id);
    }
}
