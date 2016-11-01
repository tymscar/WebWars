using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllScript : MonoBehaviour {
	public int HideTextHuh;
    public GameObject Title;
    public GameObject Hp1;
    public GameObject Hp2;
    public GameObject Fight1;
    public GameObject Fight2;
    private bool fight = false;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (HideTextHuh == 2) {
            Title.SetActive(false);
            Hp1.SetActive(true);
            Hp2.SetActive(true);
            if (fight == false)
            {
                Fight1.GetComponent<Data>().StartCoroutine(Fight1.GetComponent<Data>().fight(Fight1.GetComponent<Data>().Delay));
                Fight2.GetComponent<Data>().StartCoroutine(Fight2.GetComponent<Data>().fight(Fight2.GetComponent<Data>().Delay));
                fight = true;
                //fade out intro
                GetComponent<SoundHandler>().StartCoroutine(GetComponent<SoundHandler>().StartMusic());
                //3 2 1
                //fightclub
            }
     }

    }
}
