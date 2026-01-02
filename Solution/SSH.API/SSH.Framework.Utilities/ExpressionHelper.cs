using System.Linq.Expressions;

namespace SSH.Framework.Utilities
{
    public static class ExpressionHelper
    {
        public static string GetAccessPath<T>(Expression<Func<T, object>> expression)
        {
            var stack = new Stack<string>();

            MemberExpression memberExpression;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var unaryExpressione = expression.Body as UnaryExpression;
                    memberExpression =
                        ((unaryExpressione != null) ? unaryExpressione.Operand : null) as MemberExpression;
                    break;
                default:
                    memberExpression = expression.Body as MemberExpression;
                    break;
            }

            while (memberExpression != null)
            {
                stack.Push(memberExpression.Member.Name);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            return string.Join(".", stack.ToArray());
        }
    }
}
