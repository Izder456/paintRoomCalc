'''
Name : paintRoomCalc in Python 3.8
Author : Аїӡек Меѥҏ
Version : v1.0
License : N/A
'''

def getLayers(roomWidth, roomDepth, roomHeight, paintThick):
    i = 0
    t = 0
    roomWidth = roomWidth * 12
    roomDepth = roomDepth * 12
    roomHeight = roomHeight * 12
    roomVol = roomWidth * roomDepth * roomHeight
    while roomVol >= 0:
        #account for walls
        wallOne = roomWidth * roomHeight
        #print("wallWidth : "+str(wallOne))
        wallThree = roomDepth * roomHeight
        #print("wallDepth : "+str(wallThree))
        wallFive = roomDepth * roomWidth
        #print("wallCeil : "+str(wallFive))

        wallVol = (wallOne * 2 + wallThree * 2 + wallFive) * paintThick
        wallArea = wallOne * 2 + wallThree * 2 + wallFive

        roomWidth = roomWidth - (paintThick * 2)
        roomDepth = roomDepth - (paintThick * 2)
        roomHeight = roomHeight - (paintThick * 2)

        #account for edges going up & down
        edgeUpVol = roomHeight*paintThick**2
        edgeUpVol = edgeUpVol*2
        edgeUpArea = roomHeight*paintThick
        edgeUpVol = edgeUpArea*2

        #account for edges going side to side {on ceiling}
        ##account for edges going side to side {depth}
        edgeSideDepthVol = (roomDepth*paintThick**2)
        edgeSideDepthVol = edgeSideDepthVol*2
        edgeSideDepthArea = (roomDepth*paintThick)
        ##account for edges going side to side {width}
        edgeSideWidthVol = roomWidth*paintThick**2
        edgeSideWidthVol = edgeSideWidthVol*2
        edgeSideWidthArea = roomWidth*paintThick
        
        #add edges
        edgeVol = edgeUpVol+edgeSideWidthVol+edgeSideDepthVol
        edgeArea = edgeUpArea+edgeSideWidthArea+edgeSideDepthArea

        #calculate final values
        roomVol = roomVol - wallVol - edgeVol
        wallArea = wallArea - edgeArea

        i += 1
        t += wallArea
    print(str(i) +
          " layers to fill your room with paint!!")
    print("& " + str(t / (4800)) + " gallons of paint")

print(Fore.LIGHTGREEN_EX + Back.BLACK + "Paint Layer Calculator")
print("by : Аїӡек Меѥҏ")
print(Style.RESET_ALL)
roomWidth = input(Fore.BLUE + "Room Width in Feet? ")
roomWidth = int(roomWidth)
roomDepth = input("Room Depth in Feet? ")
roomDepth = int(roomDepth)
roomHeight = input("Room Height in Feet? ")
roomHeight = int(roomHeight)

print("\n")
print("1 mil is 1/1000 of an inch")
paintThickMil = input("Paint Thickness in Mils? ")
paintThickMil = int(paintThickMil)
paintThick = paintThickMil / 1000
print("\n")
print("Calculating...")
getLayers(roomWidth, roomDepth, roomHeight, paintThick)
