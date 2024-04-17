using System.Diagnostics;

namespace PolymorphicSerialize;

[Serializable, RegisterSerializeTypeValidation]
public class EffectFire : Effect
{
    public int flameNumber { get; set; } = 4;

    public override void ApplyEffect()
    {
        Debug.WriteLine($"fire effect {flameNumber}");
    }
}