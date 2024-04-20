using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _buttonStart;

    void OnEnable()
    {
        _buttonStart.onClick.AddListener(StartClicked);
    }

    void StartClicked()
    {
        SceneManager.LoadScene("Scene");
    }

    void OnDisable()
    {
        _buttonStart.onClick?.RemoveListener(StartClicked);
    }
}
