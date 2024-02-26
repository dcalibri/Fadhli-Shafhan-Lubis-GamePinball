
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitText : MonoBehaviour
{
    public TMP_InputField input;
    public Button submitButton;
    public TMP_Text targetText;

    void Start()
    {

        Button btn = submitButton.GetComponent<Button>();

        btn.onClick.AddListener(OnClickSubmit);

    }

    void OnClickSubmit()
    {

        targetText.text = input.text;

        targetText.fontSize += 1;

    }

}
