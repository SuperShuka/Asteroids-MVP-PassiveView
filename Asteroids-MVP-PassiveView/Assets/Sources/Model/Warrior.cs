using System;

namespace Asteroids.Model
{
    public class Warrior
    {
        private readonly Nlo _nlo;
        private Nlo _target;

        public Warrior(Nlo nlo, Nlo target)
        {
            _nlo = nlo;
            _target = target;
        }

        public static Warrior AttackTo(Nlo left, Nlo target)
        {
            if (left == target)
            {
                throw new InvalidOperationException();
            }

            return new Warrior(left, target);
        }
    }
}