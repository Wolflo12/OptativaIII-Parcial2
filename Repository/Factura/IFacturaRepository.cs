
using parcial2.Models.Factura;

namespace parcial2.Repository.IFactura
{
    public interface IFacturaRepository
    {
        bool add(FacturaModel facturaModel);
        bool update(FacturaModel facturaModel);
        bool delete(int id);
        IEnumerable<FacturaModel> GetAll();
    }
}
