using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;
using Calculator.Infrastructure;

namespace Calculator.Scientific.ViewModels
{
    public class ScientificCalculatorUIViewModel : ViewModelBase
    {
        public ScientificCalculatorUIViewModel()
        {
            PowerCommand = new DelegateCommand(Power);
            SquareRootCommand = new DelegateCommand(SquareRoot);
            XRootYCommand = new DelegateCommand(XRootY);
            ModuloCommand = new DelegateCommand(Modulo);
        }

        private void Modulo()
        {
            ModuloResult = FirstNumber % SecondNumber;
        }

        private void XRootY()
        {
            XRootYResult = Math.Pow(SecondNumber, 1/FirstNumber);
        }

        private void SquareRoot()
        {
            SquareRootResult = Math.Sqrt(FirstNumber);
        }

        private void Power()
        {
            PowerResult = Math.Pow(FirstNumber, SecondNumber);
        }

        private void Recalculate()
        {
            Power();
            SquareRoot();
            XRootY();
            Modulo();
        }

        private double _firstNumber;

        public double FirstNumber
        {
            get { return _firstNumber; }
            set
            {
                if (value == 0)
                {
                    AddError("First Number cannot be Zero!");
                }
                else
                {
                    RemoveError();
                }

                SetProperty(ref _firstNumber, value);
                Recalculate();
            }
        }

        private double _secondNumber;

        public double SecondNumber
        {
            get { return _secondNumber; }
            set
            {
                if (value == 0)
                {
                    AddError("Second Number cannot be Zero!");
                }
                else
                {
                    RemoveError();
                }

                SetProperty(ref _secondNumber, value);
                Recalculate();
            }
        }

        private double _powerResult;

        public double PowerResult
        {
            get { return _powerResult; }
            set { SetProperty(ref _powerResult, value); }
        }

        private double _squareRootResult;

        public double SquareRootResult
        {
            get { return _squareRootResult; }
            set { SetProperty(ref _squareRootResult, value); }
        }

        private double _xRootYResult;

        public double XRootYResult
        {
            get { return _xRootYResult; }
            set { SetProperty(ref _xRootYResult, value); }
        }

        private double _moduloResult;

        public double ModuloResult
        {
            get { return _moduloResult; }
            set { SetProperty(ref _moduloResult, value); }
        }

        public DelegateCommand PowerCommand { get; set; }
        public DelegateCommand SquareRootCommand { get; set; }
        public DelegateCommand XRootYCommand { get; set; }
        public DelegateCommand ModuloCommand { get; set; }
    }
}
