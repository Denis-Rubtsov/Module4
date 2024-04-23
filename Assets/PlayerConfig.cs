using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig", order = 0)]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
}
