using UnityEngine;
using System.Collections.Generic;

namespace Destructible2D
{
	public static partial class D2dFloodfill
	{
		public class Island
		{
			public int MinX;

			public int MinY;

			public int MaxX;

			public int MaxY;

			public int Count;

			public List<Line> Lines = new List<Line>();

			private List<D2dFloodfillPixel> pixels = new List<D2dFloodfillPixel>();
		
			public void Clear()
			{
				Lines.Clear();
			}

			private int GetDistance(int x, int y, Line line)
			{
				var l = line.MinX - x;
				var r = x - line.MaxX;
				var d = Mathf.Abs(y - line.Y);

				if (d < l) d = l;
				if (d < r) d = r;

				return d;
			}

			public void Submit(D2dSplitGroup splitGroup, int feather, int alphaWidth, int alphaHeight)
			{
				var minX = MinX - feather; if (minX < 0) minX = 0;
				var minY = MinY - feather; if (minY < 0) minY = 0;
				var maxX = MaxX + feather; if (maxX > alphaWidth ) maxX = alphaWidth;
				var maxY = MaxY + feather; if (maxY > alphaHeight) maxY = alphaHeight;

				for (var i = 0; i < maxX; i++)
				{
					if (i == pixels.Count)
					{
						pixels.Add(new D2dFloodfillPixel());
					}
				}

				for (var y = minY; y < maxY; y++)
				{
					var featheredRow = featheredRows[y];

					for (var i = minX; i < maxX; i++)
					{
						var pixel = pixels[i];
						
						pixel.Island   = null;
						pixel.Distance = feather + 1;
					}

					for (var i = featheredRow.Lines.Count - 1; i >= 0; i--)
					{
						var featheredLine = featheredRow.Lines[i];

						for (var x = featheredLine.MinX - feather; x < featheredLine.MaxX + feather; x++)
						{
							if (x >= minX && x < maxX)
							{
								var pixel    = pixels[x];
								var distance = GetDistance(x, y, featheredLine);

								if (distance < pixel.Distance)
								{
									pixel.Island   = featheredLine.Island;
									pixel.Distance = distance;
								}
							}
						}
					}

					for (var x = minX; x < maxX; x++)
					{
						if (pixels[x].Island == this)
						{
							splitGroup.AddPixel(x, y);
						}
					}
				}
			}
		}
	}
}