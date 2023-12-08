using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackController : MonoBehaviour
{
    [SerializeField] private BulletController _bullet;
    [SerializeField] private GameObject _tranShoot;

    public void Shoot()
    {
        CreateController.Instance.Bullet(_tranShoot).InitData(gameObject.transform,this.gameObject.transform.tag,100);
    }

}