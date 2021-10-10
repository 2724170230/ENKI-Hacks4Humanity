using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameObject : MonoBehaviour
{
    public GameObject blinkObject;
	private float blinkTime = 0.7f;
	public bool blinkFlag;
	
	// Start is called before the first frame update
    void Start()
    {
        blinkFlag = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (blinkFlag){
			blinkTime -= Time.deltaTime;
			if (blinkTime <0.2f){
				blinkObject.SetActive(false);
				if (blinkTime<0){
					blinkTime = 0.7f;
				}
			}else{
				blinkObject.SetActive(true);
			}
		}else{
			blinkObject.SetActive(true);
		}
    }
}
