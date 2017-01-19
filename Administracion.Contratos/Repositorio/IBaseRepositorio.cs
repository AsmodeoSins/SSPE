using System;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Contratos
{
    public interface IBaseRepositorio<T> where T : class
    {
        IQueryable<T> ObtenerTodos();

        IQueryable<T> EncontrarPor(Expression<Func<T, bool>> predicate);

        T Insertar(T entity);

        void Eliminar(T entity);

        void Actualizar(T entity);

        void ActualizarPorId<TipoDeId>(T entidad, TipoDeId id);

        void ActualizarPorId<TipoDePrimerId, TipoSegundoId>(T entidad, TipoDePrimerId primerId, TipoSegundoId segundoId);

        void Guardar();

        void ActivarLazyLoading();

        void DesactivarLazyLoading();

        IQueryable<T> EncontrarIncluir(Expression<Func<T, bool>> predicate, string include);
    }
}