using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("Animals")]
    public List<Animal> ownedAnimals = new List<Animal>();
    public Animal animalPrefab;
    private Animal selectedAnimal;

    [Header("Frogs")]
    public AnimalData blueFrogData;
    public AnimalData brownFrogData;
    public AnimalData greenFrogData;
    public AnimalData pinkFrogData;

    [Header("Cows")]
    public AnimalData whiteCowData;
    public AnimalData brownCowData;
    public AnimalData blackCowData;
    public AnimalData spottedCowData;

    [Header("UI")]
    public TextMeshProUGUI coinCountText;
    public GameObject shopContainer;
    public GameObject menuContainer;
    public float totalCPD = 0f;
    private float coinCount = 10f;
    //private float timer = 0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinCount += (totalCPD/ 86400) * Time.deltaTime;
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
        BuyAnimal(5f, new AnimalData[] { brownFrogData, greenFrogData, blueFrogData, pinkFrogData });
    }

    public void BuyBird()
    {
        Debug.Log("Bird Bought");
    }

    public void BuyCat()
    {
        Debug.Log("Cat Bought");
    }

    public void BuyPig()
    {
        Debug.Log("Pig Bought");
    }

    public void BuyCow()
    {
        BuyAnimal(3906250f, new AnimalData[] { whiteCowData, brownCowData, blackCowData, spottedCowData });
    }
    public void BuyAlpaca()
    {
        Debug.Log("Alpaca Bought");
    }

    private void BuyAnimal(float cost, AnimalData[] variants)
    {
        if (coinCount >= cost)
        {
            Debug.Log("Animal Bought");
            coinCount -= cost;
            Vector2 spawnPosition = new Vector2(Random.Range(-8f, 9f), Random.Range(-4f, 5f));
            Animal animal = Instantiate(animalPrefab, spawnPosition, Quaternion.identity);
            animal.gameManager = this;
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            int rarityWeight = UnityEngine.Random.Range(0, 101);
            Debug.Log(rarityWeight);
            if (rarityWeight >= 95)
            {
                animal.Initialize(variants[3]);
            }
            else if (rarityWeight >= 80)
            {
                animal.Initialize(variants[2]);
            }
            else if (rarityWeight >= 50)
            {
                animal.Initialize(variants[1]);
            }
            else
            {
                animal.Initialize(variants[0]);
            }
            ownedAnimals.Add(animal);
            totalCPD += animal.data.coinsPerSecond;
        }
    }
    public void SelectAnimal(Animal animal)
    {

        // Clicking same animal = deselect
        if (selectedAnimal == animal)
        {
            selectedAnimal = null;
            menuContainer.SetActive(false);
            return;
        }

        // Select new animal
        selectedAnimal = animal;
        menuContainer.SetActive(true);
        Debug.Log("Updated selected animal");

        UpdateAnimalPanel(animal);
    }

    private void UpdateAnimalPanel(Animal animal)
    {
        //menuName.text = animal.data.animalName;
        //menuImage.image = animal.data.animalSprite;
        //menuRarity.text = animal.data.rarity;
        //menuProfit.text = animal.data.coinsPerSecond;
        //menuSellPrice.text = animal.data.sellPrice;
        menuContainer.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = animal.data.animalName;
        menuContainer.transform.GetChild(1).GetComponent<Image>().sprite = animal.data.animalSprite;
        menuContainer.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"{animal.data.rarity}";
        menuContainer.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Earning ${animal.data.coinsPerSecond} per day.";
        menuContainer.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = $"Sells for ${animal.data.sellPrice}.";
    }

    public void SellSelectedAnimal()
    {
        Debug.Log("Sell button was pressed");
        if (selectedAnimal == null)
            return;

        SellAnimal(selectedAnimal);
    }

    public void SellAnimal(Animal animal)
    {
        Debug.Log("Attempting to sell animal");
        ownedAnimals.Remove(animal); // this might be a problem later
        totalCPD -= animal.data.coinsPerSecond;
        coinCount += animal.data.sellPrice;
        selectedAnimal = null;
        menuContainer.SetActive(false);
        Destroy(animal.gameObject);
    }
}
