using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace SimpleCalculator
{
    class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            AddCommand = new DelegateCommand(Add);
            SubtractCommand = new DelegateCommand(Subtract);
            MultiplyCommand = new DelegateCommand(Multiply);
            DivideCommand = new DelegateCommand(Divide);
        }

        private void Divide()
        {
            if (SecondNumber != 0)
            {
                DivideResult = FirstNumber / SecondNumber;
            }
        }

        private void Multiply()
        {
            MultiplyResult = FirstNumber * SecondNumber;
        }

        private void Subtract()
        {
            SubtractResult = FirstNumber - SecondNumber;
        }

        private void Add()
        {
            AddResult = FirstNumber + SecondNumber;
        }

        private int _firstNumber;

        public int FirstNumber
        {
            get { return _firstNumber; }
            set { SetProperty(ref _firstNumber, value);
                Recalculate();
            }
        }

        private void Recalculate()
        {
            Add();
            Subtract();
            Multiply();
            Divide();
        }

        private int _secondNumber;

        public int SecondNumber
        {
            get { return _secondNumber; }
            set { SetProperty(ref _secondNumber, value);
                Recalculate();
            }
        }

        private int _addResult;

        public int AddResult
        {
            get { return _addResult; }
            set { SetProperty(ref _addResult, value); }
        }

        private int _subtractResult;

        public int SubtractResult
        {
            get { return _subtractResult; }
            set { SetProperty(ref _subtractResult, value); }
        }

        private int _multiplyResult;

        public int MultiplyResult
        {
            get { return _multiplyResult; }
            set { SetProperty(ref _multiplyResult, value); }
        }

        private int _divideResult;

        public int DivideResult
        {
            get { return _divideResult; }
            set { SetProperty(ref _divideResult, value); }
        }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SubtractCommand { get; set; }
        public DelegateCommand MultiplyCommand { get; set; }
        public DelegateCommand DivideCommand { get; set; }
    }
}
