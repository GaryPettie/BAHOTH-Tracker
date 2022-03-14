using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class Character : MonoBehaviour {
	
	public CharacterSO character;

	[SerializeField] TextMeshProUGUI characterName;
	[SerializeField] TextMeshProUGUI age;
	[SerializeField] TextMeshProUGUI height;
	[SerializeField] TextMeshProUGUI weight;
	[SerializeField] TextMeshProUGUI hobbies;
	[SerializeField] TextMeshProUGUI birthday;
	[SerializeField] TextMeshProUGUI[] speed;
	[SerializeField] TextMeshProUGUI[] might;
	[SerializeField] TextMeshProUGUI[] sanity;
	[SerializeField] TextMeshProUGUI[] knowledge;
	[SerializeField] Color defaultColor;
	[SerializeField] Color startingColor;
	[SerializeField] GameObject[] markers;

	int currentSpeedIndex;
	int currentMightIndex;
	int currentSanityIndex;
	int currentKnowledgeIndex;

	public static Character instance;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(this);
		}
	}

	void Start () {
		Setup();
	}

	public void Setup () {
		characterName.text = character.characterName;
		//avatar.sprite = character.avatar;
		age.text = "Age: " + character.age;
		height.text = "Height: " + character.height;
		weight.text = "Weight: " + character.weight;

		StringBuilder str = new StringBuilder();
		for (int i = 1; i < character.hobbies.Length; i++) {
			str.Append(", " + character.hobbies[i]);
		}

		hobbies.text = "Hobbies: " + character.hobbies[0] + str;
		birthday.text = "Birthday: " + character.birthday;

		for (int i = 0; i < character.speed.Length; i++) {
			speed[i].text = character.speed[i].ToString();
			speed[i].faceColor = defaultColor;
			if (i == character.startingSpeedIndex) {
				speed[i].faceColor = startingColor;
			}
		}

		for (int i = 0; i < character.might.Length; i++) {
			might[i].text = character.might[i].ToString();
			might[i].faceColor = defaultColor;
			if (i == character.startingMightIndex) {
				might[i].faceColor = startingColor;
			}
		}

		for (int i = 0; i < character.sanity.Length; i++) {
			sanity[i].text = character.sanity[i].ToString();
			sanity[i].faceColor = defaultColor;
			if (i == character.startingSanityIndex) {
				sanity[i].faceColor = startingColor;
			}
		}

		for (int i = 0; i < character.knowledge.Length; i++) {
			knowledge[i].text = character.knowledge[i].ToString();
			knowledge[i].faceColor = defaultColor;
			if (i == character.startingKnowledgeIndex) {
				knowledge[i].faceColor = startingColor;
			}
		}

		currentSpeedIndex = character.startingSpeedIndex;
		currentMightIndex = character.startingMightIndex;
		currentSanityIndex = character.startingSanityIndex;
		currentKnowledgeIndex = character.startingKnowledgeIndex;

		markers[0].transform.position = speed[currentSpeedIndex].transform.position;
		markers[1].transform.position = might[currentMightIndex].transform.position;
		markers[2].transform.position = sanity[currentSanityIndex].transform.position;
		markers[3].transform.position = knowledge[currentKnowledgeIndex].transform.position;
	}

	public void ModifySpeed (int amount) {
		ModifyStat(0, ref speed, ref currentSpeedIndex, amount);
	}

	public void ModifyMight (int amount) {
		ModifyStat(1, ref might, ref currentMightIndex, amount);
	}

	public void ModifySanity (int amount) {
		ModifyStat(2, ref sanity, ref currentSanityIndex, amount);
	}

	public void ModifyKnowledge (int amount) {
		ModifyStat(3, ref knowledge, ref currentKnowledgeIndex, amount);
	}

	void ModifyStat (int markerIndex, ref TextMeshProUGUI[] stats, ref int currentStat, int amount) {
		currentStat += amount;
		if (currentStat > stats.Length - 1) { currentStat = stats.Length - 1; }
		if (currentStat < 0) { currentStat = 0; }
		markers[markerIndex].transform.position = stats[currentStat].transform.position;
	}
}
