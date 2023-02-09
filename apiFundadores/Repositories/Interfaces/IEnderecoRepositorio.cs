using apiFundadores.Models;

namespace apiFundadores.Repositories.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<List<EnderecoModel>> GetAllEnderecos();
        Task<EnderecoModel> GetEndereco(int id);
        Task<EnderecoModel> AddEndereco(EnderecoModel fornecedor);
        Task<EnderecoModel> EditEndereco(EnderecoModel fornecedor);
        Task<bool> DeleteEndereco(int id);
    }
}
