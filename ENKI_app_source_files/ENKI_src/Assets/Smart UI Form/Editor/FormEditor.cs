using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FormController))]
public class FormEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FormController formContr = (FormController)target;

        GUIContent requiredAction = new GUIContent("Apply Required Style For");
        formContr.requiredActionIndex = EditorGUILayout.Popup(requiredAction, formContr.requiredActionIndex, formContr.requiredActions);

        GUIContent afterSubActionLabel = new GUIContent("After Submit Action");
        formContr.actionIndex = EditorGUILayout.Popup(afterSubActionLabel, formContr.actionIndex, formContr.afterSubActions);

        GUIContent sendEmailnLabel = new GUIContent("Send Submitted Data to Your Email");
        formContr.sendEmail = EditorGUILayout.Toggle(sendEmailnLabel, formContr.sendEmail);

        GUIContent emailAddressLabel = new GUIContent("Email Address");
        formContr.emailAddress = EditorGUILayout.TextField(emailAddressLabel, formContr.emailAddress);

        GUIContent passwordLabel = new GUIContent("Password");
        formContr.password = EditorGUILayout.PasswordField(passwordLabel, formContr.password);

    }
}
