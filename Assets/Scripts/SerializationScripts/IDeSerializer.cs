
namespace Assets.Scripts.SerializationScripts
{
    public interface IDeSerializer
    {
        bool FileExists();
        DeserializedData Load();
    }
}
