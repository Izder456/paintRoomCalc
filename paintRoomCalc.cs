/*
Name : paintRoomCalc in C#
Author : Аїӡек Меѥҏ
Version : v1.0
License : N/A
*/


using System;
class MainClass {
    static public void getLayers(float roomWidth, float roomDepth, float roomHeight, float paintThick) {
		float edgeArea, edgeSideDepthArea, edgeSideDepthVol, edgeSideWidthArea, edgeSideWidthVol, edgeUpArea, edgeUpVol, edgeVol, roomVol, wallArea, wallFive, wallOne, wallThree, wallVol;
		double i = 0;
		double t = 0;
		roomWidth = roomWidth * 12;
		roomDepth = roomDepth * 12;
		roomHeight = roomHeight * 12;
		roomVol = roomWidth * roomDepth * roomHeight;
		while ( roomVol >= 0 ) {
			// account for walls
			wallOne = (float)( roomWidth * roomHeight );
			wallThree = (float)( roomDepth * roomHeight );
			wallFive = (float)( roomDepth * roomWidth );
			
			wallVol = (float)( ( ( wallOne * 2 ) + ( wallThree * 2 ) + wallFive ) * paintThick );
			wallArea = (float)( ( wallOne * 2 ) + ( wallThree * 2 ) + wallFive );
			
			roomWidth = (float)( roomWidth - ( paintThick * 2 ) );
			roomDepth = (float)(roomDepth - ( paintThick * 2 ));
			roomHeight = (float)(roomHeight - ( paintThick * 2 ));
			
			// account for edges going up & down
			edgeUpVol = (float)( roomHeight * Math.Pow(paintThick, 2) );
		    edgeUpVol = (float)( edgeUpVol * 2 );
			edgeUpArea = (float)( roomHeight * paintThick );
			edgeUpVol = (float)( edgeUpArea * 2 );
			
			// account for edges going side to side {on ceiling}
			//// account for edges going side to side {depth}
			edgeSideDepthVol = (float)( roomDepth * Math.Pow(paintThick, 2) );
			edgeSideDepthVol = (float)( edgeSideDepthVol * 2 );
			edgeSideDepthArea = (float)( roomDepth * paintThick );
			//// account for edges going side to side {width}
			edgeSideWidthVol = (float)( roomWidth * Math.Pow(paintThick, 2) );
			edgeSideWidthVol = (float)( edgeSideWidthVol * 2 );
			edgeSideWidthArea = (float)( roomWidth * paintThick );
			
			// add edges
			edgeVol = (float)( edgeUpVol + edgeSideWidthVol + edgeSideDepthVol );
			edgeArea = (float)( edgeUpArea + edgeSideWidthArea + edgeSideDepthArea );
			
			// calculate final values
			roomVol = (float)( roomVol - wallVol - edgeVol );
			wallArea = (float)( wallArea - edgeArea );
			
			i += 1;
			t += wallArea;
		}
		Console.WriteLine(i + " layers to fill your room with paint!!");
		Console.WriteLine("& " + t / 4800 + " gallons of paint");
	}
	static public void Main(string[] args) {
		float roomWidth, roomDepth, roomHeight, paintThickMil; 
		float paintThick;
		Console.WriteLine("Paint Layer Calculator");
		Console.WriteLine("by : Аїӡек Меѥҏ");
		Console.WriteLine();
		
		//get input for room dimentions
		Console.Write("Room Width in Feet? ");
		roomWidth = float.Parse(Console.ReadLine());
		Console.Write("Room Depth in Feet? ");
		roomDepth = float.Parse(Console.ReadLine());
		Console.Write("Room Height in Feet? ");
		roomHeight = float.Parse(Console.ReadLine());
		Console.WriteLine();
		Console.WriteLine("1 mil is 1/1000 of an inch");
		Console.Write("Paint Thickness in Mils? ");
		paintThickMil = float.Parse(Console.ReadLine());
		paintThick = paintThickMil / 1000;
		Console.WriteLine();
		Console.WriteLine("Calculating...");

		getLayers(roomWidth, roomDepth, roomHeight, paintThick);
		Console.ReadKey();
	}
}

