using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

    public interface IGamesService
    {
        IEnumerable<Games> GetAll(Games model);
        bool Add(Games modal);
        bool Update(Games model);
        bool Delete(int Id);

    }
    public class GamesService: IGamesService
    {
        private readonly TiendaDbContext _tiendaDbContext;
        public GamesService(
            TiendaDbContext tiendaDbContext
            )
        {
            _tiendaDbContext = tiendaDbContext;
        }
        public IEnumerable<Games> GetAll(Games model)
        {
            var result = new List<Games>();
            try
            {
                result = _tiendaDbContext.games.ToList();

            }
            catch (System.Exception)
            {


            }
            return result;

        }
        public bool Add(Games model)
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

        public bool Update(Games model)
        {
            try
            {
                var originalModel = _tiendaDbContext.games.Single(X =>
                X.Id == model.Id
                );
                originalModel.Titulo = model.Titulo;
                originalModel.Genero = model.Genero;
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
                _tiendaDbContext.Entry(new Games { Id = Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
