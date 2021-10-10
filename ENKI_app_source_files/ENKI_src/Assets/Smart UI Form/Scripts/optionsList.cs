using UnityEngine;

[ExecuteAlways]
public class optionsList : MonoBehaviour
{
    private FormController formContr;   // FormController script
    public bool isCheckboxContainer;    // For choosing between Radio Buttons and Checkbox containers
    private float horizontal, vertical, padding;    // positioning attributes

    void Update()
    {
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

        //  Choose necessary values
        if (isCheckboxContainer)
        {
            horizontal = formContr.checkboxFieldsHorizontal;
            vertical = formContr.checkboxFieldsVertical;
            padding = formContr.checkboxFieldsPadding;
        }
        else
        {
            horizontal = formContr.radioButtonFieldsHorizontal;
            vertical = formContr.radioButtonFieldsVertical;
            padding = formContr.radioButtonFieldsPadding;
        }

        
        for (int index = 0; index < gameObject.transform.childCount; index++)
        {
            // Setting gameobject position
            if(!gameObject.GetComponent<FieldType>().enableCustomAlignment)
                gameObject.transform.GetChild(index).GetComponent<RectTransform>().transform.localPosition = new Vector3(-520f + horizontal * 3f, 170f - (gameObject.transform.GetChild(index).transform.localScale.x - 2f + vertical + (padding * 3f + 230f) * index), 0);
        }
    }
}
