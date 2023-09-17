namespace PolymorphicSerialize;

[Serializable, RegisterSerializeTypeValidation]
public class EffectFreeze : Effect
{
    public List<float> waterDrops { get; set; } = new List<float>() { 2, 3, 4 };
}