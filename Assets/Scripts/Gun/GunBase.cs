using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;

    public Transform shootPosition;

    public float timeBetweenShoot = .1f;

    private Coroutine _currentCoroutine;

    public Transform playerSideReference;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }else if(Input.GetKeyUp(KeyCode.E))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();

            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectileBase);

        projectile.transform.position = shootPosition.position;

        projectile.side = playerSideReference.transform.localScale.x;
    }
}
