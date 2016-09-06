using Calculator.Scientific.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Scientific
{
    public class ScientificCalculatorModule : IModule
    {
        IRegionManager _regionManager;

        public ScientificCalculatorModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion("Main-Region", typeof(ScientificCalculatorUI));
        }
    }
}
