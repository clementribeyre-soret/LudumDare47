using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    public float minY = -6;
    public float maxX = 10;
    

    public void Update()
    {
        if(transform.position.y < minY || transform.position.x < -maxX || transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
    }
}