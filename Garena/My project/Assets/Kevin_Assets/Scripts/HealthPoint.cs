using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPoint : MonoBehaviour
{
    public static HealthPoint Instance;

    [SerializeField] int _maxHealthPoint;
    [SerializeField] Animator _animator;
    [SerializeField] HitEffect _hitEffect;

    int currentHealthPoint;

    bool isTriggered = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealthPoint = _maxHealthPoint;
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    OnDamage?.Invoke(1);
        //}
    }

    public void ReduceDamage(int damage)
    {
        currentHealthPoint -= damage;
        _hitEffect.TriggerHitVFX();

        if(currentHealthPoint < 0 && !isTriggered)
        {
            //TODO: TRIGGER RESTART SCENE or GameOverScene
            _animator.SetTrigger("Death");
            isTriggered = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
