using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskBasedServices.Common;
using TaskBasedServices.Models;
using TaskBasedServices.Services;

namespace TaskBasedServices.ViewModels
{
    public class DealParameters
    {
        private readonly ServiceExecutor services;

        public DealParameters()
        {
            services = new ServiceExecutor();
            BuildDealCommand = new RelayCommand(OnBuildCommand);
        }

        public MoneyMarketRate MoneyMarketRate { get; set; }
        public InvestmentBoundaries InvestmentBoundaries { get; set; }
        public TradingDate TradingDate { get; set; }
        public Spot Spot { get; set; }
        public ICommand BuildDealCommand { get; private set; }
        
        private async void OnBuildCommand()
        {
            try 
            {
                var tasks = new []
                {
                    services.GetAsync<DTOs.MoneyMarketRate, MoneyMarketRate>(x => MoneyMarketRate = x),
                    services.GetAsync<DTOs.InvestmentBoundaries, InvestmentBoundaries>(x => InvestmentBoundaries = x),
                    services.GetAsync<DTOs.TradingDate, TradingDate>(x => TradingDate = x),
                };

                await TaskEx.WhenAll(tasks);
                await services.GetAsync<DTOs.Spot, Spot>(x => Spot = x);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}