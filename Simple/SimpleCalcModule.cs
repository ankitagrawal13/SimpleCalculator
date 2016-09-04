using Prism.Modularity;
using Prism.Regions;
using SimpleCalc.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc
{
    public class SimpleCalcModule : IModule
    {
        IRegionManager _regionManager;

        public SimpleCalcModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(SimpleCalcUI));
        }
    }
}
