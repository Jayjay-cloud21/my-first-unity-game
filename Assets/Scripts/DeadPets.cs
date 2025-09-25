using UnityEngine;

public class DeadPets : MonoBehaviour
{
    [SerializeField] Sprite deadSprite;

    [SerializeField] Sprite currSprite;
    public GameObject pet;
    public void HitPole()
    {
        currSprite = deadSprite;
        // if pet dies, the dead sprite will be used and its collider will not be used
        pet.GetComponent<SpriteRenderer>().sprite = currSprite;
        // pet.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void OutOfBounds()
    {
        currSprite = deadSprite;

        pet.GetComponent<SpriteRenderer>().sprite = currSprite;
        // pet.GetComponent<CircleCollider2D>().enabled = false;
    }

}
