using UnityEngine;

public class SphereEjector : MonoBehaviour
{
    public GameObject spherePrefab;
    public float ejectionForce = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject sphere = Instantiate(spherePrefab, transform.position, transform.rotation);
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * ejectionForce);
        }
    }
}