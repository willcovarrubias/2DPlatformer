using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParallaxing : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing;

    private Vector3 previousCameraPos;

    // Use this for initialization

    private void Awake()
    {
        backgrounds[0] = GameObject.FindGameObjectWithTag("FarBackground").transform;
        backgrounds[1] = GameObject.FindGameObjectWithTag("MiddleBackground").transform;
        backgrounds[2] = GameObject.FindGameObjectWithTag("NearBackground").transform;
        backgrounds[3] = GameObject.FindGameObjectWithTag("Foreground").transform;
    }
    void Start () {

        
        previousCameraPos = transform.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {

        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 parallax = (previousCameraPos - transform.position) * (parallaxScales[i] / smoothing);

            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y, backgrounds[i].position.z);

        }

        previousCameraPos = transform.position;
	}
}
