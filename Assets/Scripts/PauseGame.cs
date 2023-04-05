﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class PauseGame : MonoBehaviour {

	public Transform canvas;
	public Transform Player;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
			Pause();
		}
	}
	public void Pause() {

		if (canvas.gameObject.activeInHierarchy == false)
			{
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
				Player.GetComponent<FirstPersonController>().enabled = false;
			}
			else
			{
				canvas.gameObject.SetActive(false);
				Time.timeScale = 1;
				Player.GetComponent<FirstPersonController>().enabled = true;
			}
	}
}
