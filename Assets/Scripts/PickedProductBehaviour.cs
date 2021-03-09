using UnityEngine;
using UnityEngine.UI;

public class PickedProductBehaviour : MonoBehaviour
{
    [SerializeField] private Text productName;

    public void SetProductName(string val)
    {
        productName.text = val;
    }
}
