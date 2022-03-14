using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	[SerializeField] Canvas selectCanvas;
	[SerializeField] Canvas statCanvas;
	[SerializeField] CharacterSO[] characterList;

	void Start () {
		selectCanvas.enabled = true;
		statCanvas.enabled = false;
	}

	public void LoadCharacter (int index) {
		Character.instance.character = characterList[index];
		Character.instance.Setup();
		CanvasController.instance.EnableStatsCanvas();
	}
}
