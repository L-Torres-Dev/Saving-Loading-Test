using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.SerializationScripts
{
    public class MultiFileDeserializer : IDeSerializer
    {
        private string multiDirectoryPath = Application.persistentDataPath + "/saveFiles";

        public bool FileExists()
        {
            return Directory.Exists(multiDirectoryPath);
        }

        public DeserializedData Load()
        {
            throw new NotImplementedException();
        }
    }
}
