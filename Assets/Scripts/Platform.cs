using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 0.2f;
    [SerializeField] private float destroyDelay = 1f;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", fallDelay);
        }
    }

    private void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, destroyDelay);
    }
}