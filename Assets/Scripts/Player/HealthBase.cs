using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10;

    private float _currentLife;

    public bool destroyOnKill = false;

    private bool _isDead = false;

    private void Awake()
    {
        destroyOnKill = true;
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(float damage)
    {
        if(_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
