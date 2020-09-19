/*
Name : paintRoomCalc in C++
Author : Аїӡек Меѥҏ
Version : b1.0
License : N/A
*/

#include <cmath>
#include <iostream>
using namespace std;

static void getLayers(float roomWidth, float roomDepth, float roomHeight, float paintThick) {
    float edgeArea, edgeSideDepthArea, edgeSideDepthVol, edgeSideWidthArea, edgeSideWidthVol, edgeUpArea, edgeUpVol, edgeVol, roomVol, wallArea, wallFive, wallOne, wallThree, wallVol;
    double i;
    double t;
    i = 0;
    t = 0;
    roomWidth = (roomWidth * 12);
    roomDepth = (roomDepth * 12);
    roomHeight = (roomHeight * 12);
    roomVol = ((roomWidth * roomDepth) * roomHeight);
    while ((roomVol >= 0)) {
        // account for walls
        wallOne = float(roomWidth * roomHeight);
        wallThree = float(roomDepth * roomHeight);
        wallFive = float(roomDepth * roomWidth);

        wallVol = float((((wallOne * 2) + (wallThree * 2)) + wallFive) * paintThick);
        wallArea = float(((wallOne * 2) + (wallThree * 2)) + wallFive);

        roomWidth = float(roomWidth - (paintThick * 2));
        roomDepth = float(roomDepth - (paintThick * 2));
        roomHeight = float(roomHeight - (paintThick * 2));

        // account for edges going up & down
        edgeUpVol = float(roomHeight * pow(paintThick, 2));
        edgeUpVol = float(edgeUpVol * 2);
        edgeUpArea = float(roomHeight * paintThick);
        edgeUpVol = float(edgeUpArea * 2);

        // account for edges going side to side {on ceiling}
        //// account for edges going side to side {depth}
        edgeSideDepthVol = float(roomDepth * pow(paintThick, 2));
        edgeSideDepthVol = float(edgeSideDepthVol * 2);
        edgeSideDepthArea = float(roomDepth * paintThick);
        //// account for edges going side to side {width}
        edgeSideWidthVol = float(roomWidth * pow(paintThick, 2));
        edgeSideWidthVol = float(edgeSideWidthVol * 2);
        edgeSideWidthArea = float(roomWidth * paintThick);
        edgeVol = float((edgeUpVol + edgeSideWidthVol) + edgeSideDepthVol);

        // add edges
        edgeArea = float((edgeUpArea + edgeSideWidthArea) + edgeSideDepthArea);

        // calculate final values
        roomVol = float((roomVol - wallVol) - edgeVol);
        wallArea = float(wallArea - edgeArea);

        i += 1;
        t += wallArea;
    }
    cout << i << " layers to fill your room with paint!!" << endl;
    cout << "& " << t / 4800 << " gallons of paint" << endl;
}
int main() {
    float roomWidth, roomDepth, roomHeight, paintThickMil;
    float paintThick;
    cout << "Paint Layer Calculator" << endl;
    cout << "by : izder456" << endl;
    cout << "" << endl;

    //get input for room dimentions
    cout << "Room Width in Feet? ";
    cin >> roomWidth;
    cout << "Room Depth in Feet? ";
    cin >> roomDepth;
    cout << "Room Height in Feet? ";
    cin >> roomHeight;
    cout << endl;
    cout << "1 mil is 1/1000 of an inch" << endl;
    cout << "Paint Thickness in Mils? ";
    cin >> paintThickMil;
    paintThick = paintThickMil / 1000;
    cout << endl;
    cout << "Calculating..." << endl;

    getLayers(roomWidth, roomDepth, roomHeight, paintThick);
    cin.get();

    return 0;
}

