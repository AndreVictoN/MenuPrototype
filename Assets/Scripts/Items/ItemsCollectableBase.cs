using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag(compareTag))
        {
            Collect();
        }
    }

    public void Collect()
    {
        gameObject.SetActive(false);
        
        OnCollect();
    }

    protected virtual void OnCollect()
    {

    }
}
