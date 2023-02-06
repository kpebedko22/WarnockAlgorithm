using System.Collections.Generic;
using System.Drawing;

namespace WarnockAlgorithm {
	class Polygon {

		public Color color;
		public List<MyPoint> points;

		public Polygon(List<MyPoint> points, Color color) {

			this.color = color;

			this.points = new List<MyPoint>();
			foreach (var point in points) this.points.Add(point);
		}

	}
}
