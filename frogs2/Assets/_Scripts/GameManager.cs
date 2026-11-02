using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    [Header("Animals")]
    public List<Animal> ownedAnimals = new List<Animal>();
    public Animal animalPrefab;
    public AnimalData blueFrogData;
    public AnimalData brownFrogData;
    public AnimalData greenFrogData;
    public AnimalData pinkFrogData;

    [Header("UI")]
    public TextMeshProUGUI coinCountText;
    public GameObject shopContainer;
    public float totalCPS = 0f;
    private float coinCount = 10f;
    //private float timer = 0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinCount += totalCPS * Time.deltaTime;
        coinCountText.text = $"${coinCount:F2}";
    }


    public void OpenShop()
    {
        Debug.Log("Shop button pressed");
        shopContainer.SetActive(!shopContainer.activeInHierarchy);
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

    public void BuyFrog()
    {
        Debug.Log("Frog Bought");
        float cost = 1f;
        if (coinCount >= cost)
        {
            coinCount -= cost;
            Vector2 spawnPosition = new Vector2(Random.Range(-8f, 9f), Random.Range(-4f, 5f));
            Animal animal = Instantiate(animalPrefab, spawnPosition, Quaternion.identity);

            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            int rarityWeight = UnityEngine.Random.Range(0, 101);
            Debug.Log(rarityWeight);
            if (rarityWeight >= 95)
            {
                animal.Initialize(pinkFrogData);
            }
            else if (rarityWeight >= 80)
            {
                animal.Initialize(blueFrogData);
            }
            else if (rarityWeight >= 50)
            {
                animal.Initialize(greenFrogData);
            }
            else
            {
                animal.Initialize(brownFrogData);
            }
                ownedAnimals.Add(animal);
            totalCPS += animal.data.coinsPerSecond;
        }
    }

    public void BuyBird()
    {

    }

    public void BuyCat()
    {

    }

    public void BuyPig()
    {

    }

    public void BuyCow()
    {

    }

    public void BuyAlpaca()
    {

    }

}
