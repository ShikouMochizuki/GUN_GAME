using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score {

	private static int Point = 0;
	private static PopupText text;

	/*
	void Update() {
		if (GameState.State == GameState.COUNT_DOWN && isInit == false) {
			Point = 0;
			isInit = true;
		}
	}
	*/

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
