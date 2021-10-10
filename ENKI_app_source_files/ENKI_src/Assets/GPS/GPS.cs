using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GPS : MonoBehaviour
{
    public BlinkGameObject blinkObj;
	
	public Text gpsOut;
	public Text gpsTarget;
	public Text gpsDistance;
	public GameObject compassObject;
	
	public Dropdown dd;
	//
	public AudioClip[] audioClips;
	public AudioSource audio;
	//
    public bool isUpdating;
	
	private double location1_x = 48.045968145835324;
	private double location1_y = 8.44345857366174;
	private double location2_x = 48.04549867993822;
	private double location2_y = 8.44368806422589f;
	private double location3_x = 48.044302194422606;
	private double location3_y = 8.443646018614285;
	private double location4_x = 48.04432819590795;
	private double location4_y = 8.443574940081163;
	private double location5_x = 48.04422144982683;
	private double location5_y = 8.444451887947997;
	private double location6_x = 48.043860353200046;
	private double location6_y = 8.443488559091316;
	private double location7_x = 48.044488173124364;
	private double location7_y = 8.444357247921243;
	
	IEnumerator coroutine;

	void Awake(){
		audio = GetComponent<AudioSource>();
	}
	
    public void SetTargetLocation(){
		if (dd.value==0){
			gpsTarget.text = location1_x + ", " + location1_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location1_y, location1_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location1_y, location1_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[0];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		if (dd.value==1){
			gpsTarget.text = location2_x + ", " + location2_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location2_y, location2_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location2_y, location2_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[1];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		if (dd.value==2){
			gpsTarget.text = location3_x + ", " + location3_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location3_y, location3_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location3_y, location3_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[2];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		if (dd.value==3){
			gpsTarget.text = location4_x + ", " + location4_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location4_y, location4_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location4_y, location4_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[3];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		if (dd.value==4){
			gpsTarget.text = location5_x + ", " + location5_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location5_y, location5_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location5_y, location5_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[4];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		if (dd.value==5){
			gpsTarget.text = location6_x + ", " + location6_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location6_y, location6_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location6_y, location6_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[5];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		if (dd.value==6){
			gpsTarget.text = location7_x + ", " + location7_y;
			gpsDistance.text = distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location7_y, location7_x).ToString();
			if (distance(Input.location.lastData.latitude, Input.location.lastData.longitude, location7_y, location7_x) < 10){
				if (!audio.isPlaying){
					blinkObj.blinkFlag = true;
					audio.clip = audioClips[6];
					audio.Play();
				}
			}else{
				audio.Stop();
			}
		}
		
	}

    private void Update()
    {
        if (!isUpdating)
        {
            
            //isUpdating = !isUpdating;
        }
		
		// Orient Compass object to point to magnetic north.
        // compassObject.transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
    }
	
    IEnumerator Start()
    {
        coroutine = updateGPS();
		
		if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            gpsOut.text = "Timed out";
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsOut.text = "Unable to determine device location";
               print("Unable to determine device location");
            yield break;
        }
        else
        {
            gpsOut.text = Input.location.lastData.latitude + ", " + Input.location.lastData.longitude + " "; //+ Input.location.lastData.altitude+100f + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            // Access granted and location value could be retrieved
            //print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			StartCoroutine(coroutine);
		}

        // Stop service if there is no need to query location updates continuously
        //isUpdating = !isUpdating;
        //Input.location.Stop();
    }
	
	IEnumerator updateGPS()
    {
        float UPDATE_TIME = 0.25f; //Every  0.25 seconds
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);

        while (true)
        {
			gpsOut.text = Input.location.lastData.latitude + ", " + Input.location.lastData.longitude + " ";
            SetTargetLocation();
			// Check Distance and Trigger Audio Playback
			
			//longitudeText.text = "Longitude: " + Input.location.lastData.longitude;
            //latitudeText.text = "Latitude: " + Input.location.lastData.latitude;
            yield return updateTime;
        }
    }
	
	void stopGPS()
    {
        Input.location.Stop();
        StopCoroutine(coroutine);
    }

    void OnDisable()
    {
        stopGPS();
    }
	
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//:::                                                                         :::
	//:::  This routine calculates the distance between two points (given the     :::
	//:::  latitude/longitude of those points). It is being used to calculate     :::
	//:::  the distance between two locations using GeoDataSource(TM) products    :::
	//:::                                                                         :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

	private double distance(double lat1, double lon1, double lat2, double lon2) {
	  if ((lat1 == lat2) && (lon1 == lon2)) {
		return 0;
	  }
	  else {
		double theta = lon1 - lon2;
		double dist = Mathf.Sin((float)deg2rad(lat1)) * Mathf.Sin((float)deg2rad(lat2)) + Mathf.Cos((float)deg2rad(lat1)) * Mathf.Cos((float)deg2rad(lat2)) * Mathf.Cos((float)deg2rad(theta));
		dist = Mathf.Acos((float)dist);
		dist = rad2deg(dist);
		dist = dist * 60f * 1.1515;
		//
		dist = dist * 1609.344; // Convert to Meters
		return (dist);
	  }
	}

	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//::  This function converts decimal degrees to radians             :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	private double deg2rad(double deg) {
	  return (deg * Mathf.PI / 180.0);
	}

	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//::  This function converts radians to decimal degrees             :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	private double rad2deg(double rad) {
	  return (rad / Mathf.PI * 180.0);
	}

	private void VibrateDevice()
    {
        Handheld.Vibrate();
    }
  
}

