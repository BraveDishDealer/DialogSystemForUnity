using UnityEngine.UI;
using UnityEngine;

public class UITextDialog : MonoBehaviour
{
    public string input;
    public bool DialogAtStart;
    string ouput;


    [Header("Assingnables")]
    public Text Text;
    public float delay;
    int current;
    int max;

    private void Start()
    {
        if (DialogAtStart) StartDialog();
    }

    public void StartDialog()
    {
        Text.text = "";
        current = -1;
        max = input.Length;
        DialogLoop();
    }

    public void DialogLoop()
    {
        current++;
        if (current < max)
        {
            char c = input[current];
            ouput += c;
            Text.text = ouput;
            Invoke("DialogLoop", delay);
        }
    }
}
