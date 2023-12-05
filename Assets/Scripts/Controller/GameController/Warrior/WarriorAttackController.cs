using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackController : MonoBehaviour
{
    [SerializeField] private GameObject _hitBox;
    public void Attack()
    {
        _hitBox.SetActive(true);
        DOVirtual.DelayedCall(0.5f, () => _hitBox.SetActive(false));
    }
}