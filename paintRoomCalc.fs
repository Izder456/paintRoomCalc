(*
Name : paintRoomCalc in F#
Author : Аїӡек Меѥҏ
Version : v1.0
License : N/A
*)

open System;

let getLayers (rW:float) (rD:float) (rH:float) (pT:float) : float list = 
    let paintThick = pT;
    let mutable i = 0;
    let mutable t = 0.0;
    let mutable roomWidth:float = (float rW)*12.0;
    let mutable roomDepth:float = (float rD)*12.0;
    let mutable roomHeight:float = (float rH)*12.0;
    let mutable edgeArea:float = 0.0;
    let mutable edgeSideDepthArea:float = 0.0;
    let mutable edgeSideDepthVol:float = 0.0;
    let mutable edgeSideWidthArea:float = 0.0;
    let mutable edgeSideWidthVol:float = 0.0;
    let mutable edgeUpArea:float = 0.0;
    let mutable edgeUpVol:float = 0.0; 
    let mutable edgeVol:float = 0.0;
    let mutable roomVol:float = 0.0;
    let mutable wallArea:float = 0.0;
    let mutable wallFive:float = 0.0; 
    let mutable wallOne:float = 0.0;
    let mutable wallThree:float = 0.0;
    let mutable wallVol:float = 0.0;
    let mutable roomVol:float = (float roomWidth) * (float roomDepth) * (float roomHeight);
    while (float roomVol) >= 0.0 do
        // account for walls
        wallOne <- (float roomWidth) * (float roomHeight);
        wallThree <- (float roomDepth) * (float roomHeight);
        wallFive <- (float roomDepth) * (float roomWidth);

        wallVol <- (((float wallOne) * 2.0) + ((float wallThree) * 2.0) + (float wallFive)) * (float paintThick);
        wallArea <- (((float wallOne) * 2.0) + ((float wallThree) * 2.0) + (float wallFive));

        roomWidth <- ((float roomWidth) - ((float paintThick) * 2.0));
        roomDepth <- ((float roomDepth) - ((float paintThick) * 2.0));
        roomHeight <- ((float roomHeight) - ((float paintThick) * 2.0));

        // account for edges going up & down
        edgeUpVol <- ((float roomHeight) * Math.Pow((float paintThick), 2.0));
        edgeUpVol <- ((float edgeUpVol) * 2.0);
        edgeUpArea <- ((float roomHeight) * (float paintThick));
        edgeUpVol <- ((float edgeUpArea) * 2.0);

        // account for edges going side to side {on ceiling}
        //// account for edges going side to side {depth}
        edgeSideDepthVol <- ((float roomDepth) * Math.Pow((float paintThick), 2.0));
        edgeSideDepthVol <- ((float edgeSideDepthVol) * 2.0);
        edgeSideDepthArea <- ((float roomDepth) * (float paintThick));
        //// account for edges going side to side {width}
        edgeSideWidthVol <- ((float roomWidth) * Math.Pow((float paintThick), 2.0));
        edgeSideWidthVol <- ((float edgeSideWidthVol) * 2.0);
        edgeSideWidthArea <- ((float roomWidth) * (float paintThick));

        // add edges
        edgeVol <- ((float edgeUpVol) + (float edgeSideWidthVol) + (float edgeSideDepthVol));
        edgeArea <- ((float edgeUpArea) + (float edgeSideWidthArea) + (float edgeSideDepthArea));

        // calculate final values
        roomVol <- ((float roomVol) - (float wallVol) - (float edgeVol));
        wallArea <- ((float wallArea) - (float edgeArea));

        i <- i + 1;
        t <- (float wallArea) + (float t);
    [float i; t];

    

Console.WriteLine("Paint Layer Calculator");
Console.WriteLine("by : izder456");
Console.WriteLine();

//get input for room dimentions
Console.Write("Room Width in Feet? ");
let roomWidthI:float = float(Console.ReadLine());
Console.Write("Room Depth in Feet? ");
let roomDepthI:float = float(Console.ReadLine());
Console.Write("Room Height in Feet? ");
let roomHeightI:float = float(Console.ReadLine());
Console.WriteLine();
Console.WriteLine("1 mil is 1/1000 of an inch");
Console.Write("Paint Thickness in Mils? ");
let mutable paintThickI:float = float(Console.ReadLine());
paintThickI <- float(paintThickI / 1000.0);
Console.WriteLine();
Console.WriteLine("Calculating...");

let answer = getLayers roomWidthI roomDepthI roomHeightI paintThickI;
Console.WriteLine((string answer.[0]) + " layers to fill your room with paint!!");
Console.WriteLine("& " + (string (answer.[1] / 4800.0)) + " gallons of paint");
