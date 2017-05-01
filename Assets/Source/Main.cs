using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

public class Main : MonoBehaviour {

	delegate void delegate_message_from_js(string json);

	void Start() 
	{
		set_callbacks(messageFromJS);
	}

	[DllImport("__Internal")]
	private static extern void set_callbacks(
		delegate_message_from_js delegate_message_from_js
	);

	[MonoPInvokeCallback(typeof(delegate_message_from_js))]
	private static void messageFromJS(string JSON)
	{
		if(string.IsNullOrEmpty(JSON) == false) 
		{
			SomeStructure exampleStructure = JsonConvert.DeserializeObject<SomeStructure>(JSON);
	
			string str = string.Format("exampleStructure.X= {0}, exampleStructure.Y= {1}, exampleStructure.SomeString= {2}, exampleStructure.StringList[1]= {3}",
				exampleStructure.X,
				exampleStructure.Y,
				exampleStructure.SomeString,
				exampleStructure.StringList[1]
			);

			Debug.Log(str);
		} 

		else
		{
			Debug.Log("JSON is empty!");
		}
	}

	private struct SomeStructure
	{
		[JsonProperty("x")]
		public int X { get; set ; }

		[JsonProperty("y")]
		public int Y { get; set ; }

		[JsonProperty("some_string")]
		public string SomeString { get; set; }

		[JsonProperty("string_list")]
		public List<string> StringList { get; set; }
	}
}
