#region Imports


#endregion

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Defines a filter logical operator component; combines two predicates or pipelines
    /// in a logical filter operation.
    /// </summary>
    public class FilterLogicalOperator : IFilter
    {

        #region Public properties

        /// <summary>
        /// Logical operator.
        /// </summary>
        public LogicalOperator Operator { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a logical operator.
        /// </summary>
        /// <param name="operator"></param>
        internal FilterLogicalOperator(LogicalOperator @operator)
        {
            Operator = @operator;
        }

        #endregion

    }
}
