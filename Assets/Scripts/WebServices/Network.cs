using System.Xml;
using UnityEngine;
using System.Collections;
using NumberKnightConstants;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Network : MonoBehaviour {

	XmlDocument xml;
	string url = "https://api.scoreoid.com/v1/{0}";
    public WWW requestReturn;
    public void LogIn()
    {
        WWWForm logInForm = setUpForm();
        string username = GameObject.Find("UsernameText").GetComponent<Text>().text;
        string password = GameObject.Find("PasswordText").GetComponent<Text>().text;
        logInForm.AddField("username", username);
        logInForm.AddField("password", password);
        string logInUrl = string.Format(url, "getPlayer");
        LogInForm(logInForm, logInUrl);
        Debug.Log("Logging in ");

    }

    #region Private Methods
    WWWForm setUpForm()
    {
        WWWForm form = new WWWForm();

        form.AddField("api_key", Constants.api_key);
        form.AddField("game_id", Constants.game_id);
        form.AddField("response", Constants.responseType);

        return form;
    }
    void LogInForm(WWWForm form, string url)
    {
        WWW www = new WWW(url, form);
        StartCoroutine(LogInRequest(www));
    }
    void AjaxPostForm(WWWForm form, string url)
    {
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
       
        /* Check for errors */
       if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    IEnumerator LogInRequest(WWW www)
    {
        yield return www;

        /* Check for errors */
        if (!www.text.Contains("error"))
        {
            Debug.Log("Log in Successful: " + www.text);
            PlayerContainer p = new PlayerContainer();
            p = PlayerContainer.LoadFromText(www.text);
            Debug.Log(p.playerList[0].Username);
            SceneManager.ChangeScene(1);
        }
        else
        {
            Debug.Log("Log in Error " + www.text);
        }
    }
    #endregion

}
