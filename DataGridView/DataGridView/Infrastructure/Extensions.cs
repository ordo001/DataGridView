using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewProject.Infrastructure
{
    /// <summary>
    /// Статический класс методов расширения
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Добавить Binding
        /// </summary>
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            BindingSource bindingSource,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var destPropName = GetPropertyName(destinationProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            var existing = control.DataBindings[destPropName];
            if (existing != null)
                control.DataBindings.Remove(existing);

            var binding = new Binding(destPropName, bindingSource, sourcePropName, true, DataSourceUpdateMode.OnPropertyChanged);
            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var sourceType = typeof(TSource);
                var sourcePropInfo = sourceType.GetProperty(sourcePropName);
                var validationAttributes = sourcePropInfo?.GetCustomAttributes<ValidationAttribute>();

                if (validationAttributes?.Any() == true)
                {
                    control.Validating += (sender, e) =>
                    {
                        if (bindingSource.Current is not TSource source)
                            return;

                        var context = new ValidationContext(source) { MemberName = sourcePropName };
                        var results = new List<ValidationResult>();

                        errorProvider.SetError(control, string.Empty);

                        var propertyValue = sourcePropInfo?.GetValue(source);
                        var isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        if (!isValid)
                            errorProvider.SetError(control, results.First().ErrorMessage);
                    };
                }
            }
        }

        /// <summary>
        /// Вернуть отображаемое имя Enum
        /// </summary>
        public static string GetDisplayName(this Enum value)
        {
            var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            if (member != null)
            {
                var attr = member.GetCustomAttribute<DisplayAttribute>();
                if (attr != null)
                    return attr.Name;
            }
            return value.ToString();
        }

        private static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
                body = ((UnaryExpression)body).Operand;

            if (body is MemberExpression memberExpression)
                return memberExpression.Member.Name;

            throw new ArgumentException("Выражение должно быть доступом к свойству", nameof(expression));
        }

    }
}
