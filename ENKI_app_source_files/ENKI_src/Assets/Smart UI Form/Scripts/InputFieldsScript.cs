using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class InputFieldsScript : MonoBehaviour,
    ISelectHandler,
    IDeselectHandler


{
    private FormController formContr;   // FormController script
    public bool selected = false;   // Input Field state
    private bool deleteInputFieldBackground = false;
    private float storeOpacity = 0f; // Stores background opacity

    // Input Field select action
    public void OnSelect(BaseEventData evd)
    {
    selected = true;
    }

    // Input Field  deselect action
    public void OnDeselect(BaseEventData eventData)
    {
        selected = false;
    }

    private void Update()
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
        else
        {
            if (!gameObject.GetComponent<FieldType>().enableCustomAlignment)
            {
                // Set gameobject position
                gameObject.transform.GetComponent<RectTransform>().transform.localPosition = new Vector3(-35f + formContr.inputFieldsHorizontal, -3f + formContr.inputFieldsVertical, 0f);
            }
            if (!gameObject.GetComponent<FieldType>().enableCustomDesign)
            {
                if (!formContr.inputFieldsHideBackground)
                {
                    if (deleteInputFieldBackground)
                    {
                        formContr.setOpacity(gameObject.transform, storeOpacity);
                        deleteInputFieldBackground = false;
                    }
                }
                else if (!deleteInputFieldBackground)
                {
                    // Hide background
                    storeOpacity = gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold * 255f;
                    formContr.setOpacity(gameObject.transform, 0f);
                    deleteInputFieldBackground = true;
                }
                Sprite smoothBackground = Resources.Load<Sprite>(gameObject.GetComponent<FieldType>().isCustomCommentsHolder ? "PNG/yourCommentsBackground" : "PNG/smoothBackground");
                try
                {
                    if (formContr.inputFieldsSmoothBackground)
                    {
                        gameObject.GetComponent<Image>().sprite = smoothBackground;
                    }
                    else
                        gameObject.GetComponent<Image>().sprite = null;
                }
                catch
                {

                }
            }
        }

        for (int index = 0; index < gameObject.transform.childCount; index++)
        {
            try
            {
                if (gameObject.transform.GetChild(index).GetComponent<Text>())
                {
                    if (!gameObject.GetComponent<FieldType>().enableCustomDesign)
                    {
                        // Setting text wrap modes
                        gameObject.transform.GetChild(index).GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Wrap;
                        gameObject.transform.GetChild(index).GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
                    }
                    if ((!formContr.inputFieldsHideBackground && formContr.isValid) || (!formContr.isValid && formContr.requiredActionIndex == 0))
                    {
                        if (selected)
                        {
                            // Input field active mode action
                            gameObject.GetComponent<Image>().color = Color.Lerp(gameObject.GetComponent<Image>().color, formContr.activeInputFieldsBackgroundColor, Time.deltaTime * formContr.inputFieldsBackgroundChangeSpeed);
                            formContr.setFontColor(gameObject.transform.GetChild(index), formContr.activeInputFieldsFontColor);
                        }
                        else
                        {
                            // Input field not active mode action
                            gameObject.GetComponent<Image>().color = Color.Lerp(gameObject.GetComponent<Image>().color, formContr.normalInputFieldsBackgroundColor, Time.deltaTime * formContr.inputFieldsBackgroundChangeSpeed);
                            formContr.setFontColor(gameObject.transform.GetChild(index), formContr.normalInputFieldsFontColor);
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }

}