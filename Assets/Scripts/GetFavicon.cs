using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetFavicon : MonoBehaviour {

	public string url;
	public Texture2D favicontexture;
	public Text urlText;
	public GameObject inputField;
	public GameControllScript gameController;
	// Use this for initialization
	public void StartWathevs () {
		url = "http://www.google.com/s2/favicons?domain_url=http%3A%2F%2Fwww." + urlText.text;
		StartCoroutine (downloadFavicon (url));
	}


	IEnumerator downloadFavicon(string url)
	{
			WWW www = new WWW (url);
			inputField.SetActive (false);
			Debug.Log ("Assigned url");
			while (www.isDone == false)
				yield return new WaitForSeconds (1);
			www.LoadImageIntoTexture (favicontexture);
			Debug.Log ("Downloaded favicon");
			GetComponent<Renderer> ().material.mainTexture = favicontexture;
			Debug.Log ("Assigned the texture to the material");
		yield return new WaitForSeconds (1);
		gameController.HideTextHuh++;
	}
}
