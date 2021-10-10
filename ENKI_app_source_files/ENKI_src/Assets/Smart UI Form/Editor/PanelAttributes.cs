using UnityEngine;

[ExecuteAlways]
//Unity panel attributes
public class PanelAttributes : MonoBehaviour
{
    [UnityEditor.MenuItem("Form/Create Form/Registration")]
    public static void addRegistrationForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Registration"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Hotel Reservation")]
    public static void addHotelReservationForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Hotel Reservation"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Store Purchasing")]
    public static void addStorePurchasingForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Store Purchasing"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Rate Service")]
    public static void addRateServiceForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Rate Service"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Music Contest (Dynamic Form)")]
    public static void addMusicContestForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Music Contest (Dynamic Form)"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Examination")]
    public static void addExaminationForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Examination Form"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Game Options")]
    public static void addGameOptionsForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Game Options"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Log In")]
    public static void addLogInForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Log In"));
    }

    [UnityEditor.MenuItem("Form/Create Form/Blank Form")]
    public static void addBlankForm()
    {
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFormGmb)
                {
                    gmb.SetActive(false);
                }
            }
            catch
            {

            }
        }
        Instantiate(Resources.Load<GameObject>("Prefabs/Blank Form"));
    }

    [UnityEditor.MenuItem("Form/Add Field/Input Field/Firstname")]
    public static void addFirstname()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Firstname"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Lastname")]
    public static void addLastname()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Lastname"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Username")]
    public static void addUsername()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Username"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Password")]
    public static void addPassword()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Password"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Email Address")]
    public static void addEmail()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Email Address"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Integer Number")]
    public static void addIntegerNumber()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Integer Number"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Decimal Number")]
    public static void addInputField()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Decimal Number"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Alphanumeric")]
    public static void addAlphanumeric()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Alphanumeric"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Input Field/Autocorrected")]
    public static void addAutocorrected()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Autocorrected"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Checkbox")]
    public static void addCheckbox()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Checkbox"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }

    [UnityEditor.MenuItem("Form/Add Field/Radio Buttons")]
    public static void addRadioButtons()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Radio Buttons"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Dropdown")]
    public static void addDropdown()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Dropdown"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Slider")]
    public static void addSlider()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Slider"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Rating")]
    public static void addRating()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Rating"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Toggle")]
    public static void addToggle()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Toggle"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Custom Text")]
    public static void addCustomText()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Custom Text"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Field/Horizontal Radio Buttons")]
    public static void addHorizontalRadioField()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Horizontal Radio Buttons"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Address")]
    public static void addCustomFieldAddress()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Address"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Date or Birthday")]
    public static void addCustomFieldBirthday()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Date(Birthday)"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Time")]
    public static void addCustomTimeField()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Time"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Full Name")]
    public static void addCustomFieldFullName()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Full Name"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Credit Card")]
    public static void addCustomFieldCreditCard()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Credit Card"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Delivery Options")]
    public static void addCustomFieldDeliveryOptions()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Delivery Options"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
    [UnityEditor.MenuItem("Form/Add Custom/Comments")]
    public static void addCustomFieldComments()
    {
        string storeFieldsContainerName = "Fields Container";
        Object[] allGameobjects = GameObject.FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allGameobjects)
        {
            try
            {
                GameObject gmb = GameObject.Find(obj.name);
                if (gmb.GetComponent<FieldType>().isFieldsContainer)
                {
                    storeFieldsContainerName = obj.name;
                    break;
                }
            }
            catch
            {

            }
        }
        try
        {
            GameObject gmb = Instantiate(Resources.Load<GameObject>("Prefabs/Comments"));
            gmb.transform.parent = GameObject.Find(storeFieldsContainerName).transform;
            gmb.transform.localScale = new Vector2(1.465784f, 1.465784f);
        }
        catch
        {

        }
    }
}
