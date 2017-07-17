using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkersLocation : MonoBehaviour {

    public double Latitude;
    public double Longitude;

    private Vector3 PositionVector;

    void Start () {
        PositionVector = Vector3.back;
        updatePosition();
    }
	
    private void updatePosition()
    {
        PositionVector.x = (float)((Longitude - GPSVariablesController._instance.x0) * GPSVariablesController._instance.delta_X);
        PositionVector.y = (float)((Latitude - GPSVariablesController._instance.y0) * GPSVariablesController._instance.delta_Y);
        PositionVector /= GPSVariablesController._instance.constantMultiplier;
        transform.position = PositionVector;
    }
}
