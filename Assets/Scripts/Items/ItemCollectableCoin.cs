using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemsCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemsManager.instance.AddCoins();
    }
}
