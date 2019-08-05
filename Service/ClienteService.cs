using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll(Cliente model);
        bool Add(Cliente modal);
        bool Update(Cliente model);
        bool Delete(int Id);

    }
    public class ClienteService : IClienteService
    {
        private readonly TiendaDbContext _tiendaDbContext;
        public ClienteService(
            TiendaDbContext tiendaDbContext
            ) {
            _tiendaDbContext = tiendaDbContext;
        }

        public IEnumerable<Cliente> GetAll(Cliente model)
        {
            var result = new List<Cliente>();
            try
            {
                result = _tiendaDbContext.clientes.ToList();

            }
            catch (System.Exception)
            {

                
            }
            return result;

        }
        public bool Add(Cliente model)
        {
            try
            {
                _tiendaDbContext.Add(model);
                _tiendaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;
            }
            return true;

        }

        public bool Update(Cliente model)
        {
            try
            {
                var originalModel = _tiendaDbContext.clientes.Single(X =>
                X.Id == model.Id
                );
                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.Cedula = model.Cedula;


                _tiendaDbContext.Update(originalModel);
                _tiendaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;
            }
            return true;

        }

        public bool Delete(int Id)
        {
            try
            {
                _tiendaDbContext.Entry(new Cliente {Id=Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _tiendaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;
            }
            return true;

        }


    } 

}
