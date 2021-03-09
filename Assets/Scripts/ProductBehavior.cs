using UnityEngine;
using UnityEngine.UI;

public class ProductBehavior : MonoBehaviour
{
      
    [SerializeField] private Text product;
    [SerializeField] private Toggle toggle;

    private bool isToggled = false;
    private string productName;
    private ProductCollector productCollector;

    private void Awake()
    {
        productName = product.text;
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
