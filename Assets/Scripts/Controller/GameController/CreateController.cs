using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class CreateController : SingletonMono<CreateController>
{
    [SerializeField] private WarriorController _warrior;

    public WarriorController warrior(GameObject gameObjectParent)
    {
        var warrior = SmartPool.instance.Spawn(_warrior.gameObject, gameObjectParent.transform.position, gameObjectParent.transform.rotation);
        return warrior.GetComponent<WarriorController>();
    }
}