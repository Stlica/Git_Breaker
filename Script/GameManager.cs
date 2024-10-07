using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	public int Main;

	public void Activate()
	{
		SceneManager.LoadScene("MenuScene");
	}

	void Update()
	{
		if (Input.GetKeyDown("joystick 1 button 6")|| Input.GetKeyDown("joystick 2 button 6"))
		{
			EndGame();
		}



		if (Input.anyKey)
		{
			Activate();
		}
		
	}


	private void EndGame()
	{
		//Esc�������ꂽ��
		

#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
	}
}
