using Administracion.Repositorio.Contexto;
using Administracion.Utilidades.Autenticacion;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Repositorio
{
    public abstract class BaseRepositorio<T>
       where T : class
    {
        public BaseRepositorio()
        {
        }

        #region Common

        private AdministracionEntities _contexto;

        private AdministracionEntities Contexto
        {
            get
            {
                if (_contexto == null)
                {
                    if (Sesion.ObjetoDeSesion != null)
                    {
                        _contexto = new AdministracionEntities(Sesion.ObjetoDeSesion.Conexion);
                    }
                    else
                    {
                        _contexto = new AdministracionEntities();
                    }
                }
                return _contexto;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_contexto != null)
                {
                    _contexto.Dispose();
                }
            }
        }

        ~BaseRepositorio()
        {
            Dispose(false);
        }

        #endregion

        public void ActivarLazyLoading()
        {
            Contexto.Configuration.ProxyCreationEnabled = true;
        }

        public void DesactivarLazyLoading()
        {
            Contexto.Configuration.ProxyCreationEnabled = false;
        }

        private DbSet<T> ObtenerEntidad()
        {
            return Contexto.Set<T>();
        }

        public IQueryable<T> ObtenerTodos()
        {
            return ObtenerEntidad().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> EncontrarPor(Expression<Func<T, bool>> predicate)
        {
            return ObtenerEntidad().AsNoTracking().Where(predicate).AsQueryable();
        }

        public T Insertar(T entidad)
        {
            ObtenerEntidad().Add(entidad);
            Contexto.Entry(entidad).State = EntityState.Added;
            Guardar();
            return entidad;
        }

        public void Eliminar(T entidad)
        {
            Contexto.Entry(entidad).State = System.Data.EntityState.Deleted;
        }

        public void Actualizar(T entidad)
        {
            var _entity = Contexto.Set<T>().Local.Where(e => e.Equals(entidad)).FirstOrDefault();
            if (_entity != null)
            {
                Contexto.Entry(_entity).State = System.Data.EntityState.Detached;
            }
            Contexto.Entry(entidad).State = System.Data.EntityState.Modified;
        }

        public void ActualizarPorId<TipoDeId>(T entidad, TipoDeId id)
        {
            if (entidad == null)
                return;

            T registroExistente = Contexto.Set<T>().Find(id);
            if (registroExistente != null)
            {
                Contexto.Entry(registroExistente).CurrentValues.SetValues(entidad);
            }
        }

        public void ActualizarPorId<TipoDePrimerId, TipoSegundoId>(T entidad, TipoDePrimerId primerId, TipoSegundoId segundoId)
        {
            if (entidad == null)
                return;

            T registroExistente = Contexto.Set<T>().Find(primerId, segundoId);
            if (registroExistente != null)
            {
                Contexto.Entry(registroExistente).CurrentValues.SetValues(entidad);
            }
        }

        public void Guardar()
        {
            Contexto.SaveChanges();
        }

        public IQueryable<T> EncontrarIncluir(Expression<Func<T, bool>> predicate, string include)
        {
            return Contexto.Set<T>().Where(predicate).Include(include).AsQueryable();
        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
    }
}
