using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour
{

    //This script enables underwater effects. Attach to main camera.

    //Define variable
    public int underwaterLevel = 7;
    public GameObject water;

    //The scene's default fog settings
    private bool defaultFog = false;
    private Color defaultFogColor = new Color(0.5f,0.5f,0.5f,1.0f);
    private float defaultFogDensity = 0.01f;
    private Material defaultSkybox;
    private Material noSkybox;

    void Start()
    {
        RenderSettings.fog = false;
        //RenderSettings.fogColor = defaultFogColor;
        //RenderSettings.fogDensity = defaultFogDensity;
        //RenderSettings.skybox = defaultSkybox;
        //Set the background color
        //camera.backgroundColor = new Color(0, 0.4f, 0.7f, 1);
        defaultSkybox = RenderSettings.skybox;

    }

    void Update()
    {
        if (transform.position.y < water.transform.position.y)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
            RenderSettings.fogDensity = 0.7f;
            //RenderSettings.fogMode = FogMode.Linear;
            //RenderSettings.skybox = noSkybox;
        }
        else
        {
            RenderSettings.fog = defaultFog;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
            //RenderSettings.fogMode = FogMode.Linear;
            //RenderSettings.skybox = defaultSkybox;
        }
    }

    private void OnDestroy()
    {
        RenderSettings.fog = defaultFog;
        RenderSettings.fogColor = defaultFogColor;
        RenderSettings.fogDensity = defaultFogDensity;
        //RenderSettings.fogMode = FogMode.Linear;
        //RenderSettings.skybox = defaultSkybox;
    }

}
