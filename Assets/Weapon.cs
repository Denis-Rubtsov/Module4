using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName = "Config/Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [field: SerializeField] public float AttackCooldown { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Range { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
}
