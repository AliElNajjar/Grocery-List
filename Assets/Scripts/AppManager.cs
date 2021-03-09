using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Singleton<AppManager>
{
    private ProductCollector productCollector;

    public ProductCollector ProductCollector => productCollector;
    
    protected override void Awake()
    {
        base.Awake();
        productCollector = GetComponent<ProductCollector>();
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
