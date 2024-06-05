using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;

    public float timeToDestroy = 1;

    public float side = 1;

    public int damageAmount = 1;

    void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("enemy"))
        {
            var enemy = col.transform.GetComponent<EnemyBase>();

            enemy.Damage(damageAmount);

            Destroy(gameObject);
        }
    }
}
