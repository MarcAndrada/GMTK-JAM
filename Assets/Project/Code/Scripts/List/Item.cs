using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public enum Type
    {
        Banana,
        Banana1,
        Banana2,
        Banana3,
        Banana4,
        Banana5,
        Banana6,
        Banana7,
        Last
    }

    public Type type;
}
