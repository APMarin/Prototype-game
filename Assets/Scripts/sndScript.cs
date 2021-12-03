using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sndScript : MonoBehaviour
{

    private float waitToPlayf = .50f;
    public static AudioClip footstep1;
    public static AudioClip footstep2;
    static AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        footstep1 = Resources.Load<AudioClip> ("foostep_1");
        footstep2 = Resources.Load<AudioClip> ("foostep_2");

        audiosrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void playFootsteps()
    {
        audiosrc.PlayOneShot(footstep1);
        waitToPlayf -= Time.deltaTime;
        if(waitToPlayf <= 0)
        {
            audiosrc.PlayOneShot(footstep2);
            waitToPlayf = .50f;
        }
    }
}
