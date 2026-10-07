using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFalling = false;

    void Awake()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("TriggerPlatform: Rigidbody not found on parent!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling && rb != null)
        {
            isFalling = true;
            Invoke(nameof(FallDown), 0.1f);
        }
    }

    void FallDown()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            Destroy(rb.gameObject, 4f);
        }
    }
}
