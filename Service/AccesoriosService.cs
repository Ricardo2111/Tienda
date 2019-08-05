using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IAccesoriosService
    {
        IEnumerable<Accesorios> GetAll(Accesorios model);
        bool Add(Accesorios modal);
        bool Update(Accesorios model);
        bool Delete(int Id);

    }
    public class AccesoriosService : IAccesoriosService
    {
        private readonly TiendaDbContext _tiendaDbContext;
        public AccesoriosService(
            TiendaDbContext tiendaDbContext
            )
        {
            _tiendaDbContext = tiendaDbContext;

        }
        public IEnumerable<Accesorios> GetAll(Accesorios model)
        {
            var result = new List<Accesorios>();
            try
            {
                result = _tiendaDbContext.accesorios.ToList();

            }
            catch (System.Exception)
            {


            }
            return result;

        }
        public bool Add(Accesorios model)
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

        public bool Update(Accesorios model)
        {
            try
            {
                var originalModel = _tiendaDbContext.accesorios.Single(X =>
                X.Id == model.Id
                );
                originalModel.Nombre = model.Nombre;
                originalModel.Precio = model.Precio;
                originalModel.Cantidad = model.Cantidad;


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
                _tiendaDbContext.Entry(new Accesorios { Id = Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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