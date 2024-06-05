using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10;

    private float _currentLife;

    public bool destroyOnKill = false;

    private bool _isDead = false;

    public Action OnKill;

    [SerializeField] private FlashColor _flashColor;

    private void Awake()
    {
        Init();

        if(_flashColor == null)
        {
            _flashColor.GetComponent<FlashColor>();
        }
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

        if(_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    public void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject);
        }

        OnKill?.Invoke();
    }
}
