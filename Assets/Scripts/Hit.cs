using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {
    public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "LeftWall")
        {
            // Debug.Log("Hit Player");
            parent.GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);
        }
        if (col.gameObject.tag == "RightWall")
        {
            // Debug.Log("Hit Player");
            parent.GetComponent<Rigidbody>().velocity = new Vector3(-3, 0, 0);
        }
        Debug.Log("Hit me again!");
        if (col.gameObject.tag == "Player")
        {
            //float temp = col.gameObject.GetComponent<Data>().str;
            //Debug.Log("Hit for " + temp);
            //dmg
            Debug.Log(col.rigidbody.velocity.x);
            parent.GetComponent<Data>().hit_to_the_face(col.gameObject.GetComponent<Data>().str * (Mathf.Abs(col.rigidbody.velocity.x)/3));
        }
        if(col.gameObject.tag == "Wall")
        {


        }
    }
}
