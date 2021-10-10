using UnityEngine.UI;
using UnityEngine;

[ExecuteAlways]
public class sliderValue : MonoBehaviour
{
    private FormController formContr;   // FormController script
    private Transform valueGmb;     // Slider's value

    void Update()
    {
        // Set valueGmb, if it's null
        if (valueGmb == null)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                getValueGmb(gameObject.transform.GetChild(i));
            }
        }
        else
        {
            try
            {
                // Get wholeNumbers boolean value from FormController script
                gameObject.GetComponent<Slider>().wholeNumbers = formContr.sliderFieldsWholeValue;
            }
            catch
            {
                gameObject.AddComponent<Slider>();
            }
            valueGmb.GetComponent<Text>().text = gameObject.GetComponent<Slider>().wholeNumbers ? gameObject.GetComponent<Slider>().value.ToString() : gameObject.GetComponent<Slider>().value.ToString("F" + formContr.sliderFieldsDecimalDigitsCount);
        }

        // Get formController script
        if (formContr == null)
        {
            Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
            foreach (Object obj in allGameobjects)
            {
                try
                {
                    GameObject gmb = GameObject.Find(obj.name);
                    if (gmb.GetComponent<FieldType>().isForm)
                    {
                        formContr = gmb.GetComponent<FormController>();
                        break;
                    }
                }
                catch
                {

                }
            }
        }
        else
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isSliderHolder && !gameObject.transform.GetChild(i).GetComponent<FieldType>().enableCustomAlignment)
                {
                    gameObject.transform.GetChild(i).GetComponent<RectTransform>().transform.localPosition = new Vector3(-23f + formContr.sliderFieldsHorizontal, 57f + formContr.sliderFieldsVertical, 0f);
                }
            }
        }
    }

    // Finding valueGmb via resursive function
    private void getValueGmb(Transform currGmb)
    {
        for (int index = 0; index < currGmb.transform.childCount; index++)
        {
            if (currGmb.transform.GetChild(index).transform.childCount > 0)
            {
                getValueGmb(currGmb.transform.GetChild(index));
            }
            else
            {
                if (currGmb.transform.GetChild(index).GetComponent<FieldType>().isSliderValue)
                {
                    valueGmb = currGmb.transform.GetChild(index);
                }

            }
        }
    }
}
