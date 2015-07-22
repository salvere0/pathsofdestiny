using UnityEngine;
using System.Collections;

public class DataSheetReader {
	public class XMLReader
	{
		private string xmlString = "";
		private int idx = 0;

		public XMLReader(string xmlString)
		{
			this.xmlString = xmlString;
		}
	

	public string tagName = "";
	public bool isOpeningTag = false;
	public string content = "";

		int IndexOf(char _c, int _i)
		{
			int i = _i;
			while (i < xmlString.Length) 
			{
				if(xmlString[i] == _c)
				{
					return i;
				}
				++i;
			}
			return -1;
		}
		public bool Read()
		{
			if (idx > -1)
				idx = xmlString.IndexOf ("<", idx);

			if (idx == -1) 
			{
				return false;
			}

			++idx;

			int endOfTag = IndexOf ('>', idx);
			int endOfName = IndexOf (' ', idx);
			if ((endOfName == -1) || (endOfTag < endOfName))
			{
				endOfName = endOfTag;
			}

			if (endOfTag == -1) 
			{
				return false;
			}

			tagName = xmlString.Substring(idx, endOfName - idx);
			idx = endOfTag;

			if (tagName.StartsWith ("/")) {
				isOpeningTag = false;
				tagName = tagName.Remove (0, 1);
			}
			else
			{
				isOpeningTag = true;
			}

			if (isOpeningTag) {
				int startOfCloseTag = xmlString.IndexOf ("<", idx);
				if (startOfCloseTag == -1) {
					return false;
				}
			
				content = xmlString.Substring(idx +1, startOfCloseTag - idx - 1);
				content = content.Trim();
			}
			return true;

		}

		public bool Read(string endingTag)
		{
			bool retVal = Read ();
			if (tagName == endingTag && !isOpeningTag) {
				retVal = false;
			}
			return retVal;
		}
	}
}
