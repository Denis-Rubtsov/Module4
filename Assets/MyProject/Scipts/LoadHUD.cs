using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadHUD : MonoBehaviour
{
    [SerializeField] Image _loadValue;
    [SerializeField] float _timeToLoadNextScene;
    float _timer;

    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _loadValue.fillAmount = _timer / _timeToLoadNextScene;
        if (_timer >= _timeToLoadNextScene)
        {
            SceneManager.LoadScene(StaticData.NextScene);
            return;
        }
    }
}
