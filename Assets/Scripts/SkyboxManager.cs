using System.Collections;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public float timeOfDay;
    public float dayDuration = 30f;
    public Material[] days;
    private int prev = 0;
    private int next = 1;
   
    private void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay >= 1)
        {
            //RenderSettings.skybox.Lerp(days[prev], days[next], timeOfDay);
            RenderSettings.skybox = days[next];
            prev++;
            next++;
            if(prev == days.Length - 1 && next == days.Length)
            {
                prev = 0;
                next = 1;
            }
            timeOfDay -= 1;
        }
       
    }
   
}
