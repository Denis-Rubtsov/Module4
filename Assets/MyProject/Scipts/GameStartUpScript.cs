using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class GameStartUpScript : MonoBehaviour
{
    [SerializeField] private List<EnemyConfig> _enemyData;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private TraderScript _trader;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private Vector3 _enemySpawnPoint;
    [SerializeField] private Vector3 _playerSpawnPoint;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private List<Window> _windows;

    private readonly List<EnemyBrain> _enemies = new();
    private Player _player;
    readonly SaveService _saveService = new();

    private void Start()
    {
        CreatePlayer();
        _trader.Construct(_player);
        foreach (var w in _windows)
        {
            if (w is HUD hud) hud.Construct(_player);
            if (w is InventoryWindow inventory) inventory.Construct(_player);
            if (w is TradePlayerInventory trade) trade.Construct(_player);
            if (w is TraderWindowScript traderInventory) traderInventory.Construct(_player);
        }
        _pauseMenu.Construct(_saveService);
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)) _pauseMenu.gameObject.SetActive(true);
    }

    private void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPoint, Quaternion.identity);
        _player.Construct(Camera.main, _saveService);
        _camera.Follow = _player.transform;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            EnemyConfig data = _enemyData.Random();
            CreateEnemy(data);
        }
    }

    private void CreateEnemy(EnemyConfig data)
    {
        var enemy = Instantiate(data.Prefab, _enemySpawnPoint, Quaternion.identity);
        _enemies.Add(enemy);
        enemy.Construct(_player, data);
    }

    private void OnApplicationQuit()
    {
        _saveService.SaveAll();
    }
}
