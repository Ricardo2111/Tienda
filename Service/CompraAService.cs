using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface ICompraAService
    {
        IEnumerable<Compra_Accesorio> GetAll(Compra_Accesorio model);
        bool Add(Compra_Accesorio modal);
        bool Update(Compra_Accesorio model);
        bool Delete(int Id);

    }
    public class CompraAService: ICompraAService
    {
        private readonly TiendaDbContext _tiendaDbContext;
        public CompraAService(
            TiendaDbContext tiendaDbContext
            )
        {
            _tiendaDbContext = tiendaDbContext;
        }
        public IEnumerable<Compra_Accesorio> GetAll(Compra_Accesorio model)
        {
            var result = new List<Compra_Accesorio>();
            try
            {
                result = _tiendaDbContext.compra_Accesorios.ToList();

            }
            catch (System.Exception)
            {


            }
            return result;

        }
        public bool Add(Compra_Accesorio model)
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

        public bool Update(Compra_Accesorio model)
        {
            try
            {
                var originalModel = _tiendaDbContext.compra_Accesorios.Single(X =>
                X.Id == model.Id
                );
                originalModel.ClienteID = model.ClienteID;
                originalModel.AccesoriosID = model.AccesoriosID;
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
                _tiendaDbContext.Entry(new Compra_Accesorio { Id = Id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
