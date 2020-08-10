using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
       
    private void Update()
    {
        float step = speed * Time.deltaTime;
        if(Vector3.Distance(transform.position, new Vector3(0f, transform.position.y, transform.position.z)) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, transform.position.y, transform.position.z), step);
        }
    }
        
    
}
