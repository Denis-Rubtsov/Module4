using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitStartLocation : Exit
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            _player.Save();
            StaticData.NextScene = "Dungeon";
            SceneManager.LoadScene("LoadScreen");
        }
    }
}
