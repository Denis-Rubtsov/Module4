using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public Vector3 Motion { get; private set; }
    public bool Attacking { get; private set; }

    void Update()
    {
        Attacking = Input.GetMouseButton(0);
        Motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
