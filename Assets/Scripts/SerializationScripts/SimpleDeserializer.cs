using System;
using UnityEngine;
using System.IO;

namespace Assets.Scripts.SerializationScripts
{
    public class SimpleDeserializer : IDeSerializer
    {

        public bool FileExists()
        {
            return File.Exists(Application.persistentDataPath + "/gamestate.dat");
        }

        public DeserializedData Load()
        {
            DeserializedData data = new DeserializedData();

            FileStream fileStream = File.Open(Application.persistentDataPath + "/gamestate.dat", FileMode.Open);
            BinaryReader reader = new BinaryReader(fileStream);

            data.Id = reader.ReadString();
            data.Name = reader.ReadString();
            data.Health = reader.ReadSingle();
            data.Attack = reader.ReadSingle();
            data.Defense = reader.ReadSingle();
            data.SpecialAttack = reader.ReadSingle();
            data.SpecialDefense = reader.ReadSingle();
            data.Speed = reader.ReadSingle();

            reader.Close();
            return data;
        }
    }
}
