#region Imports

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers.OData
{

    public class ODataFilterService : FilterService<ODataFilterConfiguration>
    {

        #region Constructors

        public ODataFilterService(IEnumerable<IFilterValueParser> globalValueParsers) : base(globalValueParsers)
        {
        }

        #endregion

    }

}
