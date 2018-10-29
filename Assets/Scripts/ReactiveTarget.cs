﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy health, and death
public class ReactiveTarget : MonoBehaviour
{
    public int enemyHealth;
    private Animator _animator;

    void Start()
    {
        enemyHealth = 2;
        _animator = GetComponent<Animator>();
        _animator.SetInteger("enemyHealth", enemyHealth);
    }
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            enemyHealth -= 1;
            _animator.SetInteger("enemyHealth", enemyHealth);
            Debug.Log("The enemyHealth: " + enemyHealth);
            if (enemyHealth == 0)
            {
                behavior.SetAlive(false);
                StartCoroutine(Die());
            }
        }
    }
    private IEnumerator Die()
    {
        _animator.SetInteger("enemyHealth", enemyHealth);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}