using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Api.Collector;
using Api.Collector.Metadata.Api;
using Api.Collector.Metadata.Resolvers;
using Api.Collector.Swagger;
using CommandLine;

namespace Api.Swagger.Generator.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TODO: Skip contollers if route is undefined. Currenlty controller for skipping need add to SkipTypes.txt
            //TODO: Move these setting to profile and set profile for run via command line arg - /profile:'[profilePath]/App.Sample.json'
            //TODO: Add json schema to validate profile
            
            RunnerOptions options = new RunnerOptions();
            Parser parser =new Parser();

            if (parser.ParseArguments(args, options))
            {
                string assemblyPath = options.AssemblyPath;
                string swaggerJsonPath = options.SwaggerJsonPath;
                string apiVersion = options.ApiVersion;

                IMetaDataResolver metaDataResolver = new MetaDataResolver();
                Assembly thisAssembly = Assembly.LoadFrom(assemblyPath);
                var apiCollector = new ApiCollector(metaDataResolver);

                try
                {
                    ApiRoot apiRoot = new ApiRoot
                    {
                        ApiVersion = apiVersion,
                        SwaggerVersion = "1.1",
                        BasePath = "/",
                        ResourcePath = "/generated_by_controllers"
                    };


                    var rnDApiValidator = new ApiValidator();
                    var swaggerApiGenerator = new SwaggerApiGenerator();
                    List<string> filter = rnDApiValidator.GetFilter();

                    ApiCollectorResult result = apiCollector.Run(typeof(ApiController), thisAssembly, filter);
                    rnDApiValidator.ValidateData(filter, result);
                    swaggerApiGenerator.Generate(result, swaggerJsonPath, apiRoot);
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
            else
            {
                Console.WriteLine("Error: You have missed a few command line arguments.");
                Console.WriteLine(options.GetUsage());
            }
        }
    }
}
