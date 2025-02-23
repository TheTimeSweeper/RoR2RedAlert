using UnityEngine;
using RoR2;
using RA2Mod.Survivors.Tesla;
using RA2Mod.Survivors.Tesla.Orbs;
using RoR2.Orbs;

public class TeslaWeaponComponent : MonoBehaviour {

    public bool hasTeslaCoil;
    public TeslaSkinDef teslaSkinDef;

    private CharacterBody characterBody;
    private Animator animator;

    void Awake() {

        characterBody = GetComponent<CharacterBody>();

        animator = characterBody.modelLocator.modelTransform.GetComponent<Animator>();

        characterBody.onInventoryChanged += CharacterBody_onInventoryChanged;
    }

    void Start() {
        try {
            teslaSkinDef = RA2Mod.Modules.Skins.GetCurrentSkinDef(characterBody) as TeslaSkinDef;
        }
        catch {
            Destroy(this);
        }
    }

    private void CharacterBody_onInventoryChanged() {

        hasTeslaCoil = characterBody.inventory.GetItemCount(RoR2Content.Items.ShockNearby) > 0;

        bool hasHoldingItem = characterBody.inventory.GetItemCount(RoR2Content.Items.ChainLightning) > 0 ||
                              characterBody.inventory.GetItemCount(DLC1Content.Items.ChainLightningVoid) > 0 ||
                              characterBody.inventory.GetItemCount(DLC1Content.Items.MoveSpeedOnKill) > 0;

        animator.SetBool("LeftHandClosed", hasHoldingItem);
    }

    public ModdedLightningType GetModdedOrbType()
    {
        if (hasTeslaCoil)
        {
            return ModdedLightningType.Tesla;
        }
        else if (teslaSkinDef)
        {
            return teslaSkinDef.ZapLightningType;
        }

        return ModdedLightningType.Ukulele;
    }

    public LightningOrb.LightningType GetBounceOrbType()
    {
        if (teslaSkinDef)
        {
            return teslaSkinDef.ZapBounceLightningType;
        }

        return LightningOrb.LightningType.MageLightning;
    }
}