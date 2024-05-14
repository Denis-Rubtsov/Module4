using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _resume;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _save;
    private SaveService _saveService;

    public void Construct(SaveService saveService)
    {
        _saveService = saveService;
        _resume.onClick.AddListener(ResumeButtonClicked);
        _mainMenu.onClick.AddListener(MainMenuButtonClicked);
        _save.onClick.AddListener(SaveButtonClicked);
    }


    void ResumeButtonClicked() => gameObject.SetActive(false);

    void SaveButtonClicked() => _saveService.SaveAll();

    void MainMenuButtonClicked() => SceneManager.LoadScene("MainMenu");

    private void OnDisable()
    {
        _resume.onClick.RemoveAllListeners();
        _mainMenu.onClick.RemoveAllListeners();
        _save.onClick.RemoveAllListeners();
    }
}
