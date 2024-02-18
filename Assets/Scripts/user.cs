using UnityEngine;
using System.Runtime.InteropServices;

public class user : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern string SessionToken();

    public static string token;

    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            token = SessionToken();
            Debug.Log("Session Token: " + token);
        }
    }

}