using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public AnimalData data;

    public void Initialize(AnimalData animalData)
    {
        data = animalData;
        spriteRenderer.sprite = data.animalSprite;
    }
}