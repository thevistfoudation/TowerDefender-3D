using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class WarriorHpController : MonoBehaviour
{
    private float _hp;
    public void CalculateHpCurrent(float hitDam, float defend)
    {
        _hp -= (hitDam - defend);
    }

    private void Update()
    {
        if(_hp <= 0)
        {
            SmartPool.Instance.Despawn(this.gameObject);
        }
    }

    private void OnDisable()
    {
        _hp = 0;
    }
}
