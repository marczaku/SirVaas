using UnityEngine;

public class Pikachu : MonoBehaviour
{
    public void OnEaten()
    {
        Vector3 newPosition = Vector3.zero;
        newPosition.x = Random.Range(-4, 5);
        newPosition.y = Random.Range(-4, 5);
        newPosition.z = -1;
        transform.position = newPosition;
    }
}