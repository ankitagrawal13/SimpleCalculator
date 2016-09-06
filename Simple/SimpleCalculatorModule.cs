using Prism.Modularity;
using Prism.Regions;
using Calculator.Simple.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Simple
{
    public class SimpleCalculatorModule : IModule
    {
        IRegionManager _regionManager;

        public SimpleCalculatorModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion("Main-Region", typeof(SimpleCalculatorUI));
        }
    }
}
