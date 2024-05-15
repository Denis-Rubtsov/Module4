using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    protected Player _player;

    public virtual void Construct(Player player)
    {
        if (player == null) Debug.Log("Player is null");
        _player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
