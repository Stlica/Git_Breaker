using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMeinScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたらメインシーンへ移動する
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("log output");
            Invoke("ChangeScene", 0.0f);

        }


    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }


}