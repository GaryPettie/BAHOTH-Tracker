using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Stats")]
public class CharacterSO : ScriptableObject {

	public string characterName;
	public string age;
	public string height;
	public string weight;
	public string[] hobbies;
	public string birthday;
	public int startingSpeedIndex = 3;
	public int startingMightIndex = 3;
	public int startingSanityIndex = 3;
	public int startingKnowledgeIndex = 5;
	public int[] speed = new int[9];
	public int[] might = new int[9];
	public int[] sanity = new int[9];
	public int[] knowledge = new int[9];
}
