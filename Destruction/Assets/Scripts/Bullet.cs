using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Prop"))
        {
            PropBehavior prop = other.GetComponent<PropBehavior>();
            if (prop != null && !prop.isFake)
            {
                GameManager.instance?.OnRealPropDestroyed();
            }

            Debug.Log(" Hit prop: " + other.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindAnyObjectByType<PlayerShooting>()?.ClearBullet();
        }
    }

}
