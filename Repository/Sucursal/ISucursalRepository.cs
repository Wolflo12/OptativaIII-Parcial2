
using parcial2.Models.Sucursal;


namespace parcial2.Repository.ISucursal
{
    public interface ISucursalRepository
    {
        bool add(SucursalModel sucursalModel);
        bool update(SucursalModel sucursalModel);
        bool delete(int id);
        IEnumerable<SucursalModel> GetAll();
    }
}
