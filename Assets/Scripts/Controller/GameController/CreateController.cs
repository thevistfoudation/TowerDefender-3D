using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class CreateController : SingletonMono<CreateController>
{
    [SerializeField] private WarriorController _warrior;
    [SerializeField] private WarriorController _enemyWarrior;

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
}