using UnityEngine;
using System.Collections;

public class TextXML : MonoBehaviour {

	private string text = "";
	// Use this for initialization
	void Start () {
		string xmlText = System.IO.File.ReadAllText (Application.dataPath + "/Data/skill.xml");
		DataSheetReader.XMLReader reader = new DataSheetReader.XMLReader (xmlText);

		while(reader.Read())
		      {
			if(reader.isOpeningTag)
			{
				text += (reader.tagName + " \"" + reader.content + "\"\n");
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		GUI.Label (new Rect (0, 0, 500, 500), text);
	}
}
