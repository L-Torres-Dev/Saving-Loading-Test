namespace Assets.Scripts.SerializationScripts
{
    public class DeserializedData
    {
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float Health { get => health; set => health = value; }
        public float Attack { get => attack; set => attack = value; }
        public float Defense { get => defense; set => defense = value; }
        public float SpecialAttack { get => specialAttack; set => specialAttack = value; }
        public float SpecialDefense { get => specialDefense; set => specialDefense = value; }
        public float Speed { get => speed; set => speed = value; }

        private string id;
        private string name;
        private float health;
        private float attack;
        private float defense;
        private float specialAttack;
        private float specialDefense;
        private float speed;
    }
}
