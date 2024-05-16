using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class GameStartUpScript : MonoBehaviour
{
    [SerializeField] protected List<EnemyConfig> _enemyData;
    [SerializeField] protected Player _playerPrefab;
    [SerializeField] protected PauseMenu _pauseMenu;
    [SerializeField] protected Vector3 _playerSpawnPoint;
    [SerializeField] protected CinemachineVirtualCamera _camera;
    [SerializeField] protected List<Window> _windows;
    [SerializeField] protected Exit _exit;

    protected Player _player;
    protected readonly SaveService _saveService = new();

    private void Start()
    {
    }

    void Update()
    {
    }

    protected void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPoint, Quaternion.identity);
        _player.Construct(Camera.main, _saveService);
        _camera.Follow = _player.transform;
    }

    private void OnApplicationQuit()
    {
        _saveService.SaveAll();
    }
}
