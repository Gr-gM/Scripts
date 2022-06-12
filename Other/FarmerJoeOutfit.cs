//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Hollowborn/HollowbornReapersScythe.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Enhancement/InventoryEnhancer.cs
//cs_include Scripts/Other/Classes/REP-based/EternalInversionist.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/ThroneofDarkness/05bSekt(FourthDimensionalPyramid).cs

using RBot;

public class FarmerJoeOutfit
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreFarms Farm = new CoreFarms();
    public HollowbornScythe Scythe = new HollowbornScythe();
    public EternalInversionist EI = new();
    public project InvEn = new();


    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        Outfit();

        Core.SetOptions(false);
    }

    public void Outfit()
    {
        Farm.Experience(50);
        Adv.EnhanceEquipped(EnhancementType.Lucky);
        EI.GetEI();
        Adv.EnhanceEquipped(EnhancementType.Lucky);
        Farm.Experience(100);
        Scythe.GetHBReapersScythe();
        Adv.EnhanceEquipped(EnhancementType.Lucky);
        RagsandHat();
        ServersAreDown();
        // DeathsScythe();
        // BackItem();
        // Pet();
        Adv.EnhanceEquipped(EnhancementType.Lucky);


        Adv.EnhanceItem("Hollowborn Reaper's Scythe", EnhancementType.Lucky, WeaponSpecial.Awe_Blast);

        Core.Equip(new[] { "Peasant Rags", "Scarecrow Hat", "The Server is Down", "Hollowborn Reaper's Scythe" });

        Core.Logger("We are farmers, bum ba dum bum bum bum bum", messageBox: true);

    }

    public void RagsandHat()
    {
        if (Core.CheckInventory("Peasant Rags") | Core.CheckInventory("Scarecrow Hat"))
            return;

        Core.BuyItem("yulgar", 41, "Peasant Rags");
        Bot.Wait.ForPickup("Peasant Rags");
        Core.BuyItem("yulgar", 16, "Scarecrow Hat");
        Bot.Wait.ForPickup("Scarecrow Hat");
    }

    public void ServersAreDown()
    {
        if (Core.CheckInventory("The Server is Down"))
            return;

        Core.HuntMonster("undergroundlabb", "Rabid Server Hamster", "The Server is Down", isTemp: false);
        Bot.Wait.ForPickup("The Server is Down");
    }

    // public void DeathsScythe()
    // {

    //     if (Core.CheckInventory(25117))
    //         return;


    //     while (!Core.CheckInventory(25117))
    //         Bot.Player.Hunt("Death");
    // }

    // public void Pet()
    // {
    //     if (Core.CheckInventory("item"))
    //         return;

    // }


}