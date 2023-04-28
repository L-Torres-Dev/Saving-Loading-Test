namespace Assets.Scripts
{
    public class Game
    {
        private Pokemon playerPokemon;

        public delegate void StatChange(Pokemon pokemon);
        public StatChange onStatChange;

        public Game(Pokemon starter)
        {
            playerPokemon = starter;

            BasePokemon basePokemon = starter.BaseStats;

            starter.Health = basePokemon.BaseHealth;
            starter.Attack = basePokemon.BaseAttack;
            starter.Defense = basePokemon.BaseDefense;
            starter.SpecialAttack = basePokemon.BaseSpecialAttack;
            starter.SpecialDefense = basePokemon.BaseSpecialDefense;
            starter.Speed = basePokemon.BaseSpeed;
        }

        public void NotifyOfStatChange()
        {
            onStatChange?.Invoke(playerPokemon);
        }

        public void incrementHP(int increment)
        {
            playerPokemon.Health += increment;
            NotifyOfStatChange();
        }
        public void incrementAttack(int increment)
        {
            playerPokemon.Attack += increment;
            NotifyOfStatChange();
        }
        public void incrementDefense(int increment)
        {
            playerPokemon.Defense += increment;
            NotifyOfStatChange();
        }
        public void incrementSpecialAttack(int increment)
        {
            playerPokemon.SpecialAttack += increment;
            NotifyOfStatChange();
        }
        public void incrementSpecialDefense(int increment)
        {
            playerPokemon.SpecialDefense += increment;
            NotifyOfStatChange();
        }
        public void incrementSpeed(int increment)
        {
            playerPokemon.Speed += increment;
            NotifyOfStatChange();
        }

    }
}
