using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using Microsoft.Maps.Unity;

public class GPSManager : MonoBehaviour
{
    //public BlinkGameObject blinkObj;
	//public Text gpsOut;
	//public Text gpsTarget;
	//public Text gpsDistance;
	//
	public float currentLongitude;
	public float currentLatitude;
	//
	//public AudioClip[] audioClips;
	//public AudioSource audioSrc;
	//
   IEnumerator Start()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			currentLongitude = Input.location.lastData.longitude;
			currentLatitude = Input.location.lastData.latitude;
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
  
}

