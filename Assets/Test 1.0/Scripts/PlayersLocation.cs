using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersLocation : MonoBehaviour
{
    public double Longitude;
    public double Latitude;

    private Vector3 PositionVector;
    
    public void Start()
    { 
        PositionVector = Vector3.zero;
    }

    public void Update()
    {
        UpdateGPSCoords();
        updatePosition();
    }

    private void UpdateGPSCoords()
    {
        Longitude = GPS._instande.longitude;
        Latitude = GPS._instande.latitude;
    }

    private void updatePosition()
    {
        PositionVector.x = (float)((Longitude - GPSVariablesController._instance.x0) * GPSVariablesController._instance.delta_X);
        PositionVector.y = (float)((Latitude - GPSVariablesController._instance.y0) * GPSVariablesController._instance.delta_Y);
        PositionVector /= GPSVariablesController._instance.constantMultiplier;
        transform.position = PositionVector;
    }
    
}
