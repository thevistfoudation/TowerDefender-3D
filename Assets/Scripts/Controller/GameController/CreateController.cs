using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class CreateController : SingletonMono<CreateController>
{
    [SerializeField] private WarriorController _warrior;
    [SerializeField] private WarriorController _enemyWarrior;
    [SerializeField] private BulletController _bulletController;

    public WarriorController warrior(GameObject gameObjectParent, bool isEnemy)
    {
        if (isEnemy)
        {
            var warrior = SmartPool.instance.Spawn(_enemyWarrior.gameObject, gameObjectParent.transform.position, gameObjectParent.transform.rotation);
            return warrior.GetComponent<WarriorController>();
        }
        else
        {
            var warrior = SmartPool.instance.Spawn(_warrior.gameObject, gameObjectParent.transform.position, gameObjectParent.transform.rotation);
            return warrior.GetComponent<WarriorController>();
        }
    }

    public BulletController Bullet( GameObject gameObjectParent)
    {

        var warrior = SmartPool.instance.Spawn(_bulletController.gameObject, gameObjectParent.transform.position, gameObjectParent.transform.rotation);
        return warrior.GetComponent<BulletController>();
    }
}