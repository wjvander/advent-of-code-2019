using System;

namespace CodeKata.Day01
{
    public class FuelCalculator
    {
        private int _totalFuelRequired;

        public FuelCalculator()
        {
            _totalFuelRequired = 0;
        }

        public int Calculate(int mass)
        {
            var requiredFuel = RoundDown(mass / 3) - 2;

            if (requiredFuel <= 0)
                return _totalFuelRequired;

            _totalFuelRequired += requiredFuel;
            return Calculate(requiredFuel);
        }

        private static int RoundDown(int d)
        {
            return d;
            // return (int) Math.Floor((decimal) d);
        }
    }
}
