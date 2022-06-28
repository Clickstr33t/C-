using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryMethod.Codice
{
    class ShitFactory : CardFactory
    {
        private int _creditLimit;
        private int _annualCharge;

        public ShitFactory(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new ShitCreditCard(_creditLimit, _annualCharge);
        }
    }
}
