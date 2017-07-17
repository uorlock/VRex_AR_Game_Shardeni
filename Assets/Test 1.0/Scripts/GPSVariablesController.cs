using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSVariablesController : MonoBehaviour {
    public static GPSVariablesController _instance;

    public GameObject MyMapGameObject;

    private GoogleMap Gmap;
    
    public float constantMultiplier = 1000000f;
    private float scale;

    public double y0; //latitude 0
    public double x0; //longitude 0 

    public const double Diameter_Y = 0.001281;
    public const double Diameter_X = 0.001716;

    public double delta_Y;
    public double delta_X;
    private GPSVariablesController _instance1;

    
    
    void Awake ()
    {
        _instance = this;

        Gmap = MyMapGameObject.GetComponent<GoogleMap>();

        x0 = Gmap.centerLocation.longitude - Diameter_X / 2;
        y0 = Gmap.centerLocation.latitude - Diameter_Y / 2;
        Debug.Log(x0);

        scale = MyMapGameObject.transform.localScale.x;
        scale *= constantMultiplier;
        delta_X = scale / Diameter_X;
        delta_Y = scale / Diameter_Y;
    }
}
