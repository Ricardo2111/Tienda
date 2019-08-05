using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service 
{
    public interface ICompraCService
    {
    IEnumerable<Compra_Consola> GetAll(Compra_Consola model);
    bool Add(Compra_Consola modal);
    bool Update(Compra_Consola model);
    bool Delete(int Id);

}
public class CompraCService : ICompraCService
    {
    private readonly TiendaDbContext _tiendaDbContext;
    public CompraCService(
        TiendaDbContext tiendaDbContext
        )
    {
        _tiendaDbContext = tiendaDbContext;
    }
    public IEnumerable<Compra_Consola> GetAll(Compra_Consola model)
    {
        var result = new List<Compra_Consola>();
        try
        {
            result = _tiendaDbContext.compra_Consolas.ToList();

        }
        catch (System.Exception)
        {


        }
        return result;

    }
    public bool Add(Compra_Consola model)
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

    public bool Update(Compra_Consola model)
    {
        try
        {
            var originalModel = _tiendaDbContext.compra_Consolas.Single(X =>
            X.Id == model.Id
            );
            originalModel.ClienteID = model.ClienteID;
            originalModel.ConsolaID = model.ConsolaID;
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
            _tiendaDbContext.Entry(new Compra_Consola { Id = Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
