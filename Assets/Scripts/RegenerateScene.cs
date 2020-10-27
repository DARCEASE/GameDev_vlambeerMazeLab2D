using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegenerateScene : MonoBehaviour
{
    public FloorMaker fm;
    public GameObject floorScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        Debug.Log("you restarted the scene!");
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
