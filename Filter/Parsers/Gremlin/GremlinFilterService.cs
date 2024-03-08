#region Imports

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers.Gremlin
{

    public class GremlinFilterService : FilterService<GremlinFilterParserConfiguration>
    {

        #region Constructors

        public GremlinFilterService(IEnumerable<IFilterValueParser> globalValueParsers) : base(globalValueParsers)
        {
        }

        #endregion

    }

}
