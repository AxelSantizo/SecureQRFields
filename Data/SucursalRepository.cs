using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SecureQRFields.Models;

namespace SecureQRFields.Data
{
    public class SucursalRepository
    {
        private readonly string _connectionString;

        public SucursalRepository()
        {
            // Datos fijos para conexión a dbsucursales
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "172.30.1.27",
                Port = 3306,
                UserID = "compras",
                Password = "bode.24451988",
                Database = "dbsucursales"
            };

            _connectionString = builder.ConnectionString;
        }

        public List<SucursalConnectionInfo> ObtenerSucursales()
        {
            var lista = new List<SucursalConnectionInfo>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT NombreSucursal, serverr, databasee, Uid, Pwd 
                                 FROM sucursales 
                                 WHERE Activo = 1 AND TipoSucursal <= 3 
                                 ORDER BY NombreSucursal";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new SucursalConnectionInfo
                        {
                            NombreSucursal = reader.GetString("NombreSucursal"),
                            Server = reader.GetString("serverr"),
                            Database = reader.GetString("databasee"),
                            Uid = reader.GetString("Uid"),
                            Pwd = reader.GetString("Pwd")
                        });
                    }
                }
            }

            return lista;
        }
    }
}
