using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    public void GetConfig(int value)
    {
        StaticData.SelectedConfig = value;
    }
}
