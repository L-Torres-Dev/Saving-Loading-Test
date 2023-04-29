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
            string[] files = Directory.GetFiles(multiDirectoryPath);

            return files.Length > 0;
        }

        public DeserializedData Load()
        {
            throw new NotImplementedException();
        }
    }
}
