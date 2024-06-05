using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float damage = 2;

    public Animator animator;

    public string triggerAttack = "attack";
    public string triggerKill = "kill";

    public HealthBase healthBase;

    public float timeToDestroy = 1;

    void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;

        PlayKillAnimation();

        Destroy(gameObject, timeToDestroy);
    }

    public void PlayKillAnimation()
    {
        animator.SetTrigger("kill");
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("attack");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
