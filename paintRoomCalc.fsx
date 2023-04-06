(*
Name : paintRoomCalc in F#
Author : izder456
Version : n1.0
License : WTFPL
*)

// Open System I/O
open System

// Define a function to prompt the user for input and return their response
let promptUser message =
    printfn "%s" message
    Console.ReadLine()

// Define a function to calculate the number of layers needed to fill the room
let calculateNumLayers width depth height layerThickness =
    // Calculate the volume of the room (disregarding the floor)
    let volume = width * depth * (height - layerThickness)
    // Round up to the nearest integer to get the number of layers needed
    ceil(volume / layerThickness) 

// Prompt the user for the room dimensions and layer thickness, and convert the input to floats
let width = promptUser "Enter the width of the room (in feet):" |> float
let depth = promptUser "Enter the depth of the room (in feet):" |> float
let height = promptUser "Enter the height of the room (in feet):" |> float
let layerThickness = (promptUser "Enter the thickness of each layer (in mils):" |> float) / 12000.0

// Calculate the number of layers needed to fill the room
let numLayers = calculateNumLayers width depth height layerThickness
// Print the result to the console
printfn "To completely fill a room with dimensions %.2f x %.2f x %.2f feet using %f-foot-thick layers of paint, you would need %.0f layers." width depth height layerThickness numLayers
