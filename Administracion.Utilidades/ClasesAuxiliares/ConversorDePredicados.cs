using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Administracion.Utilidades.ClasesAuxiliares
{
    public class ConversorDePredicados : ExpressionVisitor
    {
        private readonly Dictionary<Expression, Expression> parameterMap;

        public ConversorDePredicados(Dictionary<Expression, Expression> parameterMap)
        {
            this.parameterMap = parameterMap;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            // mapear los parametros
            Expression found = null;
            if (!parameterMap.TryGetValue(node, out found))
                found = base.VisitParameter(node);
            return found;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            // Mapear nodo
            var expr = Visit(node.Expression);
            if (expr != null && expr.Type != node.Type && expr.NodeType != ExpressionType.Constant)
            {
                var propiedad = node.Member.ReflectedType.GetProperties().SingleOrDefault(p => p.Name == node.Member.Name);
                var columna = propiedad.GetCustomAttributes(false).SingleOrDefault(p => p.GetType() == typeof(NombreDeColumna)) as NombreDeColumna;
                if (columna != null)
                {
                    MemberInfo newMember = expr.Type.GetMember(columna.Nombre).SingleOrDefault();
                    if (newMember != null)
                    {
                        return Expression.MakeMemberAccess(expr, newMember);
                    }
                }
            }
            return base.VisitMember(node);
        }
    }
}
