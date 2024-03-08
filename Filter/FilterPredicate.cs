#region Imports


#endregion

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Defines a filter predicate component; performs a single logical comparison.
    /// </summary>
    public class FilterPredicate : IFilter
    {

        #region Public properties

        /// <summary>
        /// Gets or sets the filter field.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filter comparison operator.
        /// </summary>
        public ComparisonOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the filter comparison value.
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterPredicate"/> class.
        /// </summary>
        /// <param name="filterField">The field to filter against.</param>
        /// <param name="operator">The comparison operator.</param>
        /// <param name="value">The value for comparison.</param>
        internal FilterPredicate(string filterField, ComparisonOperator @operator, object value)
        {
            Field = filterField;
            Operator = @operator;
            Value = value;
        }

        #endregion

    }

}
