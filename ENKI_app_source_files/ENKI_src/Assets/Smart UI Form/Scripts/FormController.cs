using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

[ExecuteAlways]
public class FormController : MonoBehaviour
{
    [HideInInspector]
    public bool isValid = true;
    private GameObject fieldsContainer;
    public int targetFrameRate = 200;

    [Space]
    [Header("Labels")]
    public bool hideAllLabels = false;
    public Font labelsFont;
    public int labelsFontSize = 80;
    public TextAnchor labelsTextAlign;
    public FontStyle labelsFontStyle;
    public Color labelsFontColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);

    [Space]
    [Header("Title")]
    public bool hideTitle = false;
    public bool hideTitleBackground = false;
    [Range(100f, 1500f)]
    public float titleBackgroundWidth = 500;
    [Range(20f, 500f)]
    public float titleBackgroundHeight = 140;
    public bool smoothTitleBackground = false;
    public Color titleBackgroundColor;
    public Font titleFont;
    public int titleFontSize = 65;
    public FontStyle titleFontStyle;
    public TextAnchor titleAlign;
    public Color titleFontColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);

    [Space]
    [Header("Fields")]
    public float fieldsPadding = 15;
    public float fieldsVertical = 0f;
    public float fieldsHorizontal = 0f;
    public Font fieldsFont;
    public FontStyle fieldsFontStyle;

    [Space]
    [Header("Background")]
    public bool hideBackground = false;
    public Sprite backgroundImage;
    public Color backgroundColor = new Color(61f / 255f, 61f / 255f, 61f / 255f, 222);
    public bool enableDynamicBackground = false;
    public Color[] changeColors;
    public float interval = 5f;
    [Range(0f, 4f)]
    public float smoothness = 1f;

    [Space]
    [Header("Submit Button")]
    [Range(0f, 5f)]
    public float submitButtonScale = 1.4f;
    [Range(50f, 1500f)]
    public float submitButtonWidth = 290f;
    [Range(30f, 300f)]
    public float submitButtoneHeight = 105f;
    public Color submitButtonColor;
    public Font submitButtonFont;
    public int submitButtonFontSize = 90;
    public FontStyle submitButtonFontStyle;
    public Color submitButtonFontColor;
    public bool smoothSubmitButton = true;

    [Space]
    [Header("Input Fields")]
    public bool inputFieldsHideLabel = false;
    public bool inputFieldsHidePlaceholder = false;
    [Range(50f, 380f)]
    public float inputFieldWidth = 300;
    [Range(10f, 100f)]
    public float inputFieldHeight = 45;
    public float inputFieldsVertical = 0f, inputFieldsHorizontal = 30f;
    public int inputFieldsFontSize = 90;
    public TextAnchor InputFieldsTextAlign;
    public Color normalInputFieldsFontColor = new Color(61f / 255f, 61f / 255f, 61f / 255f, 222), activeInputFieldsFontColor;
    public bool inputFieldsHideBackground = false;
    public Color normalInputFieldsBackgroundColor = new Color(61f / 255f, 61f / 255f, 61f / 255f, 222), activeInputFieldsBackgroundColor;
    public float inputFieldsBackgroundChangeSpeed = 5f;
    public bool inputFieldsSmoothBackground = true;

    [Space]
    [Header("Checkbox Fields")]
    public bool checkboxFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float checkboxFieldsScale = 0.135f;
    public float checkboxFieldsVertical = 0f, checkboxFieldsPadding = 20f, checkboxFieldsHorizontal = 20f;
    [Range(10f, 150f)]
    public float checkboxFieldsCheckAreaSize = 30f;
    public int checkboxFieldsFontSize = 65;
    public TextAnchor checkboxFieldsTextAlign;
    public bool checkboxFieldsSetTextActiveColor = true;
    public Color checkboxFieldsBackgroundNotActiveColor, checkboxFieldsBackgroundActiveColor, checkboxFieldsMarkColor, checkboxFieldsFontColor;

    [Space]
    [Header("Radio Button Fields")]
    public bool radioButtonFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float radioButtonFieldsScale = 0.15f;
    public float radioButtonFieldsVertical = 0f, radioButtonFieldsPadding = 20f, radioButtonFieldsHorizontal = 20f;
    [Range(10f, 150f)]
    public float radioButtonFieldsCheckAreaSize = 30f;
    public int radioButtonFieldsFontSize = 60;
    public TextAnchor radioButtonFieldsTextAlign;
    public bool radioButtonFieldsSetTextActiveColor = true;
    public Color radioButtonFieldsBackgroundNotActiveColor, radioButtonFieldsBackgroundActiveColor, radioButtonFieldsFontColor;

    [Header("Dropdown Fields")]
    public bool dropdownFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float dropdownFieldsScale = 1.25f;
    [Range(50f, 800f)]
    public float dropdownFieldsWidth = 125f;
    [Range(20f, 150f)]
    public float dropdownFieldsHeight = 40f;
    public float dropdownFieldsVertical = 10f, dropdownFieldsHorizontal = 30f;
    public int dropdownFieldsFontSize = 80;
    public Color dropdownFieldsFontColor = new Color(25f / 255f, 25f / 255f, 25f / 255f, 222);
    [Range(0.5f, 5f)]
    public float dropdownFieldsTemplateScale = 1f;
    public Color dropdownFieldsNormalColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public Color dropdownFieldsSelectedColor = new Color(25f / 255f, 25f / 255f, 25f / 255f, 222);
    public Color dropdownFieldsBackgroundColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public bool dropdownFieldsSmoothBackground = false;

    [Space]
    [Header("Slider Fields")]
    public bool sliderFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float sliderFieldsScale = 0.3f;
    public float sliderFieldsVertical, sliderFieldsHorizontal = 30f;
    public bool sliderFieldsHidePrefix = false;
    public bool sliderFieldsHidePostfix = false;
    public bool sliderFieldsHideValue = false;
    public int sliderFieldsFontSize = 70;
    public Color sliderFieldsFontColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public Color sliderFieldsHandleColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public Color sliderFieldsBackgroundColor = new Color(215f / 255f, 215f / 255f, 215f / 255f, 222);
    public Color sliderFieldsFilledAreaColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public bool sliderFieldsWholeValue = true;
    public Sprite sliderFieldsCustomHandleImage;
    public int sliderFieldsDecimalDigitsCount = 1;

    [Space]
    [Header("Rating Fields")]
    public bool ratingFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float ratingFieldsScale = 0.4f;
    [Range(0f, 500f)]
    public float ratingFieldsWidth = 100f, ratingFieldsHeight = 100f;
    public float ratingFieldsVertical = 0f, ratingFieldsPadding = 10f, ratingFieldsHorizontal = 20f;
    public bool ratingFieldsIsStar = true;
    public Color ratingFieldsActiveColor, ratingFieldsNotActiveColor;

    [Space]
    [Header("Toggle Fields")]
    public bool toggleFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float toggleFieldsScale = 0.7f;
    public float toggleFieldsVertical = 0f, toggleFieldsHorizontal = 0f;
    public int toggleFieldsFontSize = 105;
    public Color toggleFieldsActiveColor = new Color(215f / 255f, 215f / 255f, 215f / 255f, 222);
    public Color toggleFieldsNotActiveColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public bool toggleFieldsSmoothBackground = true;

    [Space]
    [Header("Custom Text Fields")]
    public bool customTextFieldsHideLabel = false;
    [Range(0f, 5f)]
    public float customTextFieldsScale = 0.5f;
    [Range(50f, 900f)]
    public float customTextFieldsWidth = 660f;
    [Range(10f, 150f)]
    public float customTextFieldsHeight = 105f;
    public float customTextFieldsVertical = 0f, customTextFieldsHorizontal = 0f;
    public Font customTextFieldsFont;
    public int customTextFieldsFontSize = 50;
    public TextAnchor customTextFieldsAlign;
    public FontStyle customTextFieldsFontStyle;
    public Color customTextFieldsFontColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);
    public bool customTextFieldsHideBackground = true;
    public Color customTextFieldsBackgroundColor = new Color(61f / 255f, 61f / 255f, 61f / 255f, 222);
    public bool customTextFieldsSmoothBackground = false;

    [Space]
    [Header("Back To Form / Required Fields Alert")]
    public string successfulSubmitionText = "Submitted Successfully!\nBack To Form";
    public string requiredFieldsAlertText = "Submition Failed!\nFill Required Fields, Please!";
    public string errorMessageText = "Something went wrong...\nCheck Your Internet Connection";
    public Color backToFormBackgroundColor = new Color(25f / 255f, 25f / 255f, 25f / 255f, 222);
    public Font backToFormFont;
    public int backToFormFontSize = 200;
    public int backToFormLineSpacing = 2;
    public TextAnchor backToFormAlign;
    public FontStyle backToFormFontStyle;
    public Color backToFormFontColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 222);

    [Space]
    [Header("After Submit Actions")]
    public AudioClip submitionSound;
    public AudioClip failedSubmitSound;
    public string changeSceneName = "";
    public float submitActionDelay = 0f;
    public bool showErrorMessage = true;
    public Color notValidColor = Color.red;
    public bool showRequiredAlert = true;
    [HideInInspector]
    public bool sendEmail = true;
    [HideInInspector]
    public string emailAddress = "", password = "";
    [HideInInspector]
    public string[] afterSubActions = new string[] { "None", "Show Back To Form", "Change Scene", "Hide Form" };
    [HideInInspector]
    public int actionIndex = 1;
    [HideInInspector]
    public string[] requiredActions = new string[] { "Labels", "Input Fields", "Labels and Input Fields" };
    [HideInInspector]
    public int requiredActionIndex = 0;

    // Local action variables, don't change
    private bool deleteCustomTextBackground = false, deleteTitleBackground = false;
    private int colorIndex = 0;
    private Transform backgroundTransform;
    private GameObject emailManager;
    private Animator backToFormAnim, requiredFieldsAlertAnim, errorMessageAnim;

    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        // Set required script
        attachRequiredScript(gameObject.transform);

        // Set required fieldsContainer
        getFieldsContainer(gameObject.transform);

        // Find background and activate it's dynamic change if condition result is truthy
        foreach(Transform element in gameObject.transform)
        {
            if (element.GetComponent<FieldType>().isBackground && !element.GetComponent<FieldType>().enableCustomDesign)
            {
                backgroundTransform = element;
                if (!hideBackground && enableDynamicBackground)
                {
                    StartCoroutine("dynamicBackground", interval);
                }
                else
                {
                    colorIndex = 0;
                }
            }

        }
    }

    private void Update()
    {
        // Set required script
        attachRequiredScript(gameObject.transform);

        // Set required fieldsContainer
        getFieldsContainer(gameObject.transform);

        //childCount = fieldsContainer.transform.childCount;

        int optCount = 0;
        float additionalHeight = 0f;

        // Setting area between fields
        for (int i = 0; i < fieldsContainer.transform.childCount; i++)
        {
            try
            {
                if(!fieldsContainer.transform.GetChild(i).GetComponent<FieldType>().enableCustomDesign)
                    fieldsContainer.transform.GetChild(i).transform.localScale = new Vector2(1.465784f, 1.465784f);
            }
            catch
            {

            }

            Transform currentChild = fieldsContainer.transform.GetChild(i);

            if(i > 0)
                {
                    try
                    {
                        if (fieldsContainer.transform.GetChild(i - 1).GetComponent<FieldType>().isCheckboxContainer)
                        {
                            for(int index = 0; index < fieldsContainer.transform.GetChild(i - 1).transform.childCount; index++)
                            {
                                try
                                {
                                    if (fieldsContainer.transform.GetChild(i - 1).transform.GetChild(index).GetComponent<FieldType>().isOptionsList)
                                    {
                                        optCount = fieldsContainer.transform.GetChild(i - 1).transform.GetChild(index).childCount;
                                        additionalHeight += optCount * checkboxFieldsPadding / 1.8f + optCount * 43 - 75f + checkboxFieldsVertical / 3.5f;
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }else if (fieldsContainer.transform.GetChild(i - 1).GetComponent<FieldType>().isRadioButtonsContainer)
                        {
                            for (int index = 0; index < fieldsContainer.transform.GetChild(i - 1).transform.childCount; index++)
                            {
                                try
                                {
                                    if (fieldsContainer.transform.GetChild(i - 1).transform.GetChild(index).GetComponent<FieldType>().isOptionsList)
                                    {
                                        optCount = fieldsContainer.transform.GetChild(i - 1).transform.GetChild(index).childCount;
                                        additionalHeight += optCount * radioButtonFieldsPadding / 1.6f + optCount * 53 - 98f + radioButtonFieldsVertical / 3.5f;
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                        else if (fieldsContainer.transform.GetChild(i - 1).GetComponent<FieldType>().isCustomComments)
                        {
                            additionalHeight += 120f;
                        }
                        else if (fieldsContainer.transform.GetChild(i - 1).GetComponent<FieldType>().isCustomAddress)
                        {
                            additionalHeight += 280;
                        }
                        else if (fieldsContainer.transform.GetChild(i - 1).GetComponent<FieldType>().isCustomBirthday)
                        {
                            additionalHeight += 27f;
                        }
                    }
                    catch
                    {
                        
                    }
                }
            if (!fieldsContainer.transform.GetChild(i).GetComponent<FieldType>().enableCustomAlignment)
            {
                fieldsContainer.transform.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(fieldsHorizontal, -708f + (fieldsContainer.transform.GetChild(i).transform.localScale.x > 0 ? 1 : 0) * (500f - additionalHeight - (fieldsContainer.transform.GetChild(i).transform.localScale.x - 2f + fieldsVertical + (fieldsPadding * 3.2f + 95f) * i)), 0);
            }
            if (currentChild.GetComponent<FieldType>().isRequired)
                addRequiredSign(currentChild);
            else
                removeRequiredSign(currentChild);

                // Setting Input Field parameters
                if (currentChild.GetComponent<FieldType>().isInputField)
                {
                    for(int ind = 0; ind < currentChild.transform.childCount; ind++)
                    {
                         if (currentChild.transform.GetChild(ind).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(ind), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(ind), labelsFontStyle);
                            setFontSize(currentChild.transform.GetChild(ind), labelsFontSize);
                            setTextAlign(currentChild.transform.GetChild(ind), labelsTextAlign);
                            if(isValid && requiredActionIndex != 1)
                                setFontColor(currentChild.transform.GetChild(ind), labelsFontColor);
                            setLabelsVisibility(currentChild.transform.GetChild(ind), inputFieldsHideLabel);
                        }else if (currentChild.transform.GetChild(ind).GetComponent<FieldType>().isInputFieldHolder && !currentChild.transform.GetChild(ind).GetComponent<FieldType>().enableCustomDesign)
                        {
                            if (!currentChild.transform.GetChild(ind).GetComponent<FieldType>().enableCustomDesign)
                            {
                                setFont(currentChild.transform.GetChild(ind), fieldsFont);
                                setFontStyle(currentChild.transform.GetChild(ind), fieldsFontStyle);
                                setTextAlign(currentChild.transform.GetChild(ind), InputFieldsTextAlign);
                                setSizes(currentChild.transform.GetChild(ind), inputFieldWidth, inputFieldHeight);
                                setFontSize(currentChild.transform.GetChild(ind), inputFieldsFontSize);

                                for (int index = 0; index < currentChild.transform.GetChild(ind).transform.childCount; index++)
                                {
                                    try
                                    {
                                        if (currentChild.transform.GetChild(ind).transform.GetChild(index).GetComponent<FieldType>().isPlaceholder)
                                        {
                                            currentChild.transform.GetChild(ind).transform.GetChild(index).GetComponent<Text>().fontSize = inputFieldsFontSize;
                                            currentChild.transform.GetChild(ind).transform.GetChild(index).GetComponent<RectTransform>().sizeDelta = new Vector2(currentChild.transform.GetChild(ind).GetComponent<RectTransform>().sizeDelta.x * 0.86f * currentChild.transform.GetChild(ind).transform.localScale.x / currentChild.transform.GetChild(ind).transform.GetChild(index).localScale.x, currentChild.transform.GetChild(ind).GetComponent<RectTransform>().sizeDelta.y * 0.85f * currentChild.transform.GetChild(ind).transform.localScale.y / currentChild.transform.GetChild(ind).transform.GetChild(index).transform.localScale.y);
                                            if (inputFieldsHidePlaceholder)
                                            {
                                                currentChild.transform.GetChild(ind).transform.GetChild(index).transform.localScale = new Vector2(0f, 0f);
                                            }
                                            else
                                            {
                                                currentChild.transform.GetChild(ind).transform.GetChild(index).transform.localScale = new Vector2(0.2f, 0.2f);
                                            }
                                        }
                                        else if (currentChild.transform.GetChild(ind).transform.GetChild(index).GetComponent<FieldType>().isText)
                                        {
                                            currentChild.transform.GetChild(ind).transform.GetChild(index).GetComponent<RectTransform>().sizeDelta = new Vector2(currentChild.transform.GetChild(ind).GetComponent<RectTransform>().sizeDelta.x * 0.68f * currentChild.transform.GetChild(ind).transform.localScale.x / currentChild.transform.GetChild(ind).transform.GetChild(index).localScale.x, currentChild.transform.GetChild(ind).GetComponent<RectTransform>().sizeDelta.y * 0.7f * currentChild.transform.GetChild(ind).transform.localScale.y / currentChild.transform.GetChild(ind).transform.GetChild(index).transform.localScale.y);
                                            currentChild.transform.GetChild(ind).transform.GetChild(index).GetComponent<Text>().fontSize = inputFieldsFontSize;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                    }
                }

                // Setting Custom text parameters
                else if (currentChild.GetComponent<FieldType>().isCustomTextHolder)
                {
                    for(int index = 0; index < currentChild.transform.childCount; index++)
                    {
                        if (currentChild.transform.GetChild(index).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(index), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(index), labelsFontStyle);
                            setFontSize(currentChild.transform.GetChild(index), labelsFontSize);
                            setTextAlign(currentChild.transform.GetChild(index), labelsTextAlign);
                            if (isValid && requiredActionIndex != 1)
                                setFontColor(currentChild.transform.GetChild(index), labelsFontColor);
                            setLabelsVisibility(currentChild.transform.GetChild(index), customTextFieldsHideLabel);
                        }
                        else if(currentChild.transform.GetChild(index).GetComponent<FieldType>().isCustomText)
                        {
                            if(!currentChild.transform.GetChild(index).GetComponent<FieldType>().enableCustomAlignment)
                                currentChild.transform.GetChild(index).localPosition = new Vector3(-6.5f + customTextFieldsHorizontal, -4f + customTextFieldsVertical, 0f);
                            if (!currentChild.transform.GetChild(index).GetComponent<FieldType>().enableCustomDesign)
                            {
                                setScale(currentChild.transform.GetChild(index), customTextFieldsScale);
                                setFont(currentChild.transform.GetChild(index), customTextFieldsFont);
                                setFontStyle(currentChild.transform.GetChild(index), customTextFieldsFontStyle);
                                for (int ind = 0; ind < currentChild.transform.GetChild(index).childCount; ind++)
                                {
                                    currentChild.transform.GetChild(index).transform.GetChild(ind).GetComponent<RectTransform>().sizeDelta = new Vector2(currentChild.transform.GetChild(index).GetComponent<RectTransform>().sizeDelta.x * 1.8f * currentChild.transform.GetChild(index).transform.localScale.x / currentChild.transform.GetChild(index).transform.GetChild(ind).localScale.x, currentChild.transform.GetChild(index).GetComponent<RectTransform>().sizeDelta.y * 0.95f * currentChild.transform.GetChild(index).transform.localScale.y / currentChild.transform.GetChild(index).transform.GetChild(ind).transform.localScale.y);
                                    setTextAlign(currentChild.transform.GetChild(index).transform.GetChild(ind), customTextFieldsAlign);
                                    setFontSize(currentChild.transform.GetChild(index).transform.GetChild(ind), customTextFieldsFontSize);
                                    setSizes(currentChild.transform.GetChild(index), customTextFieldsWidth, customTextFieldsHeight);
                                    setFontColor(currentChild.transform.GetChild(index).transform.GetChild(ind), customTextFieldsFontColor);
                                }
                                if (customTextFieldsHideBackground)
                                {
                                    if (!deleteCustomTextBackground)
                                    {
                                        deleteCustomTextBackground = true;
                                        setOpacity(currentChild.transform.GetChild(index), 0);
                                    }
                                }
                                else
                                {
                                    currentChild.transform.GetChild(index).GetComponent<Image>().color = customTextFieldsBackgroundColor;
                                    deleteCustomTextBackground = false;
                                }
                                try
                                {
                                    if (customTextFieldsSmoothBackground)
                                    {
                                        Sprite smoothBackground = Resources.Load<Sprite>("PNG/smoothBackground");
                                        currentChild.transform.GetChild(index).GetComponent<Image>().sprite = smoothBackground;
                                    }
                                    else
                                    {
                                        currentChild.transform.GetChild(index).GetComponent<Image>().sprite = null;
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                // Setting slider parameters
                else if (currentChild.GetComponent<FieldType>().isSlider)
                {
                    for (int j = 0; j < currentChild.transform.childCount; j++)
                    {
                        if (currentChild.transform.GetChild(j).GetComponent<FieldType>().isSliderHolder && !currentChild.transform.GetChild(j).GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(j), fieldsFont);
                            setFontStyle(currentChild.transform.GetChild(j), fieldsFontStyle);
                            setScale(currentChild.transform.GetChild(j), sliderFieldsScale);
                            for (int index = 0; index < currentChild.transform.GetChild(j).transform.childCount; index++)
                            {
                                setFontColor(currentChild.transform.GetChild(j), sliderFieldsFontColor);
                                Transform sliderChild = currentChild.transform.GetChild(j).transform.GetChild(index);
                                setSlidersParameters(sliderChild);
                                setFontSize(sliderChild, sliderFieldsFontSize);
                            }
                        }else if (currentChild.transform.GetChild(j).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(j), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(j), labelsFontStyle);
                            setTextAlign(currentChild.transform.GetChild(j), labelsTextAlign);
                            setFontSize(currentChild.transform.GetChild(j), labelsFontSize);
                            setLabelsVisibility(currentChild.transform.GetChild(j), sliderFieldsHideLabel);
                            setFontColor(currentChild.transform.GetChild(j), labelsFontColor);
                        }
                    }
                }
                // Setting checkbox container parameters
                else if (currentChild.GetComponent<FieldType>().isCheckboxContainer)
                {
                    for (int index = 0; index < currentChild.transform.childCount; index++)
                    {
                        if (currentChild.transform.GetChild(index).GetComponent<FieldType>().isOptionsList && !currentChild.transform.GetChild(index).GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild, fieldsFont);
                            setFontStyle(currentChild, fieldsFontStyle);
                            setFontSize(currentChild.transform.GetChild(index), checkboxFieldsFontSize);
                            setTextAlign(currentChild.transform.GetChild(index), checkboxFieldsTextAlign);
                            setScale(currentChild.transform.GetChild(index), checkboxFieldsScale);
                            setOptionParameters(currentChild.transform.GetChild(index), checkboxFieldsHideLabel, checkboxFieldsSetTextActiveColor, checkboxFieldsTextAlign, checkboxFieldsFontSize, checkboxFieldsFontColor, checkboxFieldsBackgroundActiveColor, checkboxFieldsBackgroundNotActiveColor, checkboxFieldsMarkColor, checkboxFieldsCheckAreaSize);
                        }else if (currentChild.transform.GetChild(index).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(index), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(index), labelsFontStyle);
                            setLabelsVisibility(currentChild.transform.GetChild(index), radioButtonFieldsHideLabel);
                            if (isValid && requiredActionIndex != 1)
                                setFontColor(currentChild.transform.GetChild(index), labelsFontColor);
                            setTextAlign(currentChild.transform.GetChild(index), labelsTextAlign);
                            setFontSize(currentChild.transform.GetChild(index), labelsFontSize);
                        }
                    }
                }
                // Setting radio buttons container parameters
                else if (currentChild.GetComponent<FieldType>().isRadioButtonsContainer)
                {
                    for (int index = 0; index < currentChild.transform.childCount; index++)
                    {
                    if ((currentChild.transform.GetChild(index).GetComponent<FieldType>().isOptionsList || currentChild.transform.GetChild(index).GetComponent<FieldType>().isHorizontalOptionsList) && !currentChild.transform.GetChild(index).GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(index), fieldsFont);
                            setFontStyle(currentChild.transform.GetChild(index), fieldsFontStyle);
                            setFontSize(currentChild.transform.GetChild(index), radioButtonFieldsFontSize);
                            setTextAlign(currentChild.transform.GetChild(index), radioButtonFieldsTextAlign);
                            setScale(currentChild.transform.GetChild(index), radioButtonFieldsScale);
                            setOptionParameters(currentChild.transform.GetChild(index), radioButtonFieldsHideLabel, radioButtonFieldsSetTextActiveColor, radioButtonFieldsTextAlign, radioButtonFieldsFontSize, radioButtonFieldsFontColor, radioButtonFieldsBackgroundActiveColor, radioButtonFieldsBackgroundNotActiveColor, radioButtonFieldsBackgroundActiveColor, radioButtonFieldsCheckAreaSize);
                        }else if (currentChild.transform.GetChild(index).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(index), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(index), labelsFontStyle);
                            setLabelsVisibility(currentChild.transform.GetChild(index), radioButtonFieldsHideLabel);
                            if (isValid && requiredActionIndex != 1)
                                setFontColor(currentChild.transform.GetChild(index), labelsFontColor);
                            setTextAlign(currentChild.transform.GetChild(index), labelsTextAlign);
                            setFontSize(currentChild.transform.GetChild(index), labelsFontSize);
                        }
                    }
                }
                // Setting rating container parameters
                else if (currentChild.GetComponent<FieldType>().isRatingContainer)
                {
                    for (int index = 0; index < currentChild.transform.childCount; index++)
                    {
                        try
                        {
                            if (currentChild.transform.GetChild(index).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                            {
                                setFont(currentChild.transform.GetChild(index), labelsFont);
                                setFontStyle(currentChild.transform.GetChild(index), labelsFontStyle);
                                setTextAlign(currentChild.transform.GetChild(index), labelsTextAlign);
                                if (isValid && requiredActionIndex != 1)
                                    setFontColor(currentChild.transform.GetChild(index), labelsFontColor);
                                setFontSize(currentChild.transform.GetChild(index), labelsFontSize);
                                setLabelsVisibility(currentChild.transform.GetChild(index), ratingFieldsHideLabel);
                            }
                            else if (currentChild.transform.GetChild(index).GetComponent<FieldType>().isRatingHolder && !currentChild.transform.GetChild(index).GetComponent<FieldType>().enableCustomDesign)
                            {
                                setScale(currentChild.transform.GetChild(index), ratingFieldsScale);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                // Setting rating container parameters
                else if (currentChild.GetComponent<FieldType>().isToggle)
                {
                    for (int j = 0; j < currentChild.transform.childCount; j++)
                    {
                        if (currentChild.transform.GetChild(j).GetComponent<FieldType>().isToggleHolder)
                        {
                            if (!currentChild.transform.GetChild(j).GetComponent<FieldType>().enableCustomAlignment)
                                currentChild.transform.GetChild(j).localPosition = new Vector3(-23f + toggleFieldsHorizontal, 14.5f + toggleFieldsVertical, 0f);
                            if (!currentChild.transform.GetChild(j).GetComponent<FieldType>().enableCustomDesign)
                            {
                                setFont(currentChild.transform.GetChild(j), fieldsFont);
                                setFontStyle(currentChild.transform.GetChild(j), fieldsFontStyle);
                                setScale(currentChild.transform.GetChild(j), toggleFieldsScale);
                                for (int index = 0; index < currentChild.transform.GetChild(j).transform.childCount; index++)
                                {
                                    try
                                    {
                                        if (currentChild.transform.GetChild(j).transform.GetChild(index).GetComponent<FieldType>().isToggleOption)
                                        {

                                            if (toggleFieldsSmoothBackground)
                                            {
                                                Sprite smoothBackground = Resources.Load<Sprite>("PNG/toggle");
                                                setBackground(currentChild.transform.GetChild(j).transform.GetChild(index), smoothBackground);
                                            }
                                            else
                                            {
                                                setBackground(currentChild.transform.GetChild(j).transform.GetChild(index), null);
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    setFontSize(currentChild.transform.GetChild(j).transform.GetChild(index), toggleFieldsFontSize);
                                }
                            }
                        }
                        else if (currentChild.transform.GetChild(j).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(j), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(j), labelsFontStyle);
                            setTextAlign(currentChild.transform.GetChild(j), labelsTextAlign);
                            setFontSize(currentChild.transform.GetChild(j), labelsFontSize);
                            setLabelsVisibility(currentChild.transform.GetChild(j), toggleFieldsHideLabel);
                            if (isValid && requiredActionIndex != 1)
                                setFontColor(currentChild.transform.GetChild(j), labelsFontColor);
                        }
                    }
                }
                // Setting dropdown parameters
                else if (currentChild.GetComponent<FieldType>().isDropdown)
                {
                    for (int j = 0; j < currentChild.transform.childCount; j++)
                    {
                        if (currentChild.transform.GetChild(j).GetComponent<FieldType>().isDropdownHolder)
                        {
                            if(!currentChild.transform.GetChild(j).GetComponent<FieldType>().enableCustomAlignment)
                                currentChild.transform.GetChild(j).localPosition = new Vector3(-32.5f + dropdownFieldsHorizontal, -13f + dropdownFieldsVertical, 0f);
                            if (!currentChild.transform.GetChild(j).GetComponent<FieldType>().enableCustomDesign)
                            {
                                setFont(currentChild.transform.GetChild(j), fieldsFont);
                                setFontStyle(currentChild.transform.GetChild(j), fieldsFontStyle);
                                setDropDownItemColors(currentChild.transform.GetChild(j));
                                try
                                {
                                    currentChild.transform.GetChild(j).GetComponent<Image>().color = dropdownFieldsBackgroundColor;

                                }
                                catch
                                {

                                }
                                if (dropdownFieldsSmoothBackground)
                                {
                                    Sprite smoothBackground = Resources.Load<Sprite>("PNG/smoothBackground");
                                    setBackground(currentChild.transform.GetChild(j), smoothBackground);
                                }
                                else
                                {
                                    setBackground(currentChild.transform.GetChild(j), null);
                                }
                                setSizes(currentChild.transform.GetChild(j), dropdownFieldsWidth, dropdownFieldsHeight);
                                setScale(currentChild.transform.GetChild(j), dropdownFieldsScale);
                                for (int index = 0; index < currentChild.transform.GetChild(j).transform.childCount; index++)
                                {
                                    setFontColor(currentChild.transform.GetChild(j).transform.GetChild(index), dropdownFieldsFontColor);
                                    try
                                    {
                                        if (currentChild.transform.GetChild(j).transform.GetChild(index).GetComponent<Text>())
                                        {
                                            currentChild.transform.GetChild(j).transform.GetChild(index).GetComponent<RectTransform>().sizeDelta = new Vector2(currentChild.transform.GetChild(j).GetComponent<RectTransform>().sizeDelta.x * 0.36f * currentChild.transform.GetChild(j).transform.localScale.x / currentChild.transform.GetChild(j).transform.GetChild(index).localScale.x, currentChild.transform.GetChild(j).GetComponent<RectTransform>().sizeDelta.y * 0.5f * currentChild.transform.GetChild(j).transform.localScale.y / currentChild.transform.GetChild(j).transform.GetChild(index).transform.localScale.y);
                                            setFontSize(currentChild.transform.GetChild(j).transform.GetChild(index), dropdownFieldsFontSize);
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    try
                                    {
                                        if (currentChild.transform.GetChild(j).transform.GetChild(index).GetComponent<FieldType>().isDropdownTemplate)
                                        {
                                            setScale(currentChild.transform.GetChild(j).transform.GetChild(index), dropdownFieldsTemplateScale);
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }else if (currentChild.transform.GetChild(j).GetComponent<FieldType>().isLabel && !currentChild.GetComponent<FieldType>().enableCustomDesign)
                        {
                            setFont(currentChild.transform.GetChild(j), labelsFont);
                            setFontStyle(currentChild.transform.GetChild(j), labelsFontStyle);
                            setTextAlign(currentChild.transform.GetChild(j), labelsTextAlign);
                            setFontSize(currentChild.transform.GetChild(j), labelsFontSize);
                            if (isValid && requiredActionIndex != 1)
                                setFontColor(currentChild.transform.GetChild(j), labelsFontColor);
                            setLabelsVisibility(currentChild.transform.GetChild(j), dropdownFieldsHideLabel);

                        }
                    }
                }
        }
        // Iterating through Form controller childs and setting title, submit button parameters
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            try
            {
                if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isFormHolder)
                {
                    if (hideBackground)
                    {
                        backgroundTransform.gameObject.SetActive(false);
                    }
                    else
                    {
                        if(backgroundImage != null)
                        {
                            backgroundTransform.GetComponent<Image>().sprite = backgroundImage;
                        }
                        else
                        {
                            backgroundTransform.GetComponent<Image>().sprite = null;
                        }

                        backgroundTransform.gameObject.SetActive(true);
                        try
                        {
                            if (enableDynamicBackground && changeColors.Length > 0)
                            {
                                backgroundTransform.GetComponent<Image>().color = Color.Lerp(backgroundTransform.GetComponent<Image>().color, changeColors[colorIndex], Time.deltaTime / smoothness);
                            }
                            else
                                backgroundTransform.GetComponent<Image>().color = backgroundColor;

                        }
                        catch
                        {

                        }

                        Transform background = gameObject.transform.GetChild(i);
                        for (int j = 0; j < background.transform.childCount; j++)
                        {
                            try
                            {
                                if (background.transform.GetChild(j).GetComponent<FieldType>().isTitleBackground && !background.transform.GetChild(j).GetComponent<FieldType>().enableCustomDesign)
                                {
                                    Transform titleBackground = background.transform.GetChild(j);
                                    setSizes(titleBackground, titleBackgroundWidth, titleBackgroundHeight);
                                    Sprite smoothBackground = Resources.Load<Sprite>("PNG/smoothBackground");
                                    if (smoothTitleBackground)
                                    {
                                        setBackground(titleBackground, smoothBackground);
                                    }
                                    else
                                    {
                                        setBackground(titleBackground, null);
                                    }
                                    if (hideTitleBackground)
                                    {
                                        if (!deleteTitleBackground)
                                        {
                                            setOpacity(titleBackground, 0f);
                                            deleteTitleBackground = true;
                                        }
                                    }
                                    else
                                    {
                                        titleBackground.GetComponent<Image>().color = titleBackgroundColor;
                                        deleteTitleBackground = false;
                                    }

                                    for (int index = 0; index < titleBackground.transform.childCount; index++)
                                    {
                                        try
                                        {
                                            if (titleBackground.transform.GetChild(index).GetComponent<FieldType>().isTitle)
                                            {
                                                titleBackground.transform.GetChild(index).GetComponent<RectTransform>().sizeDelta = new Vector2(titleBackground.GetComponent<RectTransform>().sizeDelta.x * 0.9f * titleBackground.transform.localScale.x / titleBackground.transform.GetChild(index).localScale.x, titleBackground.GetComponent<RectTransform>().sizeDelta.y * 0.9f * titleBackground.transform.localScale.y / titleBackground.transform.GetChild(index).transform.localScale.y);

                                            }
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            titleBackground.transform.GetChild(index).GetComponent<Text>().resizeTextMaxSize = titleFontSize;
                                        }
                                        catch
                                        {

                                        }
                                        if (hideTitle)
                                            titleBackground.transform.localScale = new Vector2(0, 0);
                                        else
                                        {
                                            titleBackground.transform.localScale = new Vector2(1, 1);
                                        }
                                        setFont(titleBackground.transform.GetChild(index), titleFont);
                                        setFontStyle(titleBackground.transform.GetChild(index), titleFontStyle);
                                        setTextAlign(background.transform.GetChild(index), titleAlign);
                                        setFontColor(titleBackground.transform.GetChild(index), titleFontColor);
                                    }

                                }
                                else if (background.transform.GetChild(j).GetComponent<FieldType>().isSubmit && !background.transform.GetChild(j).GetComponent<FieldType>().enableCustomDesign)
                                {
                                    Transform submitButton = background.transform.GetChild(j);
                                    setFont(submitButton, submitButtonFont);
                                    setScale(background.transform.GetChild(j), submitButtonScale);
                                    setFontStyle(submitButton, submitButtonFontStyle);
                                    submitButton.GetComponent<Image>().color = submitButtonColor;
                                    setFontColor(submitButton, submitButtonFontColor);
                                    setSizes(submitButton, submitButtonWidth, submitButtoneHeight);

                                    setFontSize(submitButton, submitButtonFontSize);
                                    for (int index = 0; index < submitButton.transform.childCount; index++)
                                    {
                                        try
                                        {
                                            if (background.transform.GetChild(j).transform.GetChild(index).GetComponent<Text>().text == "")
                                            {
                                                background.transform.GetChild(j).transform.GetChild(index).GetComponent<Text>().text = "Submit";
                                            }
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            background.transform.GetChild(j).transform.GetChild(index).GetComponent<RectTransform>().sizeDelta = new Vector2(background.transform.GetChild(j).GetComponent<RectTransform>().sizeDelta.x + background.transform.GetChild(j).GetComponent<RectTransform>().sizeDelta.x / 2.19f, background.transform.GetChild(j).GetComponent<RectTransform>().sizeDelta.y - background.transform.GetChild(j).GetComponent<RectTransform>().sizeDelta.y / 20);
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    try
                                    {
                                        if (smoothSubmitButton)
                                        {
                                            Sprite smoothButton = Resources.Load<Sprite>("PNG/smoothBackground");
                                            background.transform.GetChild(j).GetComponent<Image>().sprite = smoothButton;
                                        }
                                        else
                                        {
                                            background.transform.GetChild(j).GetComponent<Image>().sprite = null;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }else if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isBackToForm || gameObject.transform.GetChild(i).GetComponent<FieldType>().isRequiredAlert || gameObject.transform.GetChild(i).GetComponent<FieldType>().isErrorMessage)
                {
                    try
                    {
                        gameObject.transform.GetChild(i).GetComponent<Image>().color = backToFormBackgroundColor;
                    }
                    catch
                    {

                    }
                    if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isBackToForm)
                    {
                        backToFormAnim = gameObject.transform.GetChild(i).GetComponent<Animator>();
                    }else if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isRequiredAlert)
                    {
                        requiredFieldsAlertAnim = gameObject.transform.GetChild(i).GetComponent<Animator>();
                    }
                    else if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isErrorMessage)
                    {
                        errorMessageAnim = gameObject.transform.GetChild(i).GetComponent<Animator>();
                    }
                    if (gameObject.transform.GetChild(i).transform.childCount > 0)
                    {
                        foreach (Transform child in gameObject.transform.GetChild(i))
                        {
                            try
                            {
                                if(gameObject.transform.GetChild(i).GetComponent<FieldType>().isBackToForm)
                                    child.GetComponent<Text>().text = successfulSubmitionText;
                                else if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isRequiredAlert)
                                    child.GetComponent<Text>().text = requiredFieldsAlertText;
                                else if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isErrorMessage)
                                    child.GetComponent<Text>().text = errorMessageText;
                            }
                            catch
                            {

                            }
                        }
                    }
                    setFont(gameObject.transform.GetChild(i), backToFormFont);
                    setFontSize(gameObject.transform.GetChild(i), backToFormFontSize);
                    setFontColor(gameObject.transform.GetChild(i), backToFormFontColor);
                    setTextAlign(gameObject.transform.GetChild(i), backToFormAlign);
                    setFontStyle(gameObject.transform.GetChild(i), backToFormFontStyle);
                    setLineSpacing(gameObject.transform.GetChild(i), backToFormLineSpacing);
                }
                else if (gameObject.transform.GetChild(i).GetComponent<FieldType>().isEmailManager && emailManager == null)
                {
                    emailManager = gameObject.transform.GetChild(i).gameObject;
                }
            }
            catch
            {

            }
        }
    }

    //  Dynamic background function, with wait time as a parameter, which is public

    IEnumerator dynamicBackground(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (enableDynamicBackground)
        {
            colorIndex = colorIndex + 1 < changeColors.Length ? colorIndex + 1 : 0;
        }

        StartCoroutine("dynamicBackground", interval);
    }

    //  Setting option(Radio or checkbox) parameters
    void setOptionParameters(Transform currentChild, bool hideLabel, bool setTextActiveColor, TextAnchor textAlign, float fontSize, Color fontColor, Color backgroundActiveColor, Color backgroundNotActiveColor, Color markColor, float checkAreaSize)
    {
        if (currentChild.transform.childCount > 0)
        {
            for (int index = 0; index < currentChild.transform.childCount; index++)
                setOptionParameters(currentChild.transform.GetChild(index), hideLabel, setTextActiveColor, textAlign, fontSize, fontColor, backgroundActiveColor, backgroundNotActiveColor, markColor, checkAreaSize);
        }
        try
        {
            try
            {
                if (currentChild.GetComponent<Toggle>().isOn && setTextActiveColor)
                {
                    setFontColor(currentChild, backgroundActiveColor);
                }
                else
                {
                    setFontColor(currentChild, fontColor);
                }
            }
            catch
            {

            }
          
            if (currentChild.GetComponent<FieldType>().isChecker)
            {
                try
                {
                    currentChild.GetComponent<RectTransform>().sizeDelta = new Vector2(checkAreaSize, checkAreaSize);
                }
                catch
                {

                }
            }
            if (currentChild.GetComponent<FieldType>().isMark)
            {
                try
                {
                    currentChild.GetComponent<Image>().color = markColor;
                }
                catch
                {

                }
            }
            else if (currentChild.GetComponent<FieldType>().isOptionBackground)
            {
                try
                {
                    if(currentChild.transform.parent.GetComponent<Toggle>().isOn){
                        currentChild.GetComponent<Image>().color = backgroundActiveColor;
                    }
                    else
                    {
                        currentChild.GetComponent<Image>().color = backgroundNotActiveColor;
                    }
                }
                catch
                {

                }
            }
        }

        catch
        {
        
        }

    }

    //Add * to required fields
    void addRequiredSign(Transform field)
    {
        if (field.transform.childCount > 0)
        {
            foreach (Transform fieldChild in field)
            {
                addRequiredSign(fieldChild);
            }
        }
        if (field.GetComponent<FieldType>().isLabel)
        {
            if(field.GetComponent<Text>().text.Substring(field.GetComponent<Text>().text.Length - 1) != "*"){
                field.GetComponent<Text>().text += "*";
            }

        }
    }

    //Remove * from field
    void removeRequiredSign(Transform field)
    {
        if (field.transform.childCount > 0)
        {
            foreach (Transform fieldChild in field)
            {
                removeRequiredSign(fieldChild);
            }
        }
        if (field.GetComponent<FieldType>().isLabel)
        {
            if (field.GetComponent<Text>().text.Substring(field.GetComponent<Text>().text.Length - 1) == "*")
            {
                field.GetComponent<Text>().text = field.GetComponent<Text>().text.Substring(0, field.GetComponent<Text>().text.Length - 1);
            }

        }
    }

    // Making label not valid required color
    void changeLabelColor(Transform field, Color labelColor)
    {
        if (requiredActionIndex == 1)
            return;

        if(field.transform.childCount > 0)
        {
            foreach (Transform fieldChild in field)
            {
                changeLabelColor(fieldChild, labelColor);
            }
        }
        if (field.GetComponent<FieldType>().isLabel)
        {
            field.GetComponent<Text>().color = labelColor;
        }
    }

    // Making label not valid required color
    void changeInputFieldColor(Transform field, Color inputFieldColor)
    {
        if (requiredActionIndex == 0)
            return;

        if (field.transform.childCount > 0)
        {
            foreach (Transform fieldChild in field)
            {
                changeInputFieldColor(fieldChild, inputFieldColor);
            }
        }
        if (field.GetComponent<FieldType>().isInputFieldHolder)
        {
            field.GetComponent<Image>().color = inputFieldColor;

        }
    }

    // Required fields check
    bool checkRequiredFields()
    {
        isValid = true;
        foreach (Transform field in fieldsContainer.transform)
        {
            if (field.GetComponent<FieldType>().isCustomTextHolder || !field.GetComponent<FieldType>().isRequired)
            {
                continue;
            }

            if (field.GetComponent<FieldType>().isInputField && !field.GetComponent<FieldType>().isCustomAddress && !field.GetComponent<FieldType>().isCustomFullName)
            {
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isInputFieldHolder || fieldChild.GetComponent<FieldType>().isCustomCommentsHolder)
                    {
                        foreach (Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isText)
                            {
                                try
                                {
                                    if (value.GetComponent<Text>().text.Length == 0)
                                    {
                                        isValid = false;
                                        changeLabelColor(field, notValidColor);
                                        changeInputFieldColor(field, notValidColor);
                                    }
                                    else
                                    {
                                        changeLabelColor(field, labelsFontColor);
                                        changeInputFieldColor(field, normalInputFieldsBackgroundColor);
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
            else if (field.GetComponent<FieldType>().isCustomFullName)
            {
                int count = 0;
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isInputFieldHolder || fieldChild.GetComponent<FieldType>().isCustomCommentsHolder)
                    {
                        foreach (Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isText)
                            {
                                try
                                {
                                    if (value.GetComponent<Text>().text.Length == 0)
                                    {
                                        isValid = false;
                                        count++;
                                        changeLabelColor(field, notValidColor);
                                        changeInputFieldColor(field, notValidColor);
                                    }
                                    else if(count == 0)
                                    {
                                        changeLabelColor(field, labelsFontColor);
                                        changeInputFieldColor(field, normalInputFieldsBackgroundColor);
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
            else if (field.GetComponent<FieldType>().isCheckboxContainer || field.GetComponent<FieldType>().isRadioButtonsContainer)
            {
                bool entered = false;
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isOptionsList || fieldChild.GetComponent<FieldType>().isHorizontalOptionsList)
                    {
                        foreach (Transform value in fieldChild)
                        {
                            if (value.GetComponent<Toggle>().isOn)
                            {
                                entered = true;
                            }
                        }
                    }
                }
                if(!entered)
                {
                    isValid = false;
                    changeLabelColor(field, notValidColor);
                }
                else
                {
                    changeLabelColor(field, labelsFontColor);
                }
            }
            else if (field.GetComponent<FieldType>().isCustomAddress)
            {
                int count = 0;
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isInputFieldHolder)
                    {
                        foreach (Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isText)
                            {
                                if(value.GetComponent<Text>().text.Length == 0)
                                {
                                    count++;
                                    isValid = false;
                                    changeInputFieldColor(fieldChild, notValidColor);
                                }
                                else
                                {
                                    changeInputFieldColor(fieldChild, normalInputFieldsBackgroundColor);
                                }
                            }
                        }
                    }
                }
                if(count == 0)
                {
                    changeLabelColor(field, labelsFontColor);
                }
                else
                {
                    changeLabelColor(field, notValidColor);
                }
            }
            else if (field.GetComponent<FieldType>().isDropdown && !field.GetComponent<FieldType>().isCustomBirthday && !field.GetComponent<FieldType>().isTime)
            {
                foreach (Transform child in field)
                {
                    if (child.GetComponent<FieldType>().isDropdownHolder)
                    {
                        foreach (Transform value in child)
                        {
                            if (value.GetComponent<FieldType>().isDropdownLabel)
                            {
                                if (value.GetComponent<Text>().text.Length == 0)
                                    isValid = false;
                                changeLabelColor(field, notValidColor);
                                changeInputFieldColor(field, notValidColor);
                            }
                            else
                            {
                                changeLabelColor(field, labelsFontColor);
                                changeInputFieldColor(field, normalInputFieldsBackgroundColor);
                            }
                        }
                    }
                }
            }
            else if (field.GetComponent<FieldType>().isRatingContainer)
            {
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isRatingHolder)
                    {
                        if(fieldChild.GetComponent<ratingsList>().value + 1 == 0)
                        {
                            isValid = false;
                            changeLabelColor(field, notValidColor);
                        }
                        else
                        {
                            changeLabelColor(field, labelsFontColor);
                        }
                    }
                }
            }
        }
        return isValid;
    }

    //  Submit button click, checking couroutine 
    public void submitButtonClick()
    {
        if (checkRequiredFields())
            StartCoroutine("submitAction", submitActionDelay);
        else
        {
            if(showRequiredAlert)
                requiredFieldsAlertAnim.SetBool("Start", true);
            AudioSource src = GetComponent<AudioSource>();
            if (!isValid && failedSubmitSound != null)
            {
                src.clip = failedSubmitSound;
                src.Play();
            }
        }
    }

    //  Submit button click action
    IEnumerator submitAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        bool error = false;
		
		Debug.Log( emailBodyCreator() );
		
        // Checks send email condition
        if (sendEmail)
        {
            // Calling email send function, if there are any existing fields
            if (fieldsContainer.transform.childCount > 0)
            {
                try
                {
                    emailManager.GetComponent<EmailManager>().emailSender(emailAddress, password, getFormName() + " Submission!", emailBodyCreator());
                }
                catch
                {
                    error = true;
                    errorMessageAnim.SetBool("Start", true);
                    AudioSource src = GetComponent<AudioSource>();
                    if(failedSubmitSound != null)
                    {
                        src.clip = failedSubmitSound;
                        src.Play();
                    }
                }
            }
            else
                Debug.Log("You don't have any fields");
        }
		
        if (!error)
        {
            if (actionIndex == 1)
            {
                backToFormAnim.SetBool("Start", true);
            }
            else if (actionIndex == 2)
            {
                SceneManager.LoadScene(changeSceneName);
            }
            else if (actionIndex == 3)
            {
                gameObject.SetActive(false);
            }
            AudioSource src = GetComponent<AudioSource>();

            if (submitionSound != null && isValid)
            {
                src.clip = submitionSound;
                src.Play();
            }
        }

    }

    //  Setting given child's all component's font size
    void setFontSize(Transform currentChild, int givenFontSize)
    {
        if (currentChild.transform.childCount > 0)
        {
            for (int i = 0; i < currentChild.transform.childCount; i++)
            {
                setFontSize(currentChild.transform.GetChild(i), givenFontSize);
            }
        }
       
        try
        {
            currentChild.GetComponent<Text>().resizeTextMaxSize = givenFontSize;
        }
        catch
        {

        }
    }

    //  Setting given child's all component's line spacing
    void setLineSpacing(Transform currentChild, int givenlineSpacing)
    {
        if (currentChild.transform.childCount > 0)
        {
            for (int i = 0; i < currentChild.transform.childCount; i++)
            {
                setLineSpacing(currentChild.transform.GetChild(i), givenlineSpacing);
            }
        }

        try
        {
            currentChild.GetComponent<Text>().lineSpacing = givenlineSpacing;
        }
        catch
        {

        }
    }

    //  Setting given child's all component's font style
    void setFontStyle(Transform currentChild, FontStyle givenFontStyle)
    {
        if (currentChild.transform.childCount > 0)
        {
            for (int i = 0; i < currentChild.transform.childCount; i++)
            {
                setFontStyle(currentChild.transform.GetChild(i), givenFontStyle);
            }
        }
        try
        {
            currentChild.GetComponent<Text>().fontStyle = givenFontStyle;
        }
        catch
        {

        }
    }

    //  Setting given child's all component's font
    void setFont(Transform element, Font font)
    {
        if (element.childCount > 0)
        {
            for (int i = 0; i < element.childCount; i++)
            {
                setFont(element.GetChild(i), font);
            }
        }
        try
        {
            if(font != null)
            {
                element.GetComponent<Text>().font = font;
            }
        }
        catch
        {

        }
    }

    //  Setting dropdown elements colors
    void setDropDownItemColors(Transform currentChild)
    {
        try
        {
            if (currentChild.GetComponent<FieldType>().isDropdownItem)
            {
                try
                {
                    ColorBlock toggleColors = currentChild.GetComponent<Toggle>().colors;
                    toggleColors.normalColor = dropdownFieldsNormalColor;
                    toggleColors.pressedColor = dropdownFieldsSelectedColor;
                    toggleColors.highlightedColor = dropdownFieldsSelectedColor;
                    toggleColors.selectedColor = dropdownFieldsSelectedColor;
                    currentChild.GetComponent<Toggle>().colors = toggleColors;
                }
                catch
                {

                }
            }else if (currentChild.GetComponent<FieldType>().isDropDownArrow)
            {
                try
                {
                    currentChild.GetComponent<Image>().color = dropdownFieldsFontColor;
                }
                catch
                {

                }
            }
            if (currentChild.transform.childCount > 0)
            {
                for (int i = 0; i < currentChild.transform.childCount; i++)
                {
                    setDropDownItemColors(currentChild.transform.GetChild(i));
                }
            }
        }
        catch
        {

        }
    }

    //  Setting slider parameters
    void setSlidersParameters(Transform currentChild)
    {
        try
        {
            try
            {
                if (currentChild.GetComponent<FieldType>().isSliderHandle)
                {
                    currentChild.GetComponent<Image>().color = sliderFieldsHandleColor;
                    if(sliderFieldsCustomHandleImage != null)
                    {
                        currentChild.GetComponent<Image>().sprite = sliderFieldsCustomHandleImage;
                    }
                }
                else if (currentChild.GetComponent<FieldType>().isSliderBackground)
                {
                    currentChild.GetComponent<Image>().color = sliderFieldsBackgroundColor;
                }
                else if (currentChild.GetComponent<FieldType>().isSliderFilledArea)
                {
                    currentChild.GetComponent<Image>().color = sliderFieldsFilledAreaColor;
                }
            }
            catch
            {

            }
            if (currentChild.GetComponent<FieldType>().isSliderValue)
            {
                if (sliderFieldsHideValue)
                {
                    currentChild.transform.localScale = new Vector2(0f, 0f);
                }
                else
                {
                    currentChild.transform.localScale = new Vector2(0.25f, 0.25f);
                }
            }
            else if (currentChild.GetComponent<FieldType>().isSliderPostfix)
            {
                if (sliderFieldsHidePostfix)
                {
                    currentChild.transform.localScale = new Vector2(0f, 0f);
                }
                else
                {
                    currentChild.transform.localScale = new Vector2(1f, 1f);
                }
            }
            else if (currentChild.GetComponent<FieldType>().isSliderPrefix)
            {
                if (sliderFieldsHidePrefix)
                {
                    currentChild.transform.localScale = new Vector2(0f, 0f);
                }
                else
                {
                    currentChild.transform.localScale = new Vector2(1f, 1f);
                }
            }

            if (currentChild.transform.childCount > 0)
            {
                for (int i = 0; i < currentChild.transform.childCount; i++)
                {
                    setSlidersParameters(currentChild.transform.GetChild(i));
                }
            }
        }
        catch
        {

        }

    }

    //  Setting given child's all component's text align
    void setTextAlign(Transform currentChild, TextAnchor textAlign)
    {
        if (currentChild.transform.childCount > 0)
        {
            for (int i = 0; i < currentChild.transform.childCount; i++)
            {
                setTextAlign(currentChild.transform.GetChild(i), textAlign);
            }
        }
        try
        {
            currentChild.GetComponent<Text>().alignment = textAlign;
        }
        catch
        {

        }
    }

    //  Setting given sprite as component's background
    void setBackground(Transform component, Sprite sprite)
    {
        try
        {
            component.GetComponent<Image>().sprite = sprite;
        }
        catch
        {

        }

    }

    //  Setting given child's all component's font color
    public void setFontColor(Transform currentChild, Color givenFontColor)
    {
        if (currentChild.transform.childCount > 0)
        {
            for (int i = 0; i < currentChild.transform.childCount; i++)
            {
                setFontColor(currentChild.transform.GetChild(i), givenFontColor);
            }
        }
            try
            {
                currentChild.GetComponent<Text>().color = givenFontColor;
                if (currentChild.GetComponent<FieldType>().isPlaceholder)
                {
                    Color placeHolderColor = givenFontColor;
                    placeHolderColor.a = 100f/255f;
                    currentChild.GetComponent<Text>().color = placeHolderColor;
                }
            }
            catch
            {

            }
    }

    //  Setting given child's scale
    void setScale(Transform currentChild, float scale)
    {
        currentChild.transform.localScale = new Vector2(scale, scale);

    }

    //  Setting given child's sizes
    public void setSizes(Transform currentChild, float width, float height)
    {
        try
        {
            currentChild.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }
        catch
        {

        }
    }

    //  Setting given child's opacity
    public void setOpacity(Transform currentChild, float opacity)
    {
        Color col = currentChild.GetComponent<Image>().color;
        col.a = opacity;
        currentChild.GetComponent<Image>().color = col;
    }

    // Labels hide or not
    void setLabelsVisibility(Transform element, bool hideLabel)
    {
        if(hideAllLabels || hideLabel)
        {
            element.localScale = new Vector2(0f, 0f);
        }
        else
        {
            element.localScale = new Vector2(0.2f, 0.2f);
        }
    }

    // Get fieldsContainer gameobject
    void getFieldsContainer(Transform element)
    {
        if (element.GetComponent<FieldType>().isFieldsContainer)
        {
            fieldsContainer = element.gameObject;
            //return;
        }
        if (element.transform.childCount > 0)
        {
            foreach (Transform child in element)
            {
                getFieldsContainer(child);
            }
        }
    }

    // Adds required scipt to all gameobjects, where it doesn't exist.
    void attachRequiredScript(Transform element)
    {
        if (!checkRequiredScript(element))
        {
            element.gameObject.AddComponent<FieldType>();
        }
        if (element.transform.childCount > 0)
        {
            foreach(Transform child in element)
            {
                attachRequiredScript(child);
            }
        }
    }

    // Required script check process
    bool checkRequiredScript(Transform element)
    {
        try
        {
            bool test = element.GetComponent<FieldType>().isForm;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void backToFormToDefault()
    {
        backToFormAnim.SetBool("Start", false);
    }

    public void backToForm()
    {
        requiredFieldsAlertAnim.SetBool("Start", false);
    }
    public void backToFormAfterErrorMessage()
    {
        errorMessageAnim.SetBool("Start", false);
    }

    public void reloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    // Email text creator
    string emailBodyCreator()
    {
        string body = "";

        // body = "Hi. You have a new submission from your " + getFormName() + ":\n\n";

        foreach(Transform field in fieldsContainer.transform)
        {
            if (field.GetComponent<FieldType>().isCustomTextHolder || field.GetComponent<FieldType>().isPassword)
            {
                continue;
            }

            int index = field.name.Length;

            if (field.name.Contains("(Clone)"))
            {
                index = field.name.IndexOf('(');
            }

            body += field.name.Substring(0, index) + ": ";

            if(field.GetComponent<FieldType>().isInputField && !field.GetComponent<FieldType>().isCustomAddress && !field.GetComponent<FieldType>().isCustomFullName)
            {
                foreach(Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isInputFieldHolder || fieldChild.GetComponent<FieldType>().isCustomCommentsHolder)
                    {
                        foreach(Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isText)
                            {
                                try
                                {
                                    body += value.GetComponent<Text>().text.Length > 0 ? value.GetComponent<Text>().text + " " : "Not set" + " ";
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                body = body.Substring(0, body.Length - 1);
            }else if (field.GetComponent<FieldType>().isCustomFullName)
            {
                string fullName = "";
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isInputFieldHolder || fieldChild.GetComponent<FieldType>().isCustomCommentsHolder)
                    {
                        foreach (Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isText)
                            {
                                try
                                {
                                    if(value.GetComponent<Text>().text.Length > 0)
                                        fullName += value.GetComponent<Text>().text + " ";
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                if(fullName.Length > 0)
                {
                    fullName = fullName.Substring(0, fullName.Length - 1);
                }
                else
                {
                    fullName = "Not set";
                }
                body += fullName;
            }
            else if (field.GetComponent<FieldType>().isCheckboxContainer || field.GetComponent<FieldType>().isRadioButtonsContainer)
            {
                string val = "";
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isOptionsList || fieldChild.GetComponent<FieldType>().isHorizontalOptionsList)
                    {
                        foreach (Transform value in fieldChild)
                        {
                            if (value.GetComponent<Toggle>().isOn)
                            {
                                foreach(Transform text in value)
                                {
                                    try
                                    {
                                        if (text.GetComponent<Text>())
                                        {
                                            if(val.Length == 0)
                                            {
                                                val = text.GetComponent<Text>().text;
                                            }
                                            else
                                            {
                                                val += ", " + text.GetComponent<Text>().text;
                                            }
                                        }

                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
                body += val.Length > 0 ? val : "Not set";
            }
            else if (field.GetComponent<FieldType>().isCustomAddress)
            {
                string address = "";
                foreach(Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isInputFieldHolder)
                    {
                        foreach(Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isText)
                            {
                                if(address.Length == 0)
                                {
                                    address = value.GetComponent<Text>().text;
                                }
                                else
                                {
                                    address += ", " + value.GetComponent<Text>().text;
                                }
                            }
                        }
                    }else if (fieldChild.GetComponent<FieldType>().isDropdown)
                    {
                        foreach(Transform child in fieldChild)
                        {
                            if (child.GetComponent<FieldType>().isDropdownHolder)
                            {
                                foreach(Transform value in child)
                                {
                                    if (value.GetComponent<FieldType>().isDropdownLabel)
                                    {
                                        if (address.Length == 0)
                                        {
                                            address = value.GetComponent<Text>().text;
                                        }
                                        else
                                        {
                                            address += ", " + value.GetComponent<Text>().text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                body += address;
            }
            else if (field.GetComponent<FieldType>().isDropdown && !field.GetComponent<FieldType>().isCustomBirthday && !field.GetComponent<FieldType>().isTime)
            {
                foreach (Transform child in field)
                {
                    if (child.GetComponent<FieldType>().isDropdownHolder)
                    {
                        foreach(Transform value in child)
                        {
                            if (value.GetComponent<FieldType>().isDropdownLabel)
                            {
                                body += value.GetComponent<Text>().text.Length > 0 ? value.GetComponent<Text>().text : "Not set";
                            }
                        }
                    }
                }
            }
            else if (field.GetComponent<FieldType>().isCustomBirthday)
            {
                string date = "";
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isDropdown)
                    {
                        foreach (Transform child in fieldChild)
                        {
                            if (child.GetComponent<FieldType>().isDropdownHolder)
                            {
                                foreach (Transform value in child)
                                {
                                    if (value.GetComponent<FieldType>().isDropdownLabel)
                                    {
                                        if (date.Length == 0)
                                        {
                                            date = value.GetComponent<Text>().text;
                                        }
                                        else
                                        {
                                           date += " " + value.GetComponent<Text>().text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                body += date.Length > 0 ? date : "Not set";
            }
            else if (field.GetComponent<FieldType>().isTime)
            {
                string date = "";
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isDropdown)
                    {
                        foreach (Transform child in fieldChild)
                        {
                            if (child.GetComponent<FieldType>().isDropdownHolder)
                            {
                                foreach (Transform value in child)
                                {
                                    if (value.GetComponent<FieldType>().isDropdownLabel)
                                    {
                                        if (date.Length == 0)
                                        {
                                            date = value.GetComponent<Text>().text + ":";
                                        }
                                        else
                                        {
                                            date += value.GetComponent<Text>().text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                body += date.Length > 0 ? date : "Not set";
            }
            else if (field.GetComponent<FieldType>().isRatingContainer)
            {
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isRatingHolder)
                    {
                        body += fieldChild.GetComponent<ratingsList>().value + 1 + "/" + fieldChild.transform.childCount;
                    }
                }
            }
            else if (field.GetComponent<FieldType>().isSlider)
            {
                string value = "", prefix = "", postfix = "";
                if (sliderFieldsWholeValue || Mathf.Approximately(field.GetComponent<Slider>().value, field.GetComponent<Slider>().maxValue) || Mathf.Approximately(field.GetComponent<Slider>().value, field.GetComponent<Slider>().minValue))
                {
                    value = "" + field.GetComponent<Slider>().value;
                }
                else
                {
                    value = "" + field.GetComponent<Slider>().value.ToString("F" + sliderFieldsDecimalDigitsCount);
                }
                value += "/" + field.GetComponent<Slider>().maxValue;
                foreach (Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isSliderHolder)
                    {
                        foreach(Transform element in fieldChild)
                        {
                            if (element.GetComponent<FieldType>().isSliderPrefix)
                            {
                                prefix = element.GetComponent<Text>().text;
                            }else if (element.GetComponent<FieldType>().isSliderPostfix)
                            {
                                postfix = element.GetComponent<Text>().text;
                            }
                        }
                    }
                }
                if(Mathf.Approximately(field.GetComponent<Slider>().value, field.GetComponent<Slider>().minValue))
                {
                    value += " (" + prefix + ")";
                }else if (Mathf.Approximately(field.GetComponent<Slider>().value, field.GetComponent<Slider>().maxValue))
                {
                    value += " (" + postfix + ")";
                }
                body += value;
            }
            else if (field.GetComponent<FieldType>().isToggle)
            {
                foreach(Transform fieldChild in field)
                {
                    if (fieldChild.GetComponent<FieldType>().isToggleHolder)
                    {
                        foreach(Transform value in fieldChild)
                        {
                            if (value.GetComponent<FieldType>().isToggleOption)
                            {
                                if (value.GetComponent<toggleChange>().isChecked)
                                {
                                    foreach(Transform textObj in value)
                                    {
                                        body += textObj.GetComponent<Text>().text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            body += "\n";
        }
        return body + "\nSmart UI Form\nMade by Vectrum Technologies" + "\n" + "\n" + "Have a good day!";
    }

    // Gets form name
    string getFormName()
    {
        string formName = transform.parent.name;

        if (formName.Contains("(Clone)"))
        {
            int index = formName.LastIndexOf('(');
            formName = formName.Substring(0, index);
        }

        if (formName.Contains("(Dynamic Form)"))
        {
            int index = formName.LastIndexOf('(');
            formName = formName.Substring(0, index - 1);
        }

        if (!formName.Contains("Form") && !formName.Contains("form"))
        {
            formName += " Form";
        }
        return formName;
    }
}