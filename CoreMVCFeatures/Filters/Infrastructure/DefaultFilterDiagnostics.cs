using System.Collections.Generic;
using Filters.Infrastructure.TypeFilters;

namespace Filters.Infrastructure
{
    public class DefaultFilterDiagnostics : IFilterDiagnostics {
        private readonly List<string> _messages = new List<string>();
        
        public IEnumerable<string> Messages => _messages;
        
        public void AddMessage(string message) =>
            _messages.Add(message);
    }
}