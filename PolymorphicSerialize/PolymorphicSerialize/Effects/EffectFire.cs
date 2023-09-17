namespace PolymorphicSerialize;

[Serializable, RegisterSerializeTypeValidation]
public class EffectFire : Effect
{
    public int flameNumber { get; set; } = 4;
}