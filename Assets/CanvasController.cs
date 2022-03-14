using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	[SerializeField] Canvas selectCanvas;
	[SerializeField] Canvas statCanvas;

	public static CanvasController instance;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(instance);
		}
	}

	public void EnableSelectionCanvas () {
		selectCanvas.enabled = true;
		statCanvas.enabled = false;
	}

	public void EnableStatsCanvas () {
		statCanvas.enabled = true;
		selectCanvas.enabled = false;
	}
}
