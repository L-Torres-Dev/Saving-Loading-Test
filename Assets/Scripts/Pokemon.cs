using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

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

        public Pokemon()
        {
            
        }
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

        public override string ToString()
        {
            string toString = string.Format("Health: {0}\nAttack: {1}\nDefense: {2}\n" +
                "Special Attack: {3}\nSpecial Defense: {4}\nSpeed: {5}",
                Health, Attack, Defense, SpecialAttack, SpecialDefense,
                Speed);
            return toString;
        }
    }
}
