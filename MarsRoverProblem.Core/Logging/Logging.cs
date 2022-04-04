using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Core.Logging
{
    public class Logging
    {
        private readonly ILogger _logger;
        public Logging(ILogger<Logging> logger)
        {
            _logger = logger;
        }
        public void Start()
        {
            _logger.LogInformation($"Logging Started at {DateTime.Now}");
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                _logger.LogWarning("Logging->LoadDashboard() can throw Exception!");
                int[] a = new int[] { 1, 2, 3, 4, 5 };
                int b = a[4];
                // Console.WriteLine($"Value of B: {b}");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _logger.LogCritical($"Logging->LoadDashboard() Code needs to be fixed");
            }
        }

        public void Stop()
        {
            _logger.LogInformation($"Logging Stopped at {DateTime.Now}");
        }

        public void HandleError(Exception ex)
        {
            _logger.LogError($"Logging Error Encountered at {DateTime.Now} & Error is: {ex.Message}");
        }
    }
}
