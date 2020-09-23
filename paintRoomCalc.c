/*
Name : paintRoomCalc in C
Author : Аїӡек Меѥҏ
Version : v1.0
License : N/A
*/

#include <stdio.h>
#include <math.h>

void getLayers(float roomWidth, float roomDepth, float roomHeight, float paintThick) {
    float edgeArea, edgeSideDepthArea, edgeSideDepthVol, edgeSideWidthArea, edgeSideWidthVol, edgeUpArea, edgeUpVol, edgeVol, roomVol, wallArea, wallFive, wallOne, wallThree, wallVol;
    double i;
    double t;
    i = 0;
    t = 0;
    roomWidth = (roomWidth * 12);
    roomDepth = (roomDepth * 12);
    roomHeight = (roomHeight * 12);
    roomVol = ((roomWidth * roomDepth) * roomHeight);
    while (roomVol >= 0) {
        // account for walls
        wallOne = (float)(roomWidth * roomHeight);
        wallThree = (float)(roomDepth * roomHeight);
        wallFive = (float)(roomDepth * roomWidth);

        wallVol = (float)((((wallOne * 2) + (wallThree * 2)) + wallFive) * paintThick);
        wallArea = (float)(((wallOne * 2) + (wallThree * 2)) + wallFive);

        roomWidth = (float)(roomWidth - (paintThick * 2));
        roomDepth = (float)(roomDepth - (paintThick * 2));
        roomHeight = (float)(roomHeight - (paintThick * 2));

        // account for edges going up & down
        edgeUpVol = (float)(roomHeight * pow(paintThick, 2));
        edgeUpVol = (float)(edgeUpVol * 2);
        edgeUpArea = (float)(roomHeight * paintThick);
        edgeUpVol = (float)(edgeUpArea * 2);

        // account for edges going side to side {on ceiling}
        //// account for edges going side to side {depth}
        edgeSideDepthVol = (float)(roomDepth * pow(paintThick, 2));
        edgeSideDepthVol = (float)(edgeSideDepthVol * 2);
        edgeSideDepthArea = (float)(roomDepth * paintThick);
        //// account for edges going side to side {width}
        edgeSideWidthVol = (float)(roomWidth * pow(paintThick, 2));
        edgeSideWidthVol = (float)(edgeSideWidthVol * 2);
        edgeSideWidthArea = (float)(roomWidth * paintThick);
        edgeVol = (float)((edgeUpVol + edgeSideWidthVol) + edgeSideDepthVol);

        // add edges
        edgeArea = (float)((edgeUpArea + edgeSideWidthArea) + edgeSideDepthArea);

        // calculate final values
        roomVol = (float)((roomVol - wallVol) - edgeVol);
        wallArea = (float)(wallArea - edgeArea);

        i += 1;
        t += wallArea;
    }
    printf("%f layers to fill your room with paint!!\n",i);
    printf("& %f gallons of paint\n",((float)t/(float)4800));
};

int main() {
    float roomWidth, roomDepth, roomHeight, paintThickMil;
    float paintThick;
    printf("Paint Layer Calculator\n");
    printf("by : izder456\n");
    printf("\n");

    //get input for room dimentions
    printf("Room Width in Feet? ");
    scanf("%f", &roomWidth);
    printf("Room Depth in Feet? ");
    scanf("%f", &roomDepth);
    printf("Room Height in Feet? ");
    scanf("%f", &roomHeight);
    printf("1 mil is 1/1000 of an inch\n");
    printf("Paint Thickness in Mils? ");
    scanf("%f", &paintThickMil);
    paintThick = ((float)(paintThickMil))/((float)(1000));
    printf("\n");
    printf("Calculating...\n");

    getLayers(roomWidth, roomDepth, roomHeight, paintThick);
    while(!getchar());

    return 0;
};
