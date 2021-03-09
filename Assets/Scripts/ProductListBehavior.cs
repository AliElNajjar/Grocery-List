using System.Collections.Generic;
using UnityEngine;

public class ProductListBehavior : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] GameObject productPrefab;
    
    private List<string> productNames;
    private List<GameObject> products = new List<GameObject>();
    
    private void OnEnable()
    {
        productNames = AppManager.Instance.ProductCollector.ProductList;
        UpdateList();
    }

    private void UpdateList()
    {
        foreach (var productName in productNames)
        {
            var newProduct = Instantiate(productPrefab, container);
            newProduct.GetComponent<PickedProductBehaviour>().SetProductName(productName);
            products.Add(newProduct);
        }
    }

    private void ClearList()
    {
        foreach (var product in products)
        {
            Destroy(product);
        }
    }

    private void OnDisable()
    {
        ClearList();
    }
}
