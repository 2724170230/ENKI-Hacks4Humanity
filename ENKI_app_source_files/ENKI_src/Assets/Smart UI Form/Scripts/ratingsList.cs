using UnityEngine.UI;
using UnityEngine;

[ExecuteAlways]
public class ratingsList : MonoBehaviour
{
    private FormController formContr;   // FormController script attribute
    private float horizontal, vertical, padding;    // positioning attributes
    private Sprite activeShape, notActiveShape;     // Active and not active shapes
    private string activeShapeLocation, notActiveShapeLocation;     // Active and not active shapes locations
    public int value = -1, hoverValue = -1;     // Value is the fixed quantity, hoverValue is changing with onMouseEnter
    private Color activeColor, notActiveColor; // Local action colors

    void Update()
    {
        // Reset rating if it's value is bigger than rating count
        if(value > gameObject.transform.childCount)
        {
            value = -1;
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
        }else if(!gameObject.GetComponent<FieldType>().enableCustomDesign && !gameObject.transform.parent.GetComponent<FieldType>().enableCustomDesign)
        {
            activeColor = formContr.ratingFieldsActiveColor;
            notActiveColor = formContr.ratingFieldsNotActiveColor;
        }

        // Update local variables from formController script
        horizontal = formContr.ratingFieldsHorizontal;
        vertical = formContr.ratingFieldsVertical;
        padding = formContr.ratingFieldsPadding;

        // Choose necessary shape location
        if (formContr.ratingFieldsIsStar)
        {
            activeShapeLocation = "PNG/filledStar";
            notActiveShapeLocation = "PNG/emptyStar";
        }
        else
        {
            activeShapeLocation = "PNG/handle";
            notActiveShapeLocation = "PNG/emptyRating";
        }

        // Get shape via chosen location
        try
        {
            activeShape = Resources.Load<Sprite>(activeShapeLocation);
            notActiveShape = Resources.Load<Sprite>(notActiveShapeLocation);
        }
        catch
        {
            Debug.Log("Necessary shape not found, try different location");
        }

        // Rating action code
        for (int index = 0; index < gameObject.transform.childCount; index++)
        {

                if (gameObject.transform.GetChild(index).GetComponent<FieldType>().isRating)
                {
                    formContr.setSizes(gameObject.transform.GetChild(index), formContr.ratingFieldsWidth, formContr.ratingFieldsHeight);
                    Sprite shape;

                    if (!gameObject.GetComponent<FieldType>().enableCustomAlignment)
                    {
                        gameObject.transform.GetChild(index).GetComponent<RectTransform>().transform.localPosition = new Vector3(-348f + horizontal * 3f + (padding * 3f + 85f) * index, 10 -(gameObject.transform.GetChild(index).transform.localScale.x - 2f + vertical), 0);
                    }
                    if (hoverValue > -1)
                    {
                        if (index <= hoverValue)
                        {
                            shape = activeShape;
                            setColor(gameObject.transform.GetChild(index), activeColor);
                        }
                        else
                        {
                            shape = notActiveShape;
                            setColor(gameObject.transform.GetChild(index), notActiveColor);
                        }
                    }
                    else if (index <= value)
                    {
                        shape = activeShape;
                        setColor(gameObject.transform.GetChild(index), activeColor);
                    }
                    else
                    {
                        shape = notActiveShape;
                        setColor(gameObject.transform.GetChild(index), notActiveColor);
                    }
                    try
                    {
                        gameObject.transform.GetChild(index).GetComponent<Image>().sprite = shape;
                    }
                    catch
                    {
                        Debug.Log("Necessary shape not found, try different location");
                    }
                }
        }
 }

    //Set rating shape color
    private void setColor(Transform currElement, Color color)
    {
        try
        {
            currElement.GetComponent<Image>().color = color;
        }
        catch
        {
            //Debug.Log("Rating element Image not set");
        }
    }
}
