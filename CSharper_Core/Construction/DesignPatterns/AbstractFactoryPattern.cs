using System;

namespace Construction.DesignPatterns
{
    //class MainClass
    //{
    //    static void Main(string[] args)
    //    {
    //        PartsFactory myfactory = null;
    //        InventoryMgr myinvmgr = new InventoryMgr();
    //        foreach (string marg in args)
    //        {
    //            switch (marg)
    //            {
    //                case "Monitors": myfactory = new MonitorInvFactory(); break;
    //                case "Keyboards": myfactory = new KeyboardInvFactory(); break;
    //                default: break;
    //            }
    //            if (myfactory != null) myinvmgr.ReplenishInventory(myfactory); myfactory = null;
    //        }
    //    }
    //}
    //class InventoryMgr { public void ReplenishInventory(PartsFactory vfactory) { IPartsInventory PartInv = vfactory.ReturnPartInventory(); PartInv.Restock(); } }
    //interface IPartsInventory { void Restock(); }
    //class MonitorInventory : IPartsInventory { public void Restock() { Console.WriteLine("The monitor inventory has been restocked"); } }
    //class KeyboardInventory : IPartsInventory { public void Restock() { Console.WriteLine("The keyboard inventory has been restocked"); } }
    //abstract class PartsFactory { public abstract IPartsInventory ReturnPartInventory(); }
    //class MonitorInvFactory : PartsFactory { public override IPartsInventory ReturnPartInventory() { return (IPartsInventory)new MonitorInventory(); } }
    //class KeyboardInvFactory : PartsFactory { public override IPartsInventory ReturnPartInventory() { return (IPartsInventory)new KeyboardInventory(); } }



    class MainClass
    {
        static void Main(string[] args)
        {
            InventoryMgr InvMgr = new InventoryMgr();
            foreach (string marg in args)
            {
                switch (marg)
                {
                    case "Monitors":
                        InvMgr.ReplenishInventory(enmInvParts.Monitors);
                        break;
                    case "Keyboards": InvMgr.ReplenishInventory(enmInvParts.Keyboards); break;
                    default: break;
                }
            }
        }
    }
    public enum enmInvParts : int { Monitors = 1, Keyboards };
    class InventoryMgr { public void ReplenishInventory(enmInvParts InventoryPart) { PartsFactory factory = new PartsFactory(); IPartsInventory IP = factory.ReturnPartInventory(InventoryPart); IP.Restock(); } }
    //class PartsFactory { public IPartsInventory ReturnPartInventory(enmInvParts InvPart) { IPartsInventory InvType; switch (InvPart) { case enmInvParts.Monitors: InvType = new MonitorInventory(); break; case enmInvParts.Keyboards: InvType = new KeyboardInventory(); break; default: InvType = null; break; } return InvType; } }
}
