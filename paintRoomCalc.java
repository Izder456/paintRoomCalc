/*
Name : paintRoomCalc in Java
Author : izder456
Version : v1.0
License : N/A
*/

import java.util.Scanner;
import java.lang.Math; 

class paintRoomCalc {
    static public void getLayers(float roomWidth, float roomDepth, float roomHeight, final float paintThick) {
		float edgeArea, edgeSideDepthArea, edgeSideDepthVol, edgeSideWidthArea, edgeSideWidthVol, edgeUpArea, edgeUpVol,
				edgeVol, roomVol, wallArea, wallFive, wallOne, wallThree, wallVol;
		double i = 0;
		double t = 0;
		roomWidth = roomWidth * 12;
		roomDepth = roomDepth * 12;
		roomHeight = roomHeight * 12;
		roomVol = roomWidth * roomDepth * roomHeight;
		while (roomVol >= 0) {
			// account for walls
			wallOne = (float) (roomWidth * roomHeight);
			wallThree = (float) (roomDepth * roomHeight);
			wallFive = (float) (roomDepth * roomWidth);

			wallVol = (float) (((wallOne * 2) + (wallThree * 2) + wallFive) * paintThick);
			wallArea = (float) ((wallOne * 2) + (wallThree * 2) + wallFive);

			roomWidth = (float) (roomWidth - (paintThick * 2));
			roomDepth = (float) (roomDepth - (paintThick * 2));
			roomHeight = (float) (roomHeight - (paintThick * 2));

			// account for edges going up & down
			edgeUpVol = (float) (roomHeight * Math.pow(paintThick, 2));
			edgeUpVol = (float) (edgeUpVol * 2);
			edgeUpArea = (float) (roomHeight * paintThick);
			edgeUpVol = (float) (edgeUpArea * 2);

			// account for edges going side to side {on ceiling}
			//// account for edges going side to side {depth}
			edgeSideDepthVol = (float) (roomDepth * Math.pow(paintThick, 2));
			edgeSideDepthVol = (float) (edgeSideDepthVol * 2);
			edgeSideDepthArea = (float) (roomDepth * paintThick);
			//// account for edges going side to side {width}
			edgeSideWidthVol = (float) (roomWidth * Math.pow(paintThick, 2));
			edgeSideWidthVol = (float) (edgeSideWidthVol * 2);
			edgeSideWidthArea = (float) (roomWidth * paintThick);

			// add edges
			edgeVol = (float) (edgeUpVol + edgeSideWidthVol + edgeSideDepthVol);
			edgeArea = (float) (edgeUpArea + edgeSideWidthArea + edgeSideDepthArea);

			// calculate final values
			roomVol = (float) (roomVol - wallVol - edgeVol);
			wallArea = (float) (wallArea - edgeArea);

			i += 1;
			t += wallArea;
		}
		System.out.println(i + " layers to fill your room with paint!!");
		System.out.println("& " + t / 4800 + " gallons of paint");
	}

	public static void main(final String[] args) {
		Scanner input = new Scanner(System.in);
		float roomWidth, roomDepth, roomHeight, paintThickMil; 
		float paintThick;
		System.out.println("Paint Layer Calculator");
		System.out.println("by : izder456");
		System.out.println();
		
		//get input for room dimentions
		System.out.print("Room Width in Feet? ");
		roomWidth = input.nextFloat();
		System.out.print("Room Depth in Feet? ");
		roomDepth =  input.nextFloat();
		System.out.print("Room Height in Feet? ");
		roomHeight = input.nextFloat();
		System.out.println();
		System.out.println("1 mil is 1/1000 of an inch");
		System.out.print("Paint Thickness in Mils? ");
		paintThickMil = input.nextFloat();
		paintThick = paintThickMil / 1000;
		System.out.println();
		System.out.println("Calculating...");
		input.close();
		getLayers(roomWidth, roomDepth, roomHeight, paintThick);
	}
}

