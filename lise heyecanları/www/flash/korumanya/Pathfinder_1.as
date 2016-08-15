package  {
	
	import flash.geom.Point;
	import Node;
	
	class Pathfinder_1 {
		
		private var nodes:Array;
		private var openList:Array;
		private var closedList:Array;
		private var startNode:Node;
		private var targetNode:Point;
		private var numberOfOpenListItems:Number;
		private var nodesChecked:Number;
		
		public function Pathfinder_1(nodes:Array, startPosition:Point, targetPosition:Point) {
			this.nodes = nodes;
			var arraySize:Number = this.nodes.length * this.nodes[0].length;
			numberOfOpenListItems = 1;
			nodesChecked = 1;
			openList = new Array(arraySize);
			closedList = new Array(arraySize);
			startNode = new Node(startPosition, 0, 0, 0,undefined);
			openList[this.numberOfOpenListItems] = startNode;
			targetNode = targetPosition;
		}
		
		public function getHValue(startNode:Point, targetNode:Point):Number {
			var distance1:Number = Math.abs(targetNode.x - startNode.x);
			var distance2:Number = Math.abs(targetNode.y - startNode.y);
			return distance1 + distance2;
		}
		
		public function getAdjacentNodes(pos:Point):Array {
			var startX:Number = pos.x;
			var startY:Number = pos.y;
			var adjacentNodes:Array = new Array();
			if(startX - 1 > 0) {
				if(nodes[startX-1][startY] == 1) {
					adjacentNodes.push(new Point(startX-1, startY));
				}
			}
			if(startX+1 < nodes.length) {
				if(nodes[startX+1][startY] == 1) {
					adjacentNodes.push(new Point(startX+1, startY));
				}
			}
			if(startY-1 > 0) {
				if(nodes[startX][startY-1] == 1) {
					adjacentNodes.push(new Point(startX, startY-1));
				}
			}
			if(startY+1 < nodes[0].length) {
				if(nodes[startX][startY+1] == 1) {
					adjacentNodes.push(new Point(startX, startY+1));
				}
			}
			return adjacentNodes;
		}
		
		public function findPath():Array {
			var path:Array = new Array();
			var pathFound:Boolean = false;
			while(numberOfOpenListItems > 0 && !pathFound) {
				var currentNode:Node = openList[1];
				openList[1] = openList[numberOfOpenListItems];
				openList[numberOfOpenListItems] = null;
				numberOfOpenListItems--;
				nodesChecked++;
				closedList[nodesChecked] = currentNode;
				var v:Number = 1;
				var u:Number;
				while(true) {
					u = v;
					if(2*u+1 <= numberOfOpenListItems) {
						if(openList[u].getFValue() >= openList[2*u].getFValue()) {
							v = 2*u;
						}
						if(openList[v].getFValue() >= openList[2*u+1].getFValue()) {
							v = 2*u+1;
						}
					}
					else if(2*u <= numberOfOpenListItems) {
						if(openList[u].getFValue() >= openList[2*u].getFValue()) {
							v = 2*u;
						}
					}
					if(u!=v) {
						var copyNode:Node = openList[u];
						openList[u] = openList[v];
						openList[v] = copyNode;
					}
					else {
						break;
					}
				}
				var adjacentNodes:Array = new Array();
				adjacentNodes = getAdjacentNodes(currentNode.getPosition());
				for(var i:Number = 0; i<adjacentNodes.length; i++) {
					var skipNode:Boolean = false;
					var gValue:Number = currentNode.getGValue();
					var hValue:Number = getHValue(adjacentNodes[i], targetNode);
					var fValue:Number = gValue + hValue;
					for(var i2:Number = 0; i2<openList.length; i2++) {
						if(openList[i2] != null) {
							if(openList[i2].getPosition().equals(adjacentNodes[i2]) && openList[i2].getFValue() < fValue) {
								skipNode = true;
								break;
							}
						}
					}
					for(var i3:Number = 0; i3<closedList.length; i3++) {
						if(openList[i3] != null) {
							if(openList[i3].getPosition().equals(adjacentNodes[i3]) && openList[i3].getFValue() < fValue) {
								skipNode = true;
								break;
							}
						}
					}
					if(!skipNode) {
						var newNode:Node = new Node(adjacentNodes[i], fValue, gValue, hValue, currentNode);
						numberOfOpenListItems++;
						openList[numberOfOpenListItems] = newNode;
						var m:Number = numberOfOpenListItems;
						while(m!=1) {
							if(openList[m].getFValue() <= openList[Math.floor(m/2)].getFValue()) {
								var copyNode:Node = openList[Math.floor(m/2)];
								openList[Math.floor(m/2)] = openList[m];
								openList[m] = copyNode;
								m = Math.floor(m/2);
							}
							else {
								break;
							}
						}
					}
					if(currentNode.getPosition().equals(new Point(targetNode.x, targetNode.y))) {
						pathFound = true;
						break;
					}
				}
			}
			if(pathFound) {
				var lastNode:Node = closedList[nodesChecked];
				var parentNode:Node = lastNode.getParent();
				path.push(parentNode);
				while(parentNode != null) {
					parentNode = parentNode.getParent();
					if(parentNode != null) {
						path.push(parentNode);
					}
				}
			}
			return path;
		}
	}
}
