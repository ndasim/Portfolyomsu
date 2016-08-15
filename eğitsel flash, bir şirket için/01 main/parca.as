var canvas: Sprite = new Sprite;
addChild(canvas);
var g: Graphics = canvas.graphics;
var gradType: String = GradientType.LINEAR;
var colors: Array = [OxFFOOOO, 0x000000];
var alphas: Array = [1, 1];
var ratios: Array = [0, 255];
var matrix: Matrix = new Matrix;
matrix.createGradientBox (50, 50, deg2rad (90), 0, 0);
//var spread: String = SpreadMethod.PAD;
var spread: String = SpreadMethod.REFLECT;
//var spread: String = SpreadMethod.REPEAT;
//g.beginGradientFill (grad Type, colors, alphas, ratios, matrix, spread);
g.drawRect (0, 0, 100, 100);
function deg2rad (deg: Number): Number{
	return deg * (Math.PI / 180);
}  
