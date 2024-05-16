using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    protected Player _player;

    public void Construct(Player player) => _player = player;
}
