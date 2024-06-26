﻿
using parcial2.Bdd;
using parcial2.Models.Cliente;
using Dapper;
using System.Data;
using parcial2.Repository.ICliente;
using Npgsql;


namespace parcial2.Repository.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        NpgsqlConnection connection;

        public ClienteRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(ClienteModel clienteModel)
        {
            try
            {
                connection.Execute("INSERT INTO Cliente(Nombre, Apellido, Documento, Direccion, Mail, Celular, Estado) " +
                $"Values(@nombre, @apellido, @documento, @direccion, @mail, @celular, @estado)", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return connection.Query<ClienteModel>("SELECT * FROM Cliente");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Cliente WHERE id = {id}");
            return true;
        }

        public bool update(ClienteModel clienteModel)
        {
            try
            {
                connection.Execute("UPDATE Cliente SET " +
                    " nombre=@nombre, " +
                    " apellido=@apellido, " +
                    " documento=@documento, " +
                    " direccion=@direccion, " +
                    " mail=@mail, " +
                    " celular=@celular " +
                    " estado=@estado " +
                    $" WHERE  id = @id", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
