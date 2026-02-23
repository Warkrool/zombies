using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            Destroy(gameObject);
        }
    }
}
