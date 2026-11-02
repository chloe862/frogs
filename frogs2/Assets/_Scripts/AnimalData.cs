using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class AnimalData : ScriptableObject
{
    public string animalName;
    public Sprite animalSprite;

    public float coinsPerSecond;
    public int purchaseCost;

    public bool rare;
}
