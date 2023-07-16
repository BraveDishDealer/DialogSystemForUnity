using UnityEngine;

public class TextMeshDialog : MonoBehaviour
{
    public string input;
    public bool DialogAtStart;
    string ouput;


    [Header("Assingnables")]
    public TextMesh Text;
    int current;
    int max;
    AudioSource s;
    [Header("Delay")]
    public bool useRandomDelay;
    public float maxDelay;
    public float minDelay;
    public float normalDelay;
    [Header("Audio")]
    public AudioSource audioSource;
    public bool useRandomPitch;
    public float maxPitch;
    public float minPitch;

    private void Start()
    {
        if (DialogAtStart) StartDialog();
    }

    public void StartDialog()
    {
        if (audioSource == null) audioSource = this.gameObject.AddComponent<AudioSource>();
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
    }

    public void Audio()
    {
        if (useRandomPitch) audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play(0);
    }
}
