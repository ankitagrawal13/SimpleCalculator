using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Calculator.Simple.ViewModels;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class SimpleCalculatorUIViewModelTests
    {
        [Test]
        public void SimpleCalculatorUIViewModelTest()
        {
            SimpleCalculatorUIViewModel sut = new SimpleCalculatorUIViewModel();

            Assert.NotNull(sut.AddCommand);
            Assert.NotNull(sut.SubtractCommand);
            Assert.NotNull(sut.MultiplyCommand);
            Assert.NotNull(sut.DivideCommand);
        }

        [Test]
        public void AddCommandTest()
        {
            SimpleCalculatorUIViewModel sut = new SimpleCalculatorUIViewModel();
            sut.FirstNumber = 1;
            sut.SecondNumber = 2;

            sut.AddCommand.Execute();

            Assert.That(sut.AddResult == 3);
        }

        [Test]
        public void SubtractCommandTest()
        {
            SimpleCalculatorUIViewModel sut = new SimpleCalculatorUIViewModel();
            sut.FirstNumber = 2;
            sut.SecondNumber = 1;

            sut.SubtractCommand.Execute();

            Assert.That(sut.SubtractResult == 1);
        }

        [Test]
        public void MultiplyCommandTest()
        {
            SimpleCalculatorUIViewModel sut = new SimpleCalculatorUIViewModel();
            sut.FirstNumber = 2;
            sut.SecondNumber = 3;

            sut.MultiplyCommand.Execute();

            Assert.That(sut.MultiplyResult == 6);
        }

        [Test]
        public void DivideCommandTest()
        {
            SimpleCalculatorUIViewModel sut = new SimpleCalculatorUIViewModel();
            sut.FirstNumber = 3;
            sut.SecondNumber = 2;

            sut.DivideCommand.Execute();

            Assert.That(sut.DivideResult == 1);
        }
    }
}
