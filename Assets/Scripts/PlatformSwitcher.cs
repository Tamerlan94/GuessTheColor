using UnityEngine;

public class PlatformSwitcher : MonoBehaviour
{
    public GameObject[] platforms;
    [SerializeField] public GameObject _platforma;

    public static PlatformSwitcher instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void MovePlatform(bool a, Color color)
    {
        if (a)
        {
            //движение направо
            if (_platforma != null)
            {
                Destroy(_platforma);
            }                
            _platforma = null;
            _platforma = Instantiate(platforms[0], new Vector3(-10f, 9f, 0f), Quaternion.identity);
            _platforma.GetComponent<Renderer>().material.color = color;
        }
        else
        {
            //движение налево
            if (_platforma != null)
            {
                Destroy(_platforma);
            }
            _platforma = null;
            _platforma = Instantiate(platforms[0], new Vector3(10f, 9f, 0f), Quaternion.identity);
            _platforma.GetComponent<Renderer>().material.color = color;
        }
    }
}
