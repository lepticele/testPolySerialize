namespace PolymorphicSerialize;

[Serializable, RegisterSerializeTypeValidation]
public class Weapon
{
    public List<Effect> Effects { get; set; } = new();
}