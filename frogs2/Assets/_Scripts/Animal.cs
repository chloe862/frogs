using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public AnimalData data;
    public GameManager gameManager;
    public GameObject menu;

    public void Sell()
    {
        gameManager.SellAnimal(this);
    }

    private void OnMouseDown()
    {
        gameManager.SelectAnimal(this);
    }

    public void Initialize(AnimalData animalData)
    {
        data = animalData;
        spriteRenderer.sprite = data.animalSprite;
    }
}