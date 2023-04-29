using System.IO;
using UnityEngine;

namespace Assets.Scripts.SerializationScripts
{
    public class SimpleSerializer : ISerializer
    {
        Pokemon playerPokemon;

        public SimpleSerializer(Pokemon pokemon)
        {
            playerPokemon = pokemon;
        }

        public void Save()
        {
            Debug.Log("Simple Serializer Saving...");
            BasePokemon basePokemon = playerPokemon.BaseStats;

            FileStream fileStream = File.Create(Application.persistentDataPath + "/gamestate.dat");
            BinaryWriter writer = new BinaryWriter(fileStream);
            writer.Write(basePokemon.Id);
            writer.Write(basePokemon.Name);
            writer.Write(playerPokemon.Health);
            writer.Write(playerPokemon.Attack);
            writer.Write(playerPokemon.Defense);
            writer.Write(playerPokemon.SpecialAttack);
            writer.Write(playerPokemon.SpecialDefense);
            writer.Write(playerPokemon.Speed);
            writer.Close();

            fileStream.Close();
        }
    }
}
