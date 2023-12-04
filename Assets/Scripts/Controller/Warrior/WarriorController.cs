using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataAccount;
using Model.DataHero;

public class WarriorController : MonoBehaviour
{
    [SerializeField] private WarriorSetDestinationController _warriorSetDestinationController;
    [SerializeField] private WarriorHpController _warriorHpController;
    [SerializeField] private WarriorAttackController _warriorAttackController;

    public float damge;
    private DataWariorCollection _dataWariorCollection;
    private float _speed;
    private float _hp;
    private float _defend;
    private Transform _target;

    private bool _canMove;

    private void Awake()
    {
        InitDataBase();
    }

    private void InitDataBase()
    {
        var level = DataAccountPlayer.WarriorData.levelWarrior;
        var dataWarrior = _dataWariorCollection.dataWarrior;
        for (int i = 0; i < dataWarrior.Count; i++)
        {
            var levelData = dataWarrior[i];
            if (level == levelData.level)
            {
                _speed = levelData.speed;
                _hp = levelData.hp;
                _defend = levelData.defend;
                damge = levelData.damge;
            }
        }
    }

    private void Update()
    {
        if (!_canMove)
        {
            _warriorSetDestinationController.StopMoving();
        }
        CheckAttack();
    }

    public void InitDataWarrior(Transform target)
    {
        _warriorSetDestinationController.InitData( _speed, target);
    }

  
    private void CheckAttack()
    {
        var distance = Vector3.Distance(gameObject.transform.position, _target.position);
        if(distance <= 1)
        {
            _warriorAttackController.Attack();
            _canMove = false;
        }
        else
        {
            _canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(gameObject.transform.tag))
        {
            var hitDamge = other.GetComponent<WarriorController>().damge;
            _warriorHpController.CalculateHpCurrent(hitDamge, _defend);
        }
    }
}
