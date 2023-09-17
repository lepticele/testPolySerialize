using System.Runtime.CompilerServices;

namespace PolymorphicSerialize;

[Serializable]
public abstract class Effect
{
    public virtual void ApplyEffect()
    {

    }
}