using UnityEngine;
using System.Collections;




//This class is a static class that houses basic math functions
public static class MathLambda
{

	//
	public static int AddTillEqualTo (int value, int Add, int Max)
	{
		value += Add;
		value = value > Max ? Max : value;
		return value;
	}

	public static float AddTillEqualTo (float value, float Add, float Max)
	{
		value += Add;
		value = value > Max ? Max : value;
		return value;
	}

	public static int[] AddTillEqualTo_With_LeftOver (int value, int add, int max)
	{
		int[] temp = new int[2];


		temp [0] = (value + add) > max ? max : value + add;
		temp [1] = (value + add) < max ? 0 : Mathf.Abs (max - (value + add));
		return temp;
	}

	public static float[] AddTillEqualTo_LeftOver (this float value, float add, float max)
	{
		float[] temp = new float[2];


		temp [0] = (value + add) > max ? max : value + add;
		temp [1] = (value + add) < max ? 0 : Mathf.Abs (max - (value + add));
		return temp;
	}
	
	//
	public static int SubtractTillZero (int value, int sub)
	{
		value -= sub;
		value = value < 0 ? 0 : value;
		return value;
	}

	public static float SubtractTillZero (float value, float sub)
	{
		value -= sub;
		value = value < 0 ? 0 : value;
		return value;
	}
	//

	//
	public static int[] SubtractTillZero_LeftOver (int value, int sub)
	{
		int[] temp = new int[2];

		temp [0] = (value - sub) < 0 ? 0 : value - sub;
		temp [1] = (value - sub) > 0 ? 0 : Mathf.Abs (value - sub);
		return temp;
	}

	public static float[] SubtractTillZero_LeftOver (float value, float sub)
	{
		float[] temp = new float[2];

		temp [0] = (value - sub) < 0 ? 0 : value - sub;
		temp [1] = (value - sub) > 0 ? 0 : Mathf.Abs (value - sub);
		return temp;
	}
	//



	public static bool FlagBool (int Flag, int Value)
	{
		return (Flag & Value) == Value;
	}
}


