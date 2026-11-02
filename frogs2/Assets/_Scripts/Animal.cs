using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public AnimalData data;
    public GameManager gameManager;

    private void OnMouseDown()
    {
        Debug.Log("Animal Selected");
        gameManager.SelectAnimal(this);
    }

    public void Initialize(AnimalData animalData)
    {
        data = animalData;
        spriteRenderer.sprite = data.animalSprite;

    }

    public void Sell()
    {
        gameManager.SellAnimal(this);
    }
}