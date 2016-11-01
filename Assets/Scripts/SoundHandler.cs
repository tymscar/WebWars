using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour {

    public AudioClip[] songs;
    public AudioClip[] countdown;
    public AudioSource source;
    public AudioSource source2;

    public Text c_down;

    // Use this for initialization
    void Start () {
        //source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator music()
    {
        while (true)
        {
            int i = Random.Range(1, 4);
            Debug.Log(i);
            source.PlayOneShot(songs[i]);
            yield return new WaitForSeconds(songs[i].length);
        }
    }

    IEnumerator fadeOut()
    {
        while (source.volume != 1 && source.volume > 0.3f)
        {
            source.volume -= 0.8f * Time.deltaTime;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator countDown()
    {
        source2.PlayOneShot(countdown[0]);
        c_down.text = "READY";
        yield return new WaitForSeconds(1.5f);
        source2.PlayOneShot(countdown[1]);
        c_down.text = "3";
        yield return new WaitForSeconds(1.2f);
        source2.PlayOneShot(countdown[2]);
        c_down.text = "2";
        yield return new WaitForSeconds(1.2f);
        source2.PlayOneShot(countdown[3]);
        c_down.text = "1";
        yield return new WaitForSeconds(1.2f);
        source2.PlayOneShot(countdown[4]);
        c_down.text = "FIGHT!";
        yield return new WaitForSeconds(0.4f);
        c_down.gameObject.SetActive(false);

    }

    public IEnumerator StartMusic()
    {
        source.volume = 0.99f;
        StartCoroutine(fadeOut());
        yield return new WaitForSeconds(0);
        StartCoroutine(countDown());
        yield return new WaitForSeconds(5.1f);
        source.volume = 1;
        source.Stop();
        StartCoroutine(music());

    }


}
