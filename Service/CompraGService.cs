using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service 
{
    public interface ICompraGService
    {
    IEnumerable<Compra_Game> GetAll();
    bool Add(Compra_Game modal);
    bool Update(Compra_Game model);
    bool Delete(int Id);
    Compra_Game Get(int Id);

}
public class CompraGService : ICompraGService
    {
    private readonly TiendaDbContext _tiendaDbContext;
    public CompraGService(
        TiendaDbContext tiendaDbContext
        )
    {
        _tiendaDbContext = tiendaDbContext;
    }
    public IEnumerable<Compra_Game> GetAll()
    {
        var result = new List<Compra_Game>();
        try
        {
            result = _tiendaDbContext.compra_Games.ToList();

        }
        catch (System.Exception)
        {


        }
        return result;

    }
        public Compra_Game Get(int Id)
        {
            var result = new Compra_Game();
            try
            {
                result = _tiendaDbContext.compra_Games.Single(x => x.Id == Id);

            }
            catch (System.Exception)
            {


            }
            return result;

        }
        public bool Add(Compra_Game model)
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

    public bool Update(Compra_Game model)
    {
        try
        {
            var originalModel = _tiendaDbContext.compra_Games.Single(X =>
            X.Id == model.Id
            );
            originalModel.ClienteID = model.ClienteID;
            originalModel.GamesID = model.GamesID;
            originalModel.Cantidad = model.Cantidad;
            originalModel.Total = model.Total;


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
            _tiendaDbContext.Entry(new Compra_Game { Id = Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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