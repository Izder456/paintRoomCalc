/*
Name : paintRoomCalc in node.js
Author : Аїӡек Меѥҏ
Version : v1.0
License : N/A
*/

const prompt = require('prompt-sync')();
const colors = require('colors');

function getLayers(roomWidth, roomDepth, roomHeight, paintThick) {
  var edgeArea, edgeSideDepthArea, edgeSideDepthVol, edgeSideWidthArea, edgeSideWidthVol, edgeUpArea, edgeUpVol, edgeVol, i, roomVol, t, wallArea, wallFive, wallOne, wallThree, wallVol;
  i = 0;
  t = 0;
  roomWidth = (roomWidth * 12);
  roomDepth = (roomDepth * 12);
  roomHeight = (roomHeight * 12);
  roomVol = ((roomWidth * roomDepth) * roomHeight);
  while ((roomVol >= 0)) {
	// account for walls
    wallOne = (roomWidth * roomHeight);
    wallThree = (roomDepth * roomHeight);
    wallFive = (roomDepth * roomWidth);
	
    wallVol = ((((wallOne * 2) + (wallThree * 2)) + wallFive) * paintThick);
    wallArea = (((wallOne * 2) + (wallThree * 2)) + wallFive);
	
    roomWidth = (roomWidth - (paintThick * 2));
    roomDepth = (roomDepth - (paintThick * 2));
    roomHeight = (roomHeight - (paintThick * 2));
	
	// account for edges going up & down
    edgeUpVol = (roomHeight * Math.pow(paintThick, 2));
    edgeUpVol = (edgeUpVol * 2);
    edgeUpArea = (roomHeight * paintThick);
    edgeUpVol = (edgeUpArea * 2);
	
	// account for edges going side to side {on ceiling}
	//// account for edges going side to side {depth}
    edgeSideDepthVol = (roomDepth * Math.pow(paintThick, 2));
    edgeSideDepthVol = (edgeSideDepthVol * 2);
    edgeSideDepthArea = (roomDepth * paintThick);
	//// account for edges going side to side {width}
    edgeSideWidthVol = (roomWidth * Math.pow(paintThick, 2));
    edgeSideWidthVol = (edgeSideWidthVol * 2);
    edgeSideWidthArea = (roomWidth * paintThick);
	
	// add edges
    edgeVol = ((edgeUpVol + edgeSideWidthVol) + edgeSideDepthVol);
    edgeArea = ((edgeUpArea + edgeSideWidthArea) + edgeSideDepthArea);
    
	// calculate final values
	roomVol = ((roomVol - wallVol) - edgeVol);
    wallArea = (wallArea - edgeArea);
	
    i += 1;
    t += wallArea;
  }
  console.log(colors.magenta(i.toString() + " layers to fill your room with paint!!"));
  console.log(colors.magenta(("& " + (t / 4800).toString()) + " gallons of paint"));
}
console.log(colors.bgBlack.green("Paint Layer Calculator"));
console.log(colors.bgBlack.green("by : Аїӡек Меѥҏ"));
console.log("\n")
let roomWidth = prompt(colors.blue("Room Width in Feet? "));
roomWidth = Number(roomWidth);
let roomDepth = prompt(colors.blue("Room Depth in Feet? "));
roomDepth = Number(roomDepth);
let roomHeight = prompt(colors.blue("Room Height in Feet? "));
roomHeight = Number(roomHeight);
console.log("\n");
console.log(colors.red("1 mil is 1/1000 of an inch"));
let paintThickMil = prompt(colors.blue("Paint Thickness in Mils? "));
paintThickMil = Number(paintThickMil);
paintThick = (paintThickMil / 1000);
console.log("\n");
console.log(colors.bgBlack.green("Calculating..."));
getLayers(roomWidth, roomDepth, roomHeight, paintThick);
