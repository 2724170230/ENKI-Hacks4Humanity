using UnityEngine.UI;
using UnityEngine;

[ExecuteAlways]
public class toggleChange : MonoBehaviour
{
    private GameObject otherGmb;    // Another toggle element
    private FormController formContr;   // FormController script attribute
    public bool isChecked;  // Toggle element state
    private Color activeColor, notActiveColor;  // Local action colors

    private void Update()
    {
        // Set another toggle element
        if (otherGmb == null)
        {
            for (int index = 0; index < gameObject.transform.parent.transform.childCount; index++)
            {
                if (gameObject.transform.parent.transform.GetChild(index).name != gameObject.name)
                {
                    otherGmb = gameObject.transform.parent.transform.GetChild(index).gameObject;
                }
            }
        }

        // Check if current toggle element isChecked
        if (isChecked)
        {
            // If yes, call toggleAction
            toggleAction();
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
        else if(!gameObject.GetComponent<FieldType>().enableCustomDesign && !gameObject.transform.parent.GetComponent<FieldType>().enableCustomDesign)
        {
            activeColor = formContr.toggleFieldsActiveColor;
            notActiveColor = formContr.toggleFieldsNotActiveColor;
        }
    }

    // Action for checked rating element
    public void toggleAction()
    {
        try
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(gameObject.GetComponent<Image>().color, activeColor, Time.deltaTime * 10f);
            otherGmb.GetComponent<Image>().color = Color.Lerp(otherGmb.GetComponent<Image>().color, notActiveColor, Time.deltaTime * 10f);
            changeTextColor(gameObject, notActiveColor);
            changeTextColor(otherGmb, activeColor);
        }
        catch
        {

        }
    }

    // Change toggle state
    public void changeChecked()
    {
        if(!isChecked)
        {
            isChecked = true;
            try
            {
                otherGmb.GetComponent<toggleChange>().isChecked = false;
            }
            catch
            {

            }
        }
    }

    //  Change toggle text color
    void changeTextColor(GameObject gmb, Color color)
    {
        for (int index = 0; index < gmb.transform.childCount; index++)
        {
            if (gmb.transform.GetChild(index).childCount > 0)
            {
                changeTextColor(gmb.transform.GetChild(index).gameObject, color);
            }
            try
            {
                gmb.transform.GetChild(index).GetComponent<Text>().color = color;
            }
            catch
            {

            }
        }
    }
}
