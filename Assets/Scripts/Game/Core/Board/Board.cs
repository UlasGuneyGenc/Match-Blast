using System;
using System.Collections.Generic;
using System.Linq;
using Game.Core.Item;
using Game.Mechanics;
using UnityEngine;
using Game.Items;
using Settings;

namespace Game.Core.Board
{
	public class Board : MonoBehaviour
	{
		
		public Cell CellPrefab;
		
		public Transform CellsParent;
		public Transform ItemsParent;
		public Transform ParticlesParent;

		[HideInInspector] public Cell[,] Cells = new Cell[GameSettings.column,GameSettings.row];
	
		public void Prepare()
		{
			CreateCells();
			PrepareCells();
		}
		
		private void CreateCells()
		{
			
			for (var y = 0; y < GameSettings.row; y++)
			{
				for (var x = 0; x < GameSettings.column; x++)
				{
					var cell = Instantiate(CellPrefab, Vector3.zero, Quaternion.identity, CellsParent);
					Cells[x, y] = cell;
				}
			}
		}

		private void PrepareCells()
		{
			for (var y = 0; y < GameSettings.row; y++)
			{
				for (var x = 0; x < GameSettings.column; x++)
				{
					Cells[x, y].Prepare(x, y, this);
				}
			}
		}
		public void CellTapped(Cell cell)
		{
			if (cell == null) return;
			
			if (!cell.HasItem() || !cell.Item.IsMatchable()) return;
		
			Explore(cell);
		}
		
		//if clicked cell is 
		public void Explore(Cell cell)
		{
			var matchFinder = new MatchFinder(Cells);
			var cells = matchFinder.FindMatch(cell, cell.Item.GetItemType());
			if (cells == null) return;
			ExplodeMatchingCells(cells);
		}
		private void ExplodeMatchingCells(List<Cell> cells)
		{
			for (var i = 0; i < cells.Count; i++)
			{
				var explodedCell = cells[i];
				var item = explodedCell.Item;
				item.TryExecute();
			}
		}

		public Cell GetNeighbourWithDirection(Cell cell, Direction direction)
		{
			var x = cell.X;
			var y = cell.Y;
			switch (direction)
			{
				case Direction.None:
					break;
				case Direction.Up:
					y += 1;
					break;
				case Direction.UpRight:
					y += 1;
					x += 1;
					break;
				case Direction.Right:
					x += 1;
					break;
				case Direction.DownRight:
					y -= 1;
					x += 1;
					break;
				case Direction.Down:
					y -= 1;
					break;
				case Direction.DownLeft:
					y -= 1;
					x -= 1;
					break;
				case Direction.Left:
					x -= 1;
					break;
				case Direction.UpLeft:
					y += 1;
					x -= 1;
					break;
				default:
					throw new ArgumentOutOfRangeException("direction", direction, null);
			}

			if (x >= GameSettings.column || x < 0 || y >= GameSettings.row || y < 0) return null;

			return Cells[x, y];
		}
	}
}
