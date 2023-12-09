using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] int _maxHealthPoint;
    int currentHealthPoint;

    public static Action<int> OnDamage;

    private void Start()
    {
        currentHealthPoint = _maxHealthPoint;
        OnDamage += ReduceDamage;
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    OnDamage?.Invoke(1);
        //}
    }

    private void ReduceDamage(int damage)
    {
        currentHealthPoint -= damage;
        if(currentHealthPoint < 0)
        {
            //TODO: TRIGGER RESTART SCENE or GameOverScene

        }
    }
}
