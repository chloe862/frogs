using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Animals")]
    public List<Animal> ownedAnimals = new List<Animal>();
    public Animal animalPrefab;
    public AnimalData treeFrogData;
    public AnimalData PoisonDartFrogData;

    [Header("UI")]
    public TextMeshProUGUI coinCountText;
    public float totalCPS = 1f;
    private float coinCount = 0f;
    private float timer = 0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            foreach (Animal animal in ownedAnimals)
            {
                totalCPS += animal.data.coinsPerSecond;
            }
            coinCount += totalCPS;
            coinCountText.text = "$" + coinCount.ToString();

            timer -= 1f;
        }
    }

    public void OpenShop()
    {
        Debug.Log("Shop button pressed");

        Vector2 spawnPosition = new Vector2(Random.Range(-8, 9), Random.Range(-4, 5));

        Animal animal = Instantiate(animalPrefab, spawnPosition, Quaternion.identity);
        animal.Initialize(treeFrogData);
        ownedAnimals.Add(animal);
        Debug.Log(ownedAnimals);
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
