using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class AppendText : MonoBehaviour
{
	private TextMeshProUGUI m_textObject;
	System.Random random = new System.Random();

	private void Awake()
	{
		m_textObject = this.gameObject.GetComponent<TextMeshProUGUI>();
	}

	private string RandomString(int length)
	{
		const string chars = "001 ";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

	private void AssignCharacter(char c)
	{
		m_textObject.text += c;
	}

	private void FixedUpdate()
	{
		List<string> strs = new List<string>();
		strs.Add(RandomString(Random.Range(0, 25)));
		strs.Add(RandomString(Random.Range(0, 125)));
		strs.Add(RandomString(Random.Range(0, 400)));


		foreach (char c in strs[Random.Range(0, strs.Count)])
		{
			AssignCharacter(c);
		}

		if (m_textObject.text.Length > 6000)
		{
			m_textObject.text = "";
		}
	}
}