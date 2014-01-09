using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Api.Collector;
using Api.Collector.Metadata.Resolvers;
using Api.Collector.Swagger;
using Services.Controllers.Account;

namespace Api.Swagger.Generator.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IMetaDataResolver metaDataResolver = new MetaDataResolver();
            
            Assembly thisAssembly = typeof(AccountController).Assembly;
            var apiCollector = new ApiCollector(metaDataResolver);

            try
            {
                var rnDApiValidator = new ApiValidator();
                var swaggerApiGenerator = new SwaggerApiGenerator();
                List<string> filter = rnDApiValidator.GetFilter();

                ApiCollectorResult result = apiCollector.Run(typeof(ApiController), thisAssembly, filter);
                rnDApiValidator.ValidateData(filter, result);
                swaggerApiGenerator.Generate(result);
            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    if (exSub is FileNotFoundException)
                    {
                        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
                Console.WriteLine(errorMessage);
                //Display or log the error based on your application.
            }
            
        }
    }
}
