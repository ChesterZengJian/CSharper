using System;
using System.Collections.Generic;
using System.Text;

namespace Construction.DesignPatterns
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InventoryPartAttribute : Attribute
    {
        private enmInvParts mInventoryPart;
        public InventoryPartAttribute(enmInvParts vInvPart) { mInventoryPart = vInvPart; }
        public enmInvParts InventoryPartSupported { get { return mInventoryPart; } set { mInventoryPart = value; } }
    }
    [AttributeUsage(AttributeTargets.Interface)]
    public class ImplAttr : Attribute
    {
        private Type[] mImplementorList;
        public ImplAttr(Type[] Implementors) { mImplementorList = Implementors; }
        public Type[] ImplementorList { get { return mImplementorList; } set { mImplementorList = value; } }
    }
    [InventoryPartAttribute(enmInvParts.Monitors)]
    class MonitorInventory : IPartsInventory { public void Restock() { Console.WriteLine("monitor inventory restocked"); } }
    [InventoryPartAttribute(enmInvParts.Keyboards)]
    class KeyboardInventory : IPartsInventory { public void Restock() { Console.WriteLine("keyboard inventory restocked"); } }
    [ImplAttr(new Type[] { typeof(MonitorInventory), typeof(KeyboardInventory) })]
    interface IPartsInventory { public void Restock(); }
    class PartsFactory
    {
        public IPartsInventory ReturnPartInventory(enmInvParts vInvPart)
        {
            IPartsInventory InvPart = null;
            object Obj; Type[] IntrfaceImpl;
            Attribute Attr;
            enmInvParts enmInventoryPart;
            InventoryPartAttribute InvPartAttr;
            int ImplementorCount;
            //Retrieve the attribute ImplAttr attached to the IPartsInventory 
            //interface 
            Attr = Attribute.GetCustomAttribute(typeof(IPartsInventory), typeof(ImplAttr));
            //Retrieve the Type array containing the types that implement
            //the IPartsInventory interface 
            IntrfaceImpl = ((ImplAttr)Attr).ImplementorList;
            //Determine the number of classes that 
            //implement IPartsInventory 
            ImplementorCount = IntrfaceImpl.GetLength(0);
            for (int i = 0; i < ImplementorCount; i++)
            {
                Attr = Attribute.GetCustomAttribute(IntrfaceImpl[i], typeof(InventoryPartAttribute));
                InvPartAttr = (InventoryPartAttribute)Attr;
                //Determine what inventory part this class supports 
                enmInventoryPart = InvPartAttr.InventoryPartSupported;
                if ((int)enmInventoryPart == (int)vInvPart)
                {
                    Obj = Activator.CreateInstance(IntrfaceImpl[i]);
                    InvPart = (IPartsInventory)Obj; break;
                }
            }
            return InvPart;
        }
    }


}
