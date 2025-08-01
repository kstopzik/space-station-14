using Content.Shared.Damage;
using Content.Shared.Physics;
using Content.Shared.SS220.Shuttles.UI;
using Content.Shared.Weapons.Reflect;
using Robust.Shared.Audio;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared.Weapons.Ranged;

[Prototype]
public sealed partial class HitscanPrototype : IPrototype, IShootable
{
    [ViewVariables]
    [IdDataField]
    public string ID { get; private set; } = default!;

    [ViewVariables(VVAccess.ReadWrite), DataField("staminaDamage")]
    public float StaminaDamage;

    [ViewVariables(VVAccess.ReadWrite), DataField("damage")]
    public DamageSpecifier? Damage;

    [ViewVariables(VVAccess.ReadOnly), DataField("muzzleFlash")]
    public SpriteSpecifier? MuzzleFlash;

    [ViewVariables(VVAccess.ReadOnly), DataField("travelFlash")]
    public SpriteSpecifier? TravelFlash;

    [ViewVariables(VVAccess.ReadOnly), DataField("impactFlash")]
    public SpriteSpecifier? ImpactFlash;

    [DataField("collisionMask")]
    public int CollisionMask = (int) CollisionGroup.Opaque;

    /// <summary>
    /// What we count as for reflection.
    /// </summary>
    [DataField("reflective")] public ReflectType Reflective = ReflectType.Energy;

    /// <summary>
    /// Sound that plays upon the thing being hit.
    /// </summary>
    [DataField("sound")]
    public SoundSpecifier? Sound;

    /// <summary>
    /// Force the hitscan sound to play rather than potentially playing the entity's sound.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField("forceSound")]
    public bool ForceSound;

    /// <summary>
    /// Try not to set this too high.
    /// </summary>
    [DataField("maxLength")]
    public float MaxLength = 20f;

    //SS220 Add hitscan spread begin
    [DataField]
    public HitscanSpread? HitscanSpread;
    //SS220 Add hitscan spread end

    // SS220 Add hitscan on shuttle nav begin
    [DataField("shuttleNavInfo")]
    public ShuttleNavHitscanInfo ShuttleNavHitscanInfo = new();
    // SS220 Add hitscan on shuttle nav end
}

//SS220 Add hitscan spread begin
[DataDefinition]
public sealed partial class HitscanSpread
{
    [DataField]
    public Angle Spread = Angle.FromDegrees(5);

    [DataField]
    public int Count = 1;
}
//SS220 Add hitscan spread end
