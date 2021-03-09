using UnityEngine;
using UnityEngine.UI;

public class CustomProductBehavior : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] GameObject productPrefab;
    [SerializeField] Transform content;

    private string productName;
    //private List<GameObject> customProducts = new List<GameObject>();

    public void ConfirmNewProduct()
    {
        productName = input.text;

        if (!productName.Equals(string.Empty))
        {
            var newProduct = Instantiate(productPrefab, content);
            newProduct.GetComponent<ProductBehavior>().SetProductName(productName);
            //customProducts.Add(newProduct); If needed to clear later
        }

        input.text = string.Empty;
    }
}
