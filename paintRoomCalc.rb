=begin
Name : paintRoomCalc in Ruby
Author : Аїӡек Меѥҏ
Version : v1.0
License : N/A
=end

def getLayers(roomWidth, roomDepth, roomHeight, paintThick)
  i = 0
  t = 0
  roomWidth = roomWidth * 12
  roomDepth = roomDepth * 12
  roomHeight = roomHeight * 12
  roomVol = roomWidth * roomDepth * roomHeight
  while roomVol >= 0 do
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
  end
  puts i.to_s + " layers to fill your room with paint!!"
  puts "& " + (t / (4800)).to_s + " gallons of paint"
end


puts "Paint Layer Calculator"
puts "by : Аїӡек Меѥҏ"

print "Room Width in Feet? "
roomWidth = gets.chomp
roomWidth = roomWidth.to_i
print "Room Depth in Feet? "
roomDepth = gets.chomp
roomDepth = roomDepth.to_i
print "Room Height in Feet? "
roomHeight = gets.chomp
roomHeight = roomHeight.to_i
puts "1 mil is 1/1000 of an inch"
print "Paint Thickness in Mils? "
paintThickMil = gets.chomp
paintThickMil = paintThickMil.to_i
paintThick = paintThickMil / 1000
puts ""
puts "Calculating..."
getLayers(roomWidth, roomDepth, roomHeight, paintThick)

