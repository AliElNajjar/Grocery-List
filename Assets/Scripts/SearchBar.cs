using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : Singleton<SearchBar>
{
    private List<ProductBehavior> allProducts;

    [SerializeField] private InputField input;

    protected override void Awake()
    {
        base.Awake();
        allProducts = new List<ProductBehavior>(FindObjectsOfType<ProductBehavior>());
    }

    public void AddNewProduct(ProductBehavior product)
    {
        allProducts.Add(product);
    }

    public void ShowSearchResults()
    {
        if (string.IsNullOrEmpty(input.text))
        {
            foreach (var product in allProducts)
            {
                product.gameObject.SetActive(true);
            }

            input.text = string.Empty;
        }
        else
        {
            foreach (var product in allProducts)
            {
                if (!product.ProductName.ToLower().Contains(input.text.ToLower()))
                {
                    product.gameObject.SetActive(false);
                }

                else
                {
                    product.gameObject.SetActive(true);
                }
            }
        }
    }
}
