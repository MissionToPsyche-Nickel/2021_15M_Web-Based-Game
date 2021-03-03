using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordScrambleController : MonoBehaviour
{
    public InputField InputField1;
    public InputField InputField2;
    public InputField InputField3;
    public InputField InputField4;
    public InputField InputField5;

    public void Start()
    {
        InputField1.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField2.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField3.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField4.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        InputField5.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        InputField1.GetComponent<InputField>().text = InputField1.GetComponent<InputField>().text.ToUpper();
        InputField2.GetComponent<InputField>().text = InputField2.GetComponent<InputField>().text.ToUpper();
        InputField3.GetComponent<InputField>().text = InputField3.GetComponent<InputField>().text.ToUpper();
        InputField4.GetComponent<InputField>().text = InputField4.GetComponent<InputField>().text.ToUpper();
        InputField5.GetComponent<InputField>().text = InputField5.GetComponent<InputField>().text.ToUpper();
    }
}
