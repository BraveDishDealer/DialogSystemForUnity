using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class UITextDialog : MonoBehaviour
{
    public string input;
    public string title;
    public bool DialogAtStart;
    string ouput;


    [Header("Assingnables")]
    public Text Text;
    public Text TitleText;
    int current;
    int max;
    AudioSource s;
    [Header("Delay")]
    public bool useRandomDelay;
    public float maxDelay;
    public float minDelay;
    public float normalDelay;
    public float clearDialogDelay;
    [Header("Audio")]
    public AudioSource audioSource;
    public bool useRandomPitch;
    public float maxPitch;
    public float minPitch;
    [Header("Events")]
    public bool userAfterEvent;
    public UnityEvent afterEvent;

    private void Start()
    {
        if (DialogAtStart) StartDialog();
    }

    public void StartDialog()
    {
        if (audioSource == null) audioSource = this.gameObject.AddComponent<AudioSource>();
        TitleText.text = title;
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
            Audio();
            Text.text = ouput;
            if (useRandomDelay)
            {
                Invoke("DialogLoop", Random.Range(minDelay, maxDelay));
            }
            else Invoke("DialogLoop", normalDelay);
        }
        else Invoke("StopDialog", clearDialogDelay);
    }

    public void Audio()
    {
        if (useRandomPitch) audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play(0);
    }

    public void StopDialog()
    {
        TitleText.text = "";
        Text.text = "";
        current = -1;
        max = input.Length;
        if (userAfterEvent) afterEvent.Invoke();
    }
}
