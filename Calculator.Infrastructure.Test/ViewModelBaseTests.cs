using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Infrastructure.Tests
{
    [TestFixture]
    public class ViewModelBaseTests
    {
        ViewModelBase _vmbase;
        string _propertyName = "SomeProperty";
        string[] _errorMessages = { "Some Stupid Error", "Some Really Stupid Error" };

        [SetUp]
        public void Setup()
        {
            _vmbase = new ViewModelBase();

            foreach (var error in _errorMessages)
            {
                _vmbase.AddError(error, _propertyName);
            }
        }

        [Test]
        public void AddErrorTest()
        {
            Assert.That(_vmbase.HasErrors == true);
        }

        [Test]
        public void GetErrorsTest()
        {
            int indx = 0;
            foreach (var error in _vmbase.GetErrors(_propertyName))
            {
                Assert.That(error, Is.EqualTo(_errorMessages[indx++]));
            }
        }

        [Test]
        public void HasErrorsTest()
        {
            Assert.That(_vmbase.HasErrors == true);
        }

        [Test]
        public void RemoveErrorsTest()
        {
            _vmbase.RemoveError(_propertyName);

            Assert.That(_vmbase.HasErrors == false);
        }

        [Test]
        public void ViewModelBaseTest()
        {
            ViewModelBase vm = new ViewModelBase();

            Assert.That(vm.HasErrors == false);
        }

        [Test]
        public void ErrorsChangedEventTest()
        {
            bool eventWasFired = false;
            int eventRaisedCount = 0;

            ViewModelBase vm = new ViewModelBase();

            vm.ErrorsChanged 
                += 
                    (s, e) => { eventWasFired = true; eventRaisedCount++; };

            vm.AddError(_errorMessages[0], _propertyName);

            Assert.That(eventWasFired);
            Assert.That(eventRaisedCount == 1);

            eventWasFired = false;
            vm.RemoveError(_propertyName);

            Assert.That(eventWasFired);
            Assert.That(eventRaisedCount == 2);
        }
    }
}
