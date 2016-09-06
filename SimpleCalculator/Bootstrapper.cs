using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Calculator.Simple;
using Calculator.Views;
using Calculator.Scientific;

namespace Calculator
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = Shell as Window;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ((ModuleCatalog)ModuleCatalog).AddModule(typeof(SimpleCalculatorModule));
            ((ModuleCatalog)ModuleCatalog).AddModule(typeof(ScientificCalculatorModule));
        }
    }
}
