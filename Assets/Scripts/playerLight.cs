using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLight : MonoBehaviour
{

    public RectTransform lightBar;
    public float maxLight;
    public float currentLight;
    private float lightBarMaxWidth;
    private float lightBarHeight;
	// Start is called before the first frame update
	void Start()
    {
        currentLight = maxLight;
        lightBarMaxWidth = lightBar.sizeDelta.x;
        lightBarHeight = lightBar.sizeDelta.y;
	}
    // Update is called once per frame
    void Update()
    {
        float newWidth = (currentLight / maxLight) * lightBarMaxWidth;
        lightBar.sizeDelta = new Vector2(newWidth, lightBarHeight);
	}
}
