
using parcial2.Models.Cliente;

namespace parcial2.Repository.ICliente
{
    public interface IClienteRepository
    {
        bool add(ClienteModel clienteModelo);
        bool update(ClienteModel clienteModelo);
        bool delete(int id);
        IEnumerable<ClienteModel> GetAll();
    }
}
