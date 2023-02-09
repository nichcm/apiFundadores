namespace apiFundadores.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }

        public int? FornecedorModelId { get; set; }
        public virtual FornecedorModel FornecedorModel { get; set; }
    }
}
