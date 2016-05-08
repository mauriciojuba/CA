/* Store the contents for ListBoxes to display.
 */
using UnityEngine;
using System.Collections;

public class ListBank : MonoBehaviour
{
	public static ListBank Instance;

//	private int[] contents = {
//		1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 ,13 , 14, 15, 16 ,17 ,18 ,19 ,20 ,21 ,22 ,23 ,24 ,25 , 26
//	};

	private string[] contents = {
		"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "Bksp", "Clear", "Enter"
	};

	void Awake()
	{
		Instance = this;
	}

	public string getListContent( int index )
	{
		return contents[ index ];
	}


//	public string GetLetter(int index) {
//		return letras [index];
//	}
		

	public int getListLength()
	{
		return contents.Length;
	}

	public void setListContent( string[] c){
		c.CopyTo (contents, 0);
	}

}
