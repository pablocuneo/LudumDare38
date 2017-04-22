using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    [SerializeField]
    Image progressBarFull;

    public float barProgress = 0f;

    void Update () {
		//Fill amount range 0-1
		progressBarFull.fillAmount = barProgress;
    }
}
