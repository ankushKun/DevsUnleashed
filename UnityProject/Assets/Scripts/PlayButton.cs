using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public AnimationCurve myCurve;
    private ParticleSystem clickParticles;

    void Start()
    {
        clickParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }

    void OnMouseDown()
    {
        print("Play btn clicked");
        clickParticles.Play();
    }
}
