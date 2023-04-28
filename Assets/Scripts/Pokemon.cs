using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Pokemon
    {
        public float Health { get; set; }
        public float Attack { get; set; }
        public float Defense { get; set; }
        public float SpecialAttack { get; set; }
        public float SpecialDefense { get; set; }
        public float Speed { get; set; }

        public BasePokemon BaseStats { get; private set; }
        
        public Pokemon(BasePokemon baseData)
        {
            Health = baseData.BaseHealth;
            Attack = baseData.BaseAttack;
            Defense = baseData.BaseDefense;
            SpecialAttack = baseData.BaseSpecialAttack;
            SpecialDefense = baseData.BaseSpecialDefense;
            Speed = baseData.BaseSpeed;

            BaseStats = baseData;
        }
    }
}
