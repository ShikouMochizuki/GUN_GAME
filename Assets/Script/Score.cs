using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score {

	private static int Point = 0;
	private static PopupText text;
	private static int count = 0;
	private static int rate = 1;

	/*
	void Update() {
		if (GameState.State == GameState.COUNT_DOWN && isInit == false) {
			Point = 0;
			isInit = true;
		}
	}
	*/

	// ‚Ð‚Ç‚¢ŽÀ‘•‚¾‚¯‚ÇŽžŠÔ‚ª‚È‚¢‚Ì‚Å
	public static void Update() {
		if (count > 0)
			--count;
		else
			rate = 1;
	}

	public static void SetText(PopupText text_) {
		text = text_;
	}

	public static int GetPoint() {
		return Point;
	}

	public static void AddPoint(int point) {
		if (count > 0)
			++rate;
		Point += point * rate;
		text.DisplayPoint(point, rate);
		count = 60;
	}

	public static void ResetPoint() {
		Point = 0;
	}
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score {

	private static int Point = 0;
	private static PopupText text;
	private static int count = 0;

	public static void SetText(PopupText text_) {
		text = text_;
	}

	public static int GetPoint() {
		return Point;
	}

	public static void AddPoint(int point) {
		Point += point;
		text.DisplayPoint(point, 1);
	}

	public static void ResetPoint() {
		Point = 0;
	}
}

 */
