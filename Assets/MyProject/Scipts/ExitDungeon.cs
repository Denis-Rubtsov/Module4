using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDungeon : Exit
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            _player.Save();
            StaticData.NextScene = "StartLocation";
            SceneManager.LoadScene("LoadScreen");
        }
    }
}
