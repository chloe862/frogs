using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class AnimalData : ScriptableObject
{
    public string animalName;
    public Sprite animalSprite;
    public float coinsPerSecond;
    public float sellPrice;
    public Rarity rarity;
    public AnimalType animalType;


    public enum AnimalType
    {
        Frog,
        Bird,
        Cat,
        Pig,
        Cow,
        Alpaca
    }

    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

}
