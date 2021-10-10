using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadScene : MonoBehaviour
{
    public void sceneReload()
    {
        if(!gameObject.GetComponent<FieldType>().isRequiredAlert && !gameObject.GetComponent<FieldType>().isErrorMessage)
            Application.LoadLevel(Application.loadedLevel);
    }
}
