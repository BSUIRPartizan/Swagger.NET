using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Collector.Metadata.Resolvers
{
    public class SwaggerApiUrlValidator : IUrlValidator
    {

        private readonly List<char> _filterSymbols;
        private readonly List<char> _notAcceptableSymbols;

        public SwaggerApiUrlValidator()
        {
            _filterSymbols = new List<Char>(new char[] {'{', '}', '?', '=', ':', '/', '\\'});
            _notAcceptableSymbols = new List<Char>(new char[] {'\\'});
        }

        public bool Validate(string url)
        {
            
            if (String.IsNullOrEmpty(url))
                return false;

            if (url.StartsWith("/"))
            {
                StringBuilder templateSymbols = new StringBuilder();
                //TODO: Use regexp
                foreach (var urlChar in url.ToArray())
                {
                    if (_notAcceptableSymbols.Contains(urlChar))
                        return false;
                    if (_filterSymbols.Contains(urlChar))
                    {
                        templateSymbols.Append(urlChar);
                    }
                }

                Console.WriteLine(templateSymbols);

                // TODO: Move this if to condition rule.
                if (templateSymbols.ToString().Contains("{?}"))
                    return false;

                // TODO: Move this if to condition rule.
                if (templateSymbols.ToString().Contains("="))
                    return false;
                
                return true;
            }
            

            return false;
        }
    }
}