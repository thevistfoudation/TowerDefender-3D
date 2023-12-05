using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMono<GameController>
{
    [SerializeField] private GameObject _enemyGoal;
    [SerializeField] private GameObject _playerGoal;
    [SerializeField] private GameObject[] _listGateSpawnPlayer;
    [SerializeField] private GameObject[] _listGateSpawnEnemy;

    public List<WarriorController> listWarriorActive = new List<WarriorController>();

    public void CreateAndInitWarriorPlayerClass()
    {
        var gateSpawn = _listGateSpawnPlayer[Random.RandomRange(0, _listGateSpawnPlayer.Length)];
        var warrior = CreateController.Instance.warrior(gateSpawn);
        warrior.InitData(_enemyGoal.transform);
        listWarriorActive.Add(warrior);
    }
    
}
