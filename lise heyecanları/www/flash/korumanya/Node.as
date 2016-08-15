package  {
	
	import flash.geom.Point;
	
	class Node {
		
		private var pos:Point;
		private var fValue:Number;
		private var gValue:Number;
		private var hValue:Number;
		private var parent:Node;
		
		function Node(pos:Point, fValue:Number, gValue:Number, hValue:Number, parent:Node) {
			this.pos = pos;
			this.fValue = fValue;
			this.gValue = gValue;
			this.hValue = hValue;
			if(parent != undefined) {
				this.parent = parent;
			}
		}
		
		function getFValue():Number {
			return this.fValue;
		}
		
		function getGValue():Number {
			return this.gValue;
		}
		
		function getPosition():Point {
			return this.pos;
		}
		
		function getParent():Node {
			return this.parent;
		}
		
		function toString():String {
			return "[" + this.pos.toString() + "], f=" + this.fValue + ", g=" + this.gValue + ", h=" + this.hValue;
		}
	}
}
