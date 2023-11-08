using AwesomeShop.Core.Entities.Orders;
using AwesomeShop.Core.Repositories.Orders;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Data.Common;

namespace AwesomeShop.Infrastructure.Persistence.Repositories.Orders
{
    public class AzureTableOrderRepository : IAzureTableOrderRepository
    {
        private readonly CloudTable _table;

        public AzureTableOrderRepository()
        {
            String connectionString = "DefaultEndpointsProtocol=https;AccountName=arquitectura2023;AccountKey=Ok1Tn1vjZxyrOGt5gNnml2fvC5oReK8x0gLY5THBzNzcLqpwzdQrPqe78Yh5+C5eWGOA5Es/HXdI+AStxeLWiQ==;EndpointSuffix=core.windows.net";
            String tableName = "orders";

            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(tableName);
            _table.CreateIfNotExistsAsync().Wait();
        }

        public async Task<int> Add(Order order)
        {
            try
            {
                TableOperation insertOperation = TableOperation.Insert(order);

                TableResult result = await _table.ExecuteAsync(insertOperation);

                if (result.HttpStatusCode >= 200 && result.HttpStatusCode < 300)
                {
                    // La operación de inserción se realizó con éxito.
                    return 1; // Puedes devolver un valor apropiado para indicar el éxito.
                }
                else
                {
                    // La operación de inserción no se realizó con éxito.
                    return 0; // Puedes devolver un valor apropiado para indicar el error.
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones en caso de error.
                // Puedes registrar el error, lanzar una excepción personalizada, etc.
                return 0; // Otra opción es lanzar una excepción en lugar de devolver un valor.
            }
        }


        public async Task<List<Order>> GetAll()
        {
            // Implementa la lógica para recuperar todos los pedidos de la Azure Table
            // Retorna la lista de pedidos en lugar de datos simulados

            List<Order> orders = new List<Order>(); // Asume que aquí obtienes la lista real de pedidos
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            // Implementa la lógica para recuperar un pedido por su ID desde la Azure Table
            // Retorna el pedido correspondiente en lugar de datos simulados

            Order order = null; // Asume que aquí obtienes el pedido real por su ID
            return order;
        }
    }
}
