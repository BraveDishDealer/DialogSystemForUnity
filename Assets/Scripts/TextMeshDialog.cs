using UnityEngine;

public class TextMeshDialog : MonoBehaviour
{
    public string input;
    public bool DialogAtStart;
    string ouput;


    [Header("Assingnables")]
    public TextMesh Text;
    public float delay;
    public AudioClip typeSound;
    int current;
    int max;
    AudioSource s;
    [Header("Random Delay")]
    public bool useRandomDelay;
    public float maxDelay;
    public float minDelay;

    private void Start()
    {
        if (DialogAtStart) StartDialog();
    }

    public void StartDialog()
    {
        if (!this.gameObject.GetComponent<AudioSource>()) s = this.gameObject.AddComponent<AudioSource>();
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
            s.clip = typeSound;
            s.Play(0);
            Text.text = ouput;
            if (useRandomDelay)
            {
                Invoke("DialogLoop", Random.Range(minDelay, maxDelay));
            }
            else Invoke("DialogLoop", delay);
        }
    }
}
