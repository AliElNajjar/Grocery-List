using UnityEngine;
using UnityEngine.UI;

public class ProductBehavior : MonoBehaviour
{
      
    [SerializeField] private Text product;
    [SerializeField] private Toggle toggle;

    private bool isToggled = false;
    private string productName;
    private ProductCollector productCollector;

    public string ProductName => productName;

    private void Awake()
    {
        productName = gameObject.name;
        product.text = productName;
        productCollector = AppManager.Instance.ProductCollector;
    }

    public void SetProductName(string val)
    {
        product.text = val;
        productName = val;
        toggle.isOn = true;
    }

    public void ToggleProduct()
    {
        bool value = isToggled;
        isToggled = (value == false) ? true : false;

        productCollector.ProductToggled.Invoke(isToggled, this.productName);
    }
}
