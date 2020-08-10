using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyVersion;
    private GameObject effect;
   
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            effect = Instantiate(destroyVersion, transform.position, transform.rotation);
            effect.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
            Destroy(gameObject);
        }
    }
}
