using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _speed;
    private Transform _direction;
    public float damage;

    public void InitData(Transform direction, string tag, float dam)
    {
        _direction = direction;
        this.gameObject.transform.tag = tag;
        damage = dam;

    }

    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        this.gameObject.transform.position += _direction.transform.position * Time.deltaTime * _speed;
    }
}
