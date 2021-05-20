using System;
using Game.Core.Board;
using UnityEngine;
using System.Collections.Generic;
using Game.Core.Item;
using Game.Items;
using Settings;

namespace Game.Mechanics
{	
	public class HintManager : MonoBehaviour 
	{
		public Board Board;
		private bool[,] _visitedCells;
		private int _firstHint;
		private int _secondHint;
		private int _thirdHint;
		
		// Update is called once per frame
		private void Awake()
		{
			_firstHint = GameSettings.firstHint != 0 ? GameSettings.firstHint : 3;
			
			_secondHint = GameSettings.secondHint != 0 ? GameSettings.secondHint : 4;
			
			_thirdHint = GameSettings.thirdHint != 0 ? GameSettings.thirdHint : 5;
			
		}

		void Update () 
		{
			for (int y = 0; y < Settings.GameSettings.row; y++) {
				for (int x = 0; x < Settings.GameSettings.column; x++) {
					var cell = Board.Cells [x, y];
					if (cell.HasItem ()) {
						List<Cell> adjacent = FindMatch (Board.Cells [x, y], Board.Cells [x, y].Item.GetItemType ());
						if (adjacent != null && adjacent.Count > _firstHint && adjacent.Count <= _secondHint) {
							for (int i = 0; i < adjacent.Count; i++) {
								if (adjacent [i].HasItem ()) {
									var item = (CubeItem)adjacent [i].Item;
									item.openHintA();
								}
							}
						}
						
						else if (adjacent != null && adjacent.Count > _secondHint && adjacent.Count <= _thirdHint) {
							for (int i = 0; i < adjacent.Count; i++) {
								if (adjacent [i].HasItem ()) {
									var item = (CubeItem)adjacent [i].Item;
									item.openHintB();
								}
							}
						}
						
						else if (adjacent != null && adjacent.Count > _thirdHint ) {
							for (int i = 0; i < adjacent.Count; i++) {
								if (adjacent [i].HasItem ()) {
									var item = (CubeItem)adjacent [i].Item;
									item.openHintC();
								}
							}
						}
						else {
							for (int i = 0; i < adjacent.Count; i++) {
								if (adjacent [i].HasItem ()) {
									var item = (CubeItem)adjacent [i].Item;
									item.ChangetoNonHint();
								}

							}
						}
					}
				}
			}
		}

		public List<Cell> FindMatch(Cell cell, ItemType itemType)
		{
			_visitedCells = new bool[Settings.GameSettings.column, Settings.GameSettings.row];

			for (var y = 0; y < Settings.GameSettings.row; y++)
			{
				for (var x = 0; x < Settings.GameSettings.column; x++)
				{
					_visitedCells[x, y] = false;
				}
			}

			var resultCells = new List<Cell>();

			FindMatches(cell, itemType, resultCells);

			return resultCells;

		}

		private void FindMatches(Cell cell, ItemType itemType, List<Cell> resultCells)
		{
			if (cell == null) return;

			var x = cell.X;
			var y = cell.Y;
			if (_visitedCells[x, y]) return;

			_visitedCells[x, y] = true;

			if (cell.HasItem() && cell.Item.IsMatchable() && cell.Item.GetItemType() == itemType)
			{
				resultCells.Add(cell);

				var neighbours = cell.Neighbours;
				if (neighbours.Count == 0) return;

				for (var i = 0; i < neighbours.Count; i++)
				{	
					FindMatches(neighbours[i], itemType, resultCells);
				}
			}
		}
	}
}
