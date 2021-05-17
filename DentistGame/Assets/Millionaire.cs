using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Millionaire : MonoBehaviour
{
    private Money money;
    private void Start()
    {
        money = Money.Instance;
    }

    public void AddMoney()
    {
        money.AddCount(1000);
    }
}
