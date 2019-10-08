using System.Collections.Generic;

namespace Filters.Infrastructure.TypeFilters
{
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Messages { get; }
        void AddMessage(string message);
    }
}