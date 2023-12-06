using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataAccount;
using Model.DataHero;
using Controller.LoadData;

public class WarriorController : MonoBehaviour
{
    [SerializeField] private WarriorSetDestinationController _warriorSetDestinationController;
    [SerializeField] private WarriorHpController _warriorHpController;
    [SerializeField] private WarriorAttackController _warriorAttackController;

    public int id;
    public float damge;
    private DataWariorCollection _dataWariorCollection;
    private float _speed;
    private float _hp;
    private float _defend;
    private bool _canMove;
    private Transform _target;
    private bool _isEnemy;

    private void Awake()
    {
        InitDataBase();
        
    }

    public void InitData(Transform target,string tag, int idRuntime,bool isEnemy)
    {
        _isEnemy = isEnemy;
        id = idRuntime;
        _target = target;
        this.gameObject.transform.tag = tag;
        _warriorAttackController.InitTag(tag);
        InitDataWarrior(target);
    }

    public void SetLocation(Transform target)
    {
        InitDataWarrior(target);
    }

    private void InitDataBase()
    {
        _dataWariorCollection = LoadResourceController.Instance.LoadDataWariorCollection();
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
        _canMove = true;
        _warriorHpController.InitHpData(_hp);
    }

    private void Update()
    {
        //if (!_canMove)
        //{
        //    _warriorSetDestinationController.StopMoving();
        //}
        //CheckAttack();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(gameObject.transform.tag) && (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("player")))
        {
            if (collision.gameObject.GetComponent<WarriorController>() is null)
            {
                return;
            }
            var hitDamge = collision.gameObject.GetComponent<WarriorController>().damge;
            _warriorHpController.CalculateHpCurrent(hitDamge, _defend);
            GameController.Instance.SetTargetEnemy();
        }
    }

    private void OnDisable()
    {
        GameController.Instance.RemoveWarrior(_isEnemy, id,this);
        GameController.Instance.SetTargetEnemy();
    }
} 