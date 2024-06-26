﻿
using System.Data;
using Dapper;
using Npgsql;
using parcial2.Bdd;
using parcial2.Models.Sucursal;
using parcial2.Repository.ISucursal;

namespace parcial2.Repository.Sucursal
{
    public class SucursalRepository : ISucursalRepository
    {
        NpgsqlConnection connection;

        public SucursalRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(SucursalModel sucursalModel)
        {
            try
            {
                connection.Execute("INSERT INTO Sucursal(descripcion, direccion, telefono, whatsapp, mail, estado) " +
                $"Values(@descripcion, @direccion, @telefono, @whatsapp, @mail, @estado)", sucursalModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            return connection.Query<SucursalModel>("SELECT * FROM sucursal");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM sucursal WHERE id = {id}");
            return true;
        }

        public bool update(SucursalModel sucursalModel)
        {
            try
            {
                connection.Execute("UPDATE Sucursal SET " +
                    " descripcion=@descripcion, " +
                    " direccion=@direccion, " +
                    " telefono=@telefono, " +
                    " whatsapp=@whatsapp, " +
                    " mail=@mail, " +
                    " estado=@estado " +
                    $" WHERE  id = @id", sucursalModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
