using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static int SelectedConfig { get; set; }
    public static string NextScene {  get; set; }
    public static List<Item> Inventory { get; set; } = null;
    public static Dictionary<Slot, Item> Equipment { get; set; } = null;
}
