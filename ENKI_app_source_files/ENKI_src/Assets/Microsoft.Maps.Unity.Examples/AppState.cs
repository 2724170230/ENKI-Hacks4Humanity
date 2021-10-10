using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AppState : MonoBehaviour
{
    public GameObject TitleScreen;
	public GameObject ChecklistForm;
	public GameObject InfoForm;
	public GameObject GoButton;
	
	public Text _firstName;
	public Text _lastName;
	public Text _contact;
	public Toggle _distress;
	public Text _adults;
	public Text _children;
	public Text _elderly;
	public Toggle _disability;
	public Toggle _medical;
	public Text _additional;
	
	public GPSManager gps;
	
	// Start is called before the first frame update
    void Start()
    {
       //GoButton.SetActive(false); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // if (gps.currentLatitude != 0 && gps.currentLongitude != 0){
			//GoButton.SetActive(true);
		//}
    }
	
	public void ResetScreens(){
		TitleScreen.SetActive(true);
		InfoForm.SetActive(true);
		ChecklistForm.SetActive(true);
	}
	
	public void HideTitleScreen(){
		TitleScreen.SetActive(false);
	}
	
	public void HideChecklist(){
		ChecklistForm.SetActive(false);
	}
	
	public void HideForm(){
		InfoForm.SetActive(false);
	}
	
	public void SubmitForm()
	{
		Debug.Log("Submit");
		Debug.Log(_firstName.text);
		StartCoroutine(PostForm());
		HideForm();
		Debug.Log("DONE");
	}

	IEnumerator PostForm()
	{
		WWWForm form = new WWWForm();
		//form.AddField("latitude", _firstName.text);
		//form.AddField("longitude", _firstName.text);
		form.AddField("firstname", _firstName.text);
		form.AddField("lastname", _lastName.text);
		form.AddField("contact", _contact.text);
		if (_distress.isOn){
			form.AddField("status", "1");
		}else{
			form.AddField("status", "3");
		}
		form.AddField("adults", _adults.text);
		form.AddField("children", _children.text);
		form.AddField("elderly", _elderly.text);
		if (_disability.isOn){
			form.AddField("disability", "1");
		}else{
			form.AddField("disability", "0");
		}
		if (_medical.isOn){
			form.AddField("medical", "1");
		}else{
			form.AddField("medical", "0");
		}
		form.AddField("additional", _additional.text);
		form.AddField("Content-Type", "text/csv");

		using (UnityWebRequest www = UnityWebRequest.Post("www.link.com", form))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("Post Request Complete!");
			}
		}
	}
}
