using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using PolymorphicSerialize;

class Test
{
    private const string EffectPath = @"Y:\Projects\LaboratorySerialize\PolymorphicSerialize\SerializedFiles\";
    private const string FileName = @"Effects.json";
    private const string EffectValidationName = @"TypeValidation.json";

    public static List<Type> ValideSerializedTypes = new ();


    static void Main(string[] args)
    {

        GenerateSecurityTypeCheckFile();

        LoadSecurityTypeCheck();

        // Display the number of command line arguments.
        Console.WriteLine(args.Length);

        // Serialize();
        Deserialize();
    }

    private static void LoadSecurityTypeCheck()
    {
        string fileContent = File.ReadAllText(EffectPath + EffectValidationName);

        ValideSerializedTypes = JsonConvert.DeserializeObject<List<Type>>(fileContent)!;
    }

    private static void GenerateSecurityTypeCheckFile()
    {
        List<Type> types = new();

        foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in a.GetTypes())
            {
                // ... do something with 't' ...
                if (type.IsDefined(typeof(RegisterSerializeTypeValidation), true))
                {
                    types.Add(type);
                }
            }
        }

        using StreamWriter file = File.CreateText(EffectPath + EffectValidationName);
        string fileContent = JsonConvert.SerializeObject(types);
        file.Write(fileContent);
    }

    private static List<Weapon> CreateWeapons()
    {
        List<Weapon> weapons = new();

        Weapon weapon1 = new Weapon();

        weapon1.Effects.Add(new EffectFire());

        Weapon weapon2 = new Weapon();
        weapon2.Effects.Add(new EffectFreeze());

        weapons.Add(weapon1);
        weapons.Add(weapon2);

        return weapons;
    }


    private static void Serialize()
    {
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            SerializationBinder = new SerializerSetting()
        };

        List<Weapon> weapons = CreateWeapons();
        foreach (Weapon weapon in weapons)
        {
            foreach (Effect effect in weapon.Effects)
            {
                effect.ApplyEffect();
            }
        }
        using StreamWriter file = File.CreateText(EffectPath + FileName);
        string fileContent = JsonConvert.SerializeObject(weapons, jsonSerializerSettings);
        file.Write(fileContent);
    }

    private static void Deserialize()
    {
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            SerializationBinder = new SerializerSetting()
        };

        string fileContent = File.ReadAllText(EffectPath + FileName);

        List<Weapon>? weapons = JsonConvert.DeserializeObject<List<Weapon>>(fileContent, jsonSerializerSettings);
        if (weapons != null)
        {
            foreach (Weapon weapon in weapons)
            {
                Debug.WriteLine(weapon);
            }
        }
    }
}