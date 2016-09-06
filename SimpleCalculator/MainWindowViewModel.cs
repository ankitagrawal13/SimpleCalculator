using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using Prism.Modularity;
using Calculator.Simple;
using Calculator.Simple.Views;
using Calculator.Scientific.Views;
using Calculator.Infrastructure;

namespace Calculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            ShowSimpleCalculatorCommand = new DelegateCommand(ShowSimpleCalculator);
            ShowScientificCalculatorCommand = new DelegateCommand(ShowScientificCalculator);
        }

        void ShowSimpleCalculator()
        {
            ShowCalculator(CalculatorType.Simple);
        }

        void ShowScientificCalculator()
        {
            ShowCalculator(CalculatorType.Scientific);
        }

        void ShowCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.Simple:
                    _regionManager.RegisterViewWithRegion("Main-Region", typeof(SimpleCalculatorUI));
                    break;
                case CalculatorType.Scientific:
                    _regionManager.RegisterViewWithRegion("Main-Region", typeof(ScientificCalculatorUI));
                    break;
                default:
                    break;
            }
        }

        public DelegateCommand ShowSimpleCalculatorCommand { get; set; }
        public DelegateCommand ShowScientificCalculatorCommand { get; set; }
    }

    enum CalculatorType
    {
        Simple,
        Scientific
    }
}
