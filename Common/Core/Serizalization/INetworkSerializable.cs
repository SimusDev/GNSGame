namespace Common.Core.Serizalization
{
    public interface INetworkSerializable
    {
        void NetworkSerialize(BinaryWriter writer);
        void NetworkDeserialize(BinaryReader reader);
    }
}
