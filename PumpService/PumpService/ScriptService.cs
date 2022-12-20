using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PumpService
{
    public class ScriptService : IScriptService
    {
        private CompilerResults results = null;
        private readonly ISettingsService _settingsService;
        private readonly IStatisticsService _statisticsService;
        private readonly IPumpServiceCallback _pumpServiceCallback;

        public ScriptService(ISettingsService settingsService,
            IStatisticsService statisticsService,
            IPumpServiceCallback pumpServiceCallback)
        {
            _settingsService = settingsService;
            _statisticsService = statisticsService;
            _pumpServiceCallback = pumpServiceCallback;
        }
        public bool Compile()
        {
            try
            {
                CompilerParameters compilerParameters = new CompilerParameters();
                compilerParameters.GenerateInMemory = true;
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                FileStream fileStream = new FileStream(_settingsService.FileName, FileMode.Open);
                byte[] buffer;
                try
                {
                    int length = (int)fileStream.Length;
                    buffer = new byte[length];
                    int count;
                    int sum = 0;
                    while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    {
                        sum += count;
                    }
                }
                finally
                {
                    fileStream.Close();
                }
                CSharpCodeProvider provider = new CSharpCodeProvider();
                results = provider.CompileAssemblyFromSource(compilerParameters, System.Text.Encoding.UTF8.GetString(buffer));
                if (results.Errors != null && results.Errors.Count != 0)
                {
                    string compileErrors = string.Empty;
                    for (int i = 0; i < results.Errors.Count; i++)
                    {
                        if (compileErrors != string.Empty)
                        {
                            compileErrors += "\n";
                        }
                        compileErrors += results.Errors[i];
                    }

                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public void Run(int count)
        {
            if (results == null || (results != null && results.Errors != null && results.Errors.Count > 0))
            {
                if (Compile() == false)
                {
                    return;
                }
            }

            Type type = results.CompiledAssembly.GetType("Sample.SampleScript");
            if(type == null)
            {
                return;
            }

            MethodInfo entryPointMethod = type.GetMethod("EnteryPoint");
            if (entryPointMethod == null)
            {
                return;
            }

            Task.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    if ((bool)entryPointMethod.Invoke(Activator.CreateInstance(type), null))
                    {
                        _statisticsService.SuccessTacts++;
                    }
                    else
                    {
                        _statisticsService.ErrorTacts++;
                    }
                    _statisticsService.AllTacts++;

                    _pumpServiceCallback.UpdateStatistics((StatisticsService)_statisticsService);

                    Thread.Sleep(1000);
                }
            });            
        }
    }
}