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
    public List<WarriorController> listEnemyActive = new List<WarriorController>();

    private int _count;

    public void StartGame()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateEnemyInitClass();
        }
    }

    public void RemoveWarrior(bool isEnemy,int id, WarriorController WarriorController)
    {
        if (isEnemy)
        {
            listEnemyActive.Remove(WarriorController);
        }
        else
        {
            listWarriorActive.Remove(WarriorController);
        }

        if(listEnemyActive.Count <= 0)
        {
            for(int i = 0; i < listWarriorActive.Count; i++)
            {
                listWarriorActive[i].SetLocation(_enemyGoal.transform);
            }
        }
        else if(listWarriorActive.Count <= 0)
        {
            for (int i = 0; i < listEnemyActive.Count; i++)
            {
                listEnemyActive[i].SetLocation(_playerGoal.transform);
            }
        }
    }

    public void CreateAndInitWarriorPlayerClass()
    {
        var gateSpawn = _listGateSpawnPlayer[Random.RandomRange(0, _listGateSpawnPlayer.Length)];
        var warrior = CreateController.Instance.warrior(gateSpawn,false);
        warrior.InitData(_enemyGoal.transform,"player", listWarriorActive.Count,false);
        listWarriorActive.Add(warrior);
        SetTargetEnemy();
    }   

    public void CreateEnemyInitClass()
    {
        var gateSpawn = _listGateSpawnEnemy[Random.RandomRange(0, _listGateSpawnEnemy.Length)];
        var warrior = CreateController.Instance.warrior(gateSpawn,true);
        warrior.InitData(_playerGoal.transform,"enemy", listEnemyActive.Count,true);
        listEnemyActive.Add(warrior);
    }
    
    public void SetTargetEnemy()
    {
        if(listEnemyActive.Count > listWarriorActive.Count)
        { 
            for (int i = 0; i < listEnemyActive.Count; i++)
            {
                if(i >= listWarriorActive.Count)
                {
                    var pos = listWarriorActive[0];
                    listEnemyActive[i].SetLocation(pos.transform);
                    _count += 1;
                }
                else if(i < listWarriorActive.Count)
                {
                    var pos = listWarriorActive[i];
                    listEnemyActive[i].SetLocation(pos.transform);
                    _count += 1;
                }
             
            }
        }
        else if(listEnemyActive.Count <= listWarriorActive.Count)
        {
            for (int i = 0; i < listWarriorActive.Count; i++)
            {
                if (i >= listEnemyActive.Count)
                {
                    var pos = listEnemyActive[0];
                    listWarriorActive[i].SetLocation(pos.transform);
                    _count += 1;
                }
                else if (i < listEnemyActive.Count)
                {
                    var pos = listWarriorActive[i];
                    listWarriorActive[i].SetLocation(pos.transform);
                    _count += 1;
                }

            }
        }
       
    }
}