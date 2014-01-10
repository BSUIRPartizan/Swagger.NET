using CommandLine;
using CommandLine.Text;

namespace Api.Swagger.Generator.Runner
{
    public class RunnerOptions
    {
        [Option('a', "assemblyPath", Required = true,
            HelpText = "Assembly Path to be processed.")]
        public string AssemblyPath { get; set; }

        [Option('s', "swaggerJsonPath", Required = true,
            HelpText = "Output file path.")]
        public string SwaggerJsonPath { get; set; }


        [Option('v', "apiVersion", Required = false, DefaultValue = "1.0",
            HelpText = "Output file path.")]
        public string ApiVersion { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}