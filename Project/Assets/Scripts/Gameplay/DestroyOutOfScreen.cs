using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    public float minY = -6;
    

    public void Update()
    {
        if(transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}