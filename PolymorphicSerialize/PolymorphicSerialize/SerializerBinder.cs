using Newtonsoft.Json.Serialization;

public class SerializerSetting : ISerializationBinder
{
    public Type BindToType(string? assemblyName, string typeName)
    {
        foreach (Type type in Test.ValideSerializedTypes)
        {
            if (type.ToString() == typeName)
            {
                var resolvedTypeName = $"{typeName}, {assemblyName}";
                return Type.GetType(resolvedTypeName, true);
            }
        }

        return Type.GetType(null, true);
    }

    public void BindToName(Type serializedType, out string? assemblyName, out string? typeName)
    {
        assemblyName = null;
        typeName = serializedType.AssemblyQualifiedName;
    }
}