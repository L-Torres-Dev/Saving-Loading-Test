using Assets.Scripts.SerializationScripts;

namespace Assets.Scripts
{
    public class Game
    {
        private Pokemon playerPokemon;
        public delegate void StatChange(Pokemon pokemon);
        public StatChange onStatChange;
        private ISerializer serializer;

        public Game(ISerializer serializer)
        {
            this.serializer = serializer;
        }
        public Game(Pokemon starter, ISerializer serializer)
        {
            this.serializer = serializer;
            playerPokemon = starter;

            BasePokemon basePokemon = starter.BaseStats;

            starter.Health = basePokemon.BaseHealth;
            starter.Attack = basePokemon.BaseAttack;
            starter.Defense = basePokemon.BaseDefense;
            starter.SpecialAttack = basePokemon.BaseSpecialAttack;
            starter.SpecialDefense = basePokemon.BaseSpecialDefense;
            starter.Speed = basePokemon.BaseSpeed;
        }

        public void Save()
        {
            SavePokemon();
        }

        private void SavePokemon()
        {
            serializer.Save();
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

        public void SetPlayerPokemon(Pokemon pokemon)
        {
            playerPokemon = pokemon;
        }

    }
}
