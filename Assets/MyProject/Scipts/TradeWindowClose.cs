using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeWindowClose : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) gameObject.SetActive(false);
    }
}
