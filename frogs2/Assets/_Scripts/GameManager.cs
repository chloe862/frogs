using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Canvas canvas;


    void Start()
    {
        //Transform buttonShopTransform = canvas.transform.GetChild(0).transform.Find("ButtonShop");

        //if (buttonShopTransform != null)
        //{
        //    Button buttonShop = buttonShopTransform.GetComponent<Button>();
        //    buttonShop.onClick.AddListener(OpenShop);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShop()
    {
        Debug.Log("Shop button pressed");
    }

    public void OpenFish()
    {
        Debug.Log("Fish button pressed");
    }

    public void OpenCatalogue()
    {
        Debug.Log("Catalogue button pressed");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button pressed");
    }
}
