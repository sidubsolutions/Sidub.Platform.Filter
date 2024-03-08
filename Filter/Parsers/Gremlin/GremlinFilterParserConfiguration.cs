using Sidub.Platform.Filter.Services;

namespace Sidub.Platform.Filter.Parsers.Gremlin
{

    /// <summary>
    /// Represents the configuration for the Gremlin filter parser.
    /// </summary>
    public class GremlinFilterParserConfiguration : IFilterServiceConfiguration
    {

        #region Public properties

        /// <summary>
        /// Gets the list of filter parsers.
        /// </summary>
        public List<IFilterParser> FilterParsers { get; }

        /// <summary>
        /// Gets the list of value parsers.
        /// </summary>
        public List<IFilterValueParser> ValueParsers { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GremlinFilterParserConfiguration"/> class.
        /// </summary>
        public GremlinFilterParserConfiguration()
        {
            FilterParsers = new List<IFilterParser>()
                {
                    new FilterParserPredicate(),
                    new FilterParserLogicalOperator(),
                    new FilterParserPipeline()
                };

            ValueParsers = new List<IFilterValueParser>()
                {
                    new FilterValueParserGuid(),
                    new FilterValueParserNumeric(),
                    new FilterValueParserString()
                };
        }

        #endregion

    }

}
