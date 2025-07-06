using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualAsteroide : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] _Asteroide;
    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;
        _Asteroide[FindProjectile()].transform.position = firePoint.position;
        _Asteroide[FindProjectile()].GetComponent<ActualAsteroidEnemy>().ActivateProjectile();
    }

    private int FindProjectile()
    {
        for(int i = 0; i < _Asteroide.Length; i++)
        {
            if(!_Asteroide[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer = cooldownTimer + Time.deltaTime;
        if(cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }
}
