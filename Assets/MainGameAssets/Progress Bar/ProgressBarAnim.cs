using UnityEngine;
using UnityEngine.UI;

public class ProgressBarAnim : MonoBehaviour
{

    public Slider progressBar;
    public ScanMovement scanner;

    private float progress;
    private float increaseRate;
    private float decreaseRate;
    private bool transitioning;

    // Start is called before the first frame update
    void Start()
    {
        AdjustIncreaseRate(5);
        AdjustDecreaseRate(10);
        transitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool colliding = scanner.seeing;
        float delta = (colliding ? increaseRate : -decreaseRate) * Time.deltaTime; // deltaTime is employed in case of variable framerate
        progress = Mathf.Clamp01(progress + delta);
        progressBar.value = progress;

        if (progress == 1f)
        {
            if (!transitioning)
            {
                transitioning = true;
                // no clue what the scene transition code is, but this latching code should prevent it from activating twice
            }
        }
    }

    // time is how long it should take to complete the scan, in seconds
    public void AdjustIncreaseRate(int time)
    {
        increaseRate = 1f / time;
    }

    // time is how long it should take for a full bar to completely deplete, in seconds
    public void AdjustDecreaseRate(int time)
    {
        decreaseRate = 1f / time;
    }
}
