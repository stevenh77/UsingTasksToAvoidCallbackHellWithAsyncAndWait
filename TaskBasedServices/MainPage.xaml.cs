using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using TaskBasedServices.Models;
using TaskBasedServices.Services;
using TaskBasedServices.ViewModels;

namespace TaskBasedServices
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new DealParameters();
        }
    }
}