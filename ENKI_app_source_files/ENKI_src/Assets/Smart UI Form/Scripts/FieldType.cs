using UnityEngine;

// Unique values for every component (Don't change it)
public class FieldType : MonoBehaviour
{
    [Header("Custom")]
    public bool isRequired = false;
    public bool enableCustomDesign = false;
    public bool enableCustomAlignment = false;

    [Space]
    [Header("Current Field Type (Don't change)")]
    public bool isForm;
    public bool isFormGmb;
    public bool isEmailManager;
    public bool isTitleBackground;
    public bool isTitle;
    public bool isBackground;
    public bool isFormHolder;
    public bool isFieldsContainer;
    public bool isSubmit;
    public bool isSubmitText;
    public bool isPlaceholder;
    public bool isInputField;
    public bool isInputFieldHolder;
    public bool isDropdown;
    public bool isDropdownLabel;
    public bool isDropdownHolder;
    public bool isCustomText;
    public bool isCustomTextHolder;
    public bool isLabel;
    public bool isText;
    public bool isPassword;
    public bool isCheckboxContainer;
    public bool isRadioButtonsContainer;
    public bool isOptionsList;
    public bool isHorizontalOptionsList;
    public bool isOption;
    public bool isChecker;
    public bool isMark;
    public bool isOptionBackground;
    public bool isRatingContainer;
    public bool isRatingHolder;
    public bool isRating;
    public bool isToggle;
    public bool isToggleHolder;
    public bool isToggleOption;
    public bool isSlider;
    public bool isSliderHolder;
    public bool isSliderPrefix;
    public bool isSliderPostfix;
    public bool isSliderValue;
    public bool isSliderHandle;
    public bool isSliderBackground;
    public bool isSliderFilledArea;
    public bool isDropdownTemplate;
    public bool isDropdownItem;
    public bool isDropDownArrow;
    public bool isCustomComments;
    public bool isCustomCommentsHolder;
    public bool isCustomFullName;
    public bool isCustomAddress;
    public bool isCustomBirthday;
    public bool isTime;
    public bool isBackToForm;
    public bool isRequiredAlert;
    public bool isErrorMessage;
}
