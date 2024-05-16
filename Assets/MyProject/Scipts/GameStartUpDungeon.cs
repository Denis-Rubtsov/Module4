using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUPDungeon : GameStartUpScript
{
    [SerializeField] protected Vector3 _enemySpawnPoint;
    private readonly List<EnemyBrain> _enemies = new();

    void Start()
    {
        CreatePlayer();
        foreach (var w in _windows)
        {
            if (w is HUD hud) hud.Construct(_player);
            if (w is InventoryWindow inventory) inventory.Construct(_player);
            if (w is TradePlayerInventory trade) trade.Construct(_player);
            if (w is TraderWindowScript traderInventory) traderInventory.Construct(_player);
        }
        _pauseMenu.Construct(_saveService);
        _exit.Construct(_player);
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) _pauseMenu.gameObject.SetActive(true);
    }

    protected IEnumerator SpawnEnemies()
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
