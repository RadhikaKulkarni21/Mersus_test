using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft;
using JSONhandler;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public InputField username;
    public InputField password;
    //public GameObject responseType;
    public static string user;
	public string sceneNext;

	public string URL = "http://localhost/accounts.php";

	public void DoLogin()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", username.ToString());
		form.AddField("password", password.ToString());
		WWW w = new WWW(URL, form);
		StartCoroutine(Login(w));
		Debug.Log("Success");
	}
	IEnumerator Login(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			if (w.text.Contains("username"))
			{
				user = w.text;
				LoadScene(sceneNext);
				Debug.Log("Success");
				//LoggedIn = true;
			}
		}
	}
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

}