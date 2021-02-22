using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text TextField;

    public void setText (string text)
    {
        TextField.text = text;
    }
}
