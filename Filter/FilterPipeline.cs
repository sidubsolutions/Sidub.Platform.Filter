#region Imports


#endregion

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Defines a filter pipeline component; encapsulates multiple filter operations and enforces
    /// order of operations.
    /// </summary>
    public class FilterPipeline : IFilter
    {
        #region Public properties

        /// <summary>
        /// Gets the filters contained within the pipeline.
        /// </summary>
        public List<IFilter> Filters { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterPipeline"/> class.
        /// </summary>
        internal FilterPipeline()
        {
            Filters = new List<IFilter>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds a filter to the pipeline.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        /// <exception cref="ArgumentException">Thrown when the filter is null.</exception>
        public void AddFilter(IFilter filter)
        {
            if (filter == null)
                throw new ArgumentException("Cannot add a null filter into the pipeline.", nameof(filter));

            Filters.Add(filter);
        }

        #endregion
    }

}
