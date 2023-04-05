using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {
	public Transform mainMenu, creditsMenu;
	public void LoadScene(string name){
		SceneManager.LoadScene(name);
	}
	public void QuitGame(){
		Application.Quit();
	}
	// ADD OPTIoNS MENU HERE

	public void CreditsMenu(bool clicked){
		if (clicked == true){
			creditsMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(false);
		}
		else{
			creditsMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(true);
		}
	}
}
