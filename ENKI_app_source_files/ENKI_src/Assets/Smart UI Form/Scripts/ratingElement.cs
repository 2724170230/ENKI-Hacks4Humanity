using UnityEngine;
using UnityEngine.EventSystems;

public class ratingElement : MonoBehaviour, IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler

{
    private ratingsList ratList;    // ratingList script
    private bool activateScaleHover;    // Enable onMouseEnter for ratings

    void Update()
    {
         //Check if ratingList script is attached to parent
        if(ratList == null)
        {
            try
            {
                ratList = gameObject.transform.parent.GetComponent<ratingsList>();
            }
            catch
            {
                // If not, attach it
                gameObject.transform.parent.gameObject.AddComponent<ratingsList>();
            }
        }

        // Scale hover action check
        if (activateScaleHover)
        {
            gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), Time.deltaTime * 10);
        }
        else
        {
            gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }
    }

    // Enable onMouseOver action
    public void OnPointerEnter(PointerEventData evd)
    {
        activateScaleHover = true;
        ratList.hoverValue = transform.GetSiblingIndex();
    }

    // Disable onMouseOver action
    public void OnPointerExit(PointerEventData evd)
    {
        activateScaleHover = false;
        ratList.hoverValue = -1;
    }

    // Fix value after click
    public void OnPointerClick(PointerEventData evd)
    {
        // Reset ratings, when clicked on active star
        if(ratList.value == transform.GetSiblingIndex())
        {
            ratList.value = -1;
        }
        else
        {
            ratList.value = transform.GetSiblingIndex();
        }
        activateScaleHover = false;
    }
}