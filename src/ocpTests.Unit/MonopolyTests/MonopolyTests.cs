using NUnit.Framework;
using Ocp.Monopoly;

namespace ocpTests.Unit.MonopolyTests
{
    [TestFixture]
    public class MonopolyTests
    {
        private MonopolyPlayer _alice;
		private MonopolyPlayer _bob;
		private SquareFactory _squareFactory;

		[SetUp]
		public void setUp() 
	    {
			_squareFactory = new SquareFactory ();
			_alice = new MonopolyPlayer("Alice");
			_bob = new MonopolyPlayer("Bob");
		}

		[Test]
		public void freeParking() 
	    {
			Square freeParking = _squareFactory.Get ("FREE PARKING");
			_alice.LandsOn(freeParking);
			Assert.AreEqual("FREE PARKING", _alice.Location());
		}

		[Test, Ignore]
		public void go() 
	    {
			Square go = _squareFactory.Get ("GO");
			_alice.Balance = 100;
			_alice.LandsOn(go);
			Assert.AreEqual(100 + 200, _alice.Balance);
			Assert.AreEqual(go, _alice.Location());
		}

		[Test, Ignore]
		public void luxuryTax() 
	    {
			Square luxuryTax = _squareFactory.Get ("LUXURY TAX");
			_alice.Balance = 100;
			_alice.LandsOn(luxuryTax);
			Assert.AreEqual(100 - 75, _alice.Balance);
			Assert.AreEqual(luxuryTax, _alice.Location());
		}

		[Test, Ignore]
		public void goToJail() 
	    {
			Square goToJail = _squareFactory.Get ("GO TO JAIL");
			Square jail = _squareFactory.Get ("JAIL");
			_alice.LandsOn(goToJail);
			Assert.AreEqual(jail, _alice.Location());
		}

		[Test, Ignore]
		public void incomeTax() 
	    {
			Square incomeTax = _squareFactory.Get ("INCOME TAX");
			// if balance is more than 2000 then pay 200
			_alice.Balance = 3000;
			_alice.LandsOn(incomeTax);
			Assert.AreEqual(3000 - 200, _alice.Balance);

			// if balance is less than 2000 then pay 10% of balance
			_bob.Balance = 1000;
			_bob.LandsOn(incomeTax);
			Assert.AreEqual(1000 - 100, _bob.Balance);
		}
			
		[Test, Ignore]
		public void payRentOnUnimprovedProperty() 
	    {
			Square orientalAvenue = _squareFactory.Get ("ORIENTAL AVENUE");
			_alice.Balance = 1000;
			_bob.Balance = 1000;
			_bob.AddOwnedProperty(orientalAvenue);

			_alice.LandsOn(orientalAvenue);

			Assert.AreEqual(1000 - 6, _alice.Balance);
			Assert.AreEqual(1000 + 6, _bob.Balance);
		}
    }
}