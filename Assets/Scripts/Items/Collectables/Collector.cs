using UnityEngine;

public class Collector : MonoBehaviour
{
    ICollectable collectable;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectable = collision.GetComponent<ICollectable>();

        if (collectable != null)
        {
            collectable.Collect();
        }
    }
}
