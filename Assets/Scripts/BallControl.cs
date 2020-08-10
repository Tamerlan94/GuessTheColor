using UnityEngine;

public class BallControl : MonoBehaviour
{
    public event System.Action<Color> ChangeColorEvent;
    public event System.Action EndGameStarted;

    private Renderer _renderer;    
    public Color currentColor;

    private Rigidbody rb;
    public float speed;
    private float endTime = 30f;
    private float time;

    public AudioClip sound;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        //первоначальный цвет шара
       // _renderer.material.color = ColorOfMaterial.instance.colors[0];
        //текущее значение цвета 
        currentColor = _renderer.material.color;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time > endTime)
        {
            speed = Random.Range(4f, 5.2f);
            time = 0f;
        }
    }
    void ChangeColor()
    {
        int randomColor = Random.Range(0, ColorOfMaterial.instance.colors.Length);
        //меняем цвет шара на цвет из массива
        _renderer.material.color = ColorOfMaterial.instance.colors[randomColor];
        //текущее значение записываем вполе
        currentColor = _renderer.material.color;
        //вызываем делегат
        ChangeColorEvent?.Invoke(currentColor);
    }
    //при входе коллизии(шар опускается)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            AudioManager.instance.PlaySfx(sound);

            if (CheckColor(collision.gameObject.GetComponent<Renderer>()))
            {
                Debug.Log("Цвета совпали");
                //набор очков
                ScoreManager.instance.AddScore(1);
            }
            else
            {
                Debug.Log("Цвета не совпали - конец игры");
                ScoreManager.instance.AddHiScore();
                EndGameStarted?.Invoke();
            } 
        }

        if (collision.gameObject.CompareTag("EndGame"))
        {
            ScoreManager.instance.AddHiScore();
            EndGameStarted?.Invoke();
        }
    }
    //при выходе из коллизии(шар поднимается вверх)
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ChangeColor();
            //Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
        
    }
    private bool CheckColor(Renderer platform)
    {
        if(platform.material.color == currentColor)
        {
            return true;
        }
        return false;
    }
}
