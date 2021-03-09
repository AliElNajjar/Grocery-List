using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductCollector : MonoBehaviour
{
    public Action<bool, string> ProductToggled;

    private List<string> productList = new List<string>();

    public List<string> ProductList => productList;

    private void Start()
    {
        ProductToggled += HandleProductToggled;
    }

    private void HandleProductToggled(bool picked, string product)
    {
        if (picked)
        {
            productList.Add(product);
        }

        if (!picked)
        {
            productList.Remove(product);
        }
    }
}
