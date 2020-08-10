using UnityEngine;

public class CloudMoving : MonoBehaviour
{
    public float speed;
    public bool rightMove;
    public bool leftMove;
    private void Update()
    {
        if (rightMove)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            if (transform.position.x > 9f)
            {
                transform.position = new Vector3(-9f, 13f, 3f);
            }
        }
        else if (leftMove)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            if (transform.position.x < -6f)
            {
                transform.position = new Vector3(9f, 12f, 0f);
            }
        }          
    }
}
