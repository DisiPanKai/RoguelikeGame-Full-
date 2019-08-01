using UnityEngine;


public class ErrorWindow : MonoBehaviour {

    public void ErrorWindowGoAway()
    {
        GameObject.Find("Error Window").SetActive(false);
    }
}
