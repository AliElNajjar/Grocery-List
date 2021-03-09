using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    private List<ProductBehavior> allProducts;

    [SerializeField] private InputField input;

    private void Awake()
    {
        allProducts = new List<ProductBehavior>(FindObjectsOfType<ProductBehavior>());
    }


    public void ShowSearchResults()
    {
        if (string.IsNullOrEmpty(input.text))
        {
            foreach (var product in allProducts)
            {
                product.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (var product in allProducts)
            {
                if (!product.ProductName.Contains(input.text))
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
