'''''''''''''''''''''''''''''''''''''''
''Name : paintRoomCalc in Visual Basic
''Author : Аїӡек Меѥҏ
''Version : v1.0
''License : N/A
'''''''''''''''''''''''''''''''''''''''

Imports System

Module Program
	Function getLayers(ByVal roomWidth As Decimal, ByVal roomDepth As Decimal, ByVal roomHeight As Decimal, ByVal paintThick As Decimal) As Double()
		Dim i = 0
		Dim t = 0.0
		roomWidth = roomWidth * 12
		roomDepth = roomDepth * 12
		roomHeight = roomHeight * 12
		Dim edgeArea As Decimal = 0.0
		Dim edgeSideDepthArea As Decimal = 0.0
		Dim edgeSideDepthVol As Decimal = 0.0
		Dim edgeSideWidthArea As Decimal = 0.0
		Dim edgeSideWidthVol As Decimal = 0.0
		Dim edgeUpArea As Decimal = 0.0
		Dim edgeUpVol As Decimal = 0.0
		Dim edgeVol As Decimal = 0.0
		Dim wallArea As Decimal = 0.0
		Dim wallFive As Decimal = 0.0
		Dim wallOne As Decimal = 0.0
		Dim wallThree As Decimal = 0.0
		Dim wallVol As Decimal = 0.0
		Dim roomVol As Decimal = roomWidth * roomDepth * roomHeight
		While (roomVol >= 0)
			' account for walls
			wallOne = (roomWidth * roomHeight)
			wallThree = (roomDepth * roomHeight)
			wallFive = (roomDepth * roomWidth)

			wallVol = (((wallOne * 2) + (wallThree * 2) + wallFive) * paintThick)
			wallArea = ((wallOne * 2) + (wallThree * 2) + wallFive)

			roomWidth = (roomWidth - (paintThick * 2))
			roomDepth = (roomDepth - (paintThick * 2))
			roomHeight = (roomHeight - (paintThick * 2))

			' account for edges going up & down
			edgeUpVol = (roomHeight * Math.Pow(paintThick, 2))
			edgeUpVol = (edgeUpVol * 2)
			edgeUpArea = (roomHeight * paintThick)
			edgeUpVol = (edgeUpArea * 2)

			' account for edges going side to side {on ceiling}
			'' account for edges going side to side {depth}
			edgeSideDepthVol = (roomDepth * Math.Pow(paintThick, 2))
			edgeSideDepthVol = (edgeSideDepthVol * 2)
			edgeSideDepthArea = (roomDepth * paintThick)
			'' account for edges going side to side {width}
			edgeSideWidthVol = (roomWidth * Math.Pow(paintThick, 2))
			edgeSideWidthVol = (edgeSideWidthVol * 2)
			edgeSideWidthArea = (roomWidth * paintThick)

			' add edges
			edgeVol = (edgeUpVol + edgeSideWidthVol + edgeSideDepthVol)
			edgeArea = (edgeUpArea + edgeSideWidthArea + edgeSideDepthArea)

			' calculate final values
			roomVol = (roomVol - wallVol - edgeVol)
			wallArea = (wallArea - edgeArea)

			i += 1
			t += wallArea
		End While
		Return {i, t}
	End Function
	Sub Main(args As String())
		Console.WriteLine("Paint Layer Calculator")
		Console.WriteLine("by : izder456")
		Console.WriteLine()

		' get input for room dimentions
		Console.Write("Room Width in Feet? ")
		Dim roomWidth As Decimal = Console.ReadLine()
		Console.Write("Room Depth in Feet? ")
		Dim roomDepth As Decimal = Console.ReadLine()
		Console.Write("Room Height in Feet? ")
		Dim roomHeight As Decimal = Console.ReadLine()
		Console.WriteLine()
		Console.WriteLine("1 mil is 1/1000 of an inch")
		Console.Write("Paint Thickness in Mils? ")
		Dim paintThickMil As Decimal = Console.ReadLine()
		Dim paintThick As Decimal = paintThickMil / 1000
		Console.WriteLine()
		Console.WriteLine("Calculating...")

		Dim answer = getLayers(roomWidth, roomDepth, roomHeight, paintThick)
		Console.WriteLine((answer(0).ToString) + " layers to fill your room with paint!!")
		Console.Write("& ")
		Console.Write(answer(1).ToString / 4800.0)
		Console.Write(" gallons of paint")
		Console.WriteLine()
	End Sub
End Module
