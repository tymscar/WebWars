using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour {

    public Text urlText;
    public GameObject controller;
    private string url;
    public GameObject Self;
    public GameObject Other;
    public Slider HealthBar;


    public AudioClip jump;
    public AudioClip hit;
    private AudioSource source;

    public bool ready = false;
    public bool grounded = false;
    public float Delay = 0;
    private int jxstr;
    private int jystr;
    public float str;
    private float def = 1;
    private float maxDef;
    private int y = 2;
    private string land_sound;

    private bool fighting = true;

    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        if(def <= 0)
        {
            fighting = false;
            StartCoroutine(restart());
            Debug.Log(url + "Loses!");
            //Destroy(this.gameObject);
            this.GetComponentInChildren<Renderer>().enabled = false;
            

        }
        HealthBar.value = def / maxDef;
    }

    public void hit_to_the_face(float dmg)
    {
        Debug.Log(url + " got hit!");
        def = def - dmg*100;
    }

    public void Url()
    {
        StartCoroutine(x(urlText.text));
    }


   public IEnumerator fight(float delay)
    {
        yield return new WaitForSeconds(5.8f);
        while (fighting == true) { 
            if (this.gameObject.transform.position.x > Other.gameObject.transform.position.x && grounded == true)
            {
                //jump left
                Self.GetComponent<Rigidbody>().AddForce(new Vector3(-1*(jxstr * y + 350) * Random.Range(0.9f, 1.1f), jystr * y * 4,0 * Random.Range(0.9f, 1.1f)));
                grounded = false;

                yield return new WaitForSeconds(delay/2);

            }
            else if (this.gameObject.transform.position.x < Other.gameObject.transform.position.x && grounded == true)
            {
                //jump right
                Self.GetComponent<Rigidbody>().AddForce(new Vector3(jxstr * y + 250, jystr * y * 4, 0));
                grounded = false;

                yield return new WaitForSeconds(delay/2);


            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(5);
        //continue
        SceneManager.LoadScene(0);
    }

    IEnumerator x(string site)
    {

        url = "https://developer.majestic.com/api/xml?app_api_key=8837D6D9BE6D6A6B1CAD8C7801CE9DE0&cmd=GetIndexItemInfo&items=1&item0=www." + site + "&datasource=fresh";
        //Debug.Log(url);
        WWW www = new WWW(url);
        string temp;
        yield return www;
        //Debug.Log(www.text);
        temp = www.text;
        string[] temps = temp.Split(new[] { "<Row>" }, System.StringSplitOptions.None);
        string[] temps2 = temps[1].Split(new[] { "</Row>" }, System.StringSplitOptions.None);
        temp = temps2[0];
        string[] temps3 = temps2[0].Split(new[] { "|" }, System.StringSplitOptions.None);
        //Debug.Log(temp);
        if (temps3[34].ToString() == null || temps3[34].ToString() == " " || temps3[34].ToString() == "" || int.Parse(temps3[34].ToString()) < 35)
        {
            temps3[34] = "35";
        }
        if ( temps3[35].ToString() == null || temps3[35].ToString() == " " || temps3[35].ToString() == "" || int.Parse(temps3[34].ToString()) < 35)
        {
            temps3[35] = "35";
        }
        if (temps3[38].ToString() == null || temps3[38].ToString() == " " || temps3[38].ToString() == "" || int.Parse(temps3[34].ToString()) < 35)
        {
            temps3[38] = "50";
        }
        if (temps3[40].ToString() == null || temps3[40].ToString() == " " || temps3[40].ToString() == "" || int.Parse(temps3[34].ToString()) < 35)
        {
            temps3[40] = "35";
        }
        if (temps3[42].ToString() == null || temps3[42].ToString() == " " || temps3[42].ToString() == "" || int.Parse(temps3[34].ToString()) < 35)
        {
            temps3[42] = "35";
        }
        Delay = float.Parse(temps3[34]) / 20;
        Debug.Log(Delay);
        jxstr = int.Parse(temps3[35]);
        jystr = int.Parse(temps3[38]);
        if(jystr < 35)
        {
            jystr = 35;

        }
        str = 1 / float.Parse(temps3[40]);
        Debug.Log(int.Parse(temps3[42]));
        def = int.Parse(temps3[42]) + 100;
        if (def < 135)
        {
            def = 135;
        }
        maxDef = def;
        Debug.Log(def);

        /*
        //Website
        Debug.Log(temps3[1]);

        Debug.Log("CitationFlow");
        Debug.Log(temps3[34]);

        Debug.Log("TrustFlow");
        Debug.Log(temps3[35]);

        Debug.Log(temps3[37]);
        Debug.Log(temps3[38]);

        Debug.Log(temps3[39]);
        Debug.Log(temps3[40]);

        Debug.Log(temps3[41]);
        Debug.Log(temps3[42]);
        */
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Hit something");
        if (col.gameObject.tag == "Floor")
        {
            //Debug.Log("Hit Floor");

            source.PlayOneShot(jump);

            grounded = true;
        }

        if (col.gameObject.tag == "Player")
        {
            // Debug.Log("Hit Player");

            source.PlayOneShot(hit);

            grounded = true;
        }
        if (col.gameObject.tag == "Head")
        {
            // Debug.Log("Hit Player");

            source.PlayOneShot(hit);

            grounded = true;
        }
        if (col.gameObject.tag == "Wall")
        {
            // Debug.Log("Hit Player");
            this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x * -1, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z * -1);
        }
    }
}
