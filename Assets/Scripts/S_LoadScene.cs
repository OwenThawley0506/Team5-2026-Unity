using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_LoadScene : MonoBehaviour
{
    private void Start()
    {
        // load scene a into scene b
        SceneManager.LoadScene("DialogSystem", LoadSceneMode.Additive);
    }
}
