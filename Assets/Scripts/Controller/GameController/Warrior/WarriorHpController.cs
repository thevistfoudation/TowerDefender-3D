using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class WarriorHpController : MonoBehaviour
{
    public float hp;

    public void InitHpData(float hp)
    {
        this.hp = hp;
    }

    public void CalculateHpCurrent(float hitDam, float defend)
    {
        hp -= (hitDam - defend);
    }

    private void Update()
    {
        if(hp <= 0)
        {
            SmartPool.Instance.Despawn(this.gameObject);

        }
    }

    private void OnDisable()
    {
        hp = 0;
    }
}
