using parcial2.Bdd;
using parcial2.Models.Factura;
using Dapper;
using System.Data;
using parcial2.Repository.IFactura;
using Npgsql;

namespace parcial2.Repository.Factura
{
    public class FacturaRepository : IFacturaRepository
    {
        NpgsqlConnection connection;

        public FacturaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(FacturaModel facturaModel)
        {
            try
            {
                connection.Execute("INSERT INTO Factura(Nro_factura, Fecha_hora, Total, Total_iva5, Total_iva10, Total_iva, Total_letras) " +
                    $"Values(@nro_factura, @fecha_hora, @total, @total_iva5, @total_iva10, @total_iva, @total_letras)", facturaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            return connection.Query<FacturaModel>("SELECT * FROM factura");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM factura WHERE id = {id}");
            return true;
        }

        public bool update(FacturaModel facturaModel)
        {
            try
            {
                connection.Execute("UPDATE Factura SET " +
                    " nro_factura=@nro_factura, " +
                    " fecha_hora=@fecha_hora, " +
                    " total=@total, " +
                    " total_iva5=@total_iva5, " +
                    " total_iva10=@total_iva10, " +
                    " total_iva=@total_iva " +
                    " total_letras=@total_letras " +
                    $" WHERE  id = @id", facturaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
