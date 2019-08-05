

using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

    public interface IConsolaService
    {
        IEnumerable<Consola> GetAll(Consola model);
        bool Add(Consola modal);
        bool Update(Consola model);
        bool Delete(int Id);

    }
    public class ConsolaService : IConsolaService
    {
        private readonly TiendaDbContext _tiendaDbContext;
        public ConsolaService(
            TiendaDbContext tiendaDbContext
            )
        {
            _tiendaDbContext = tiendaDbContext;
        }
        public IEnumerable<Consola> GetAll(Consola model)
        {
            var result = new List<Consola>();
            try
            {
                result = _tiendaDbContext.consolas.ToList();

            }
            catch (System.Exception)
            {


            }
            return result;

        }
        public bool Add(Consola model)
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

        public bool Update(Consola model)
        {
            try
            {
                var originalModel = _tiendaDbContext.consolas.Single(X =>
                X.Id == model.Id
                );
                originalModel.Modelo = model.Modelo;
                originalModel.Precio = model.Precio;
                originalModel.Stock = model.Stock;


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
                _tiendaDbContext.Entry(new Consola { Id = Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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