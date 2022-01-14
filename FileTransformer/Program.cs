using Domain;
using Service;
using FileHelpers;
using Infrastructure;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FileTransformer
{
    class Program
    {
        private const string InputFileName = "ProgrammingExercise.txt";
        private const string OutputFileName = "Results.txt";
        static IHost AppStartup()
        {
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((_, services) =>
                        {
                            services.AddTransient<IFileHelperAsyncEngine<InputFormat>, FileHelperAsyncEngine<InputFormat>>();
                            services.AddTransient<IFileHelperAsyncEngine<OutputFormat>, FileHelperAsyncEngine<OutputFormat>>();
                            services.AddTransient<IDelimitedFileParser<InputFormat>, DelimitedFileParser<InputFormat>>();
                            services.AddTransient<IDelimitedFileParser<OutputFormat>, DelimitedFileParser<OutputFormat>>();
                            services.AddTransient<IPriceService, PriceService>();
                        }).Build();

            return host;
        }

        static void Main()
        {
            var host = AppStartup();
            ActivatorUtilities.GetServiceOrCreateInstance<IFileHelperAsyncEngine<InputFormat>>(host.Services);
            var inputFileParser = ActivatorUtilities.GetServiceOrCreateInstance<IDelimitedFileParser<InputFormat>>(host.Services);
            var outputFileParser = ActivatorUtilities.GetServiceOrCreateInstance<IDelimitedFileParser<OutputFormat>>(host.Services);
            var priceService = ActivatorUtilities.GetServiceOrCreateInstance<IPriceService>(host.Services);
            var inputRecords = inputFileParser.ReadFile(InputFileName);
            var outputRecords = priceService.processInputRecords(inputRecords as List<InputFormat>);
            outputFileParser.WriteFile(outputRecords, OutputFileName);
        }
    }
}
