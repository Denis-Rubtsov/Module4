using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig", order = 0)]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
}
