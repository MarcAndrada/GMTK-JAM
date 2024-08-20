using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public enum Type
    {
        Fridge,
        Mircowave,
        Toaster,
        Rice_Cooker,
        Coffee_Maker,
        Dishwasher,
        Cabinets,
        Waffle_Maker,
        Portable_Stove,
        Meat_Grinder,
        Kettle,
        Kitchen_Stove,
        Washing_Machine,
        Apple,
        Banana,
        Orange,
        Cat,
        Pinguin,
        Elephant,
        Lobster,
        Racoon,
        Last
    }

    public Type type;
}
