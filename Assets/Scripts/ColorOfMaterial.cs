using UnityEngine;

public class ColorOfMaterial : MonoBehaviour
{
    public Color[] colors;
    public static ColorOfMaterial instance;
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
}
