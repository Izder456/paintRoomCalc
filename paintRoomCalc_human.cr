##################################
# Name : paintRoomCalc in crystal
# Author : izder456
# Version : n1.0
# License : WTFPL
#################################

# Prompt user for input and return the response as a string
def prompt_user(message : String) : String
  puts message
  read_line 
end

# Calculate the volume taken by one layer of paint on each wall
# (accounting for the one lost edge of volume, assuming each wall is painted in a clockwise order)
def calculate_wall_vol(height : Float64, width : Float64, layer_thickness : Float64) : Float64
  wall_area = height * width - height * layer_thickness
  wall_area * layer_thickness
end

# Calculate the volume taken by one layer of paint on the ceiling
# (accounting for the four lost edges of volume)
def calculate_ceil_vol(length : Float64, width : Float64, layer_thickness : Float64) : Float64
  ceil_area = length * width - (2 * (length * layer_thickness) + 2 * (width * layer_thickness)) - (layer_thickness ** 2)
  ceil_area * layer_thickness
end

# Calculate the number of layers needed to fill the room with paint
def calculate_num_layers(width : Float64, depth : Float64, height : Float64, layer_thickness : Float64) : Int32
  room_volume = width * depth * height
  num_layer = 0
  curr_width, curr_depth, curr_height = width, depth, height
  curr_room_volume = room_volume

  # Iterate layers of paint until volume is zero or negative
  until curr_room_volume <= 0
    wall_vol_NS = calculate_wall_vol(curr_width, height, layer_thickness)
    wall_vol_EW = calculate_wall_vol(curr_depth, height, layer_thickness)
    wall_vol_Tot = wall_vol_NS + wall_vol_EW
    ceil_vol_Tot = calculate_ceil_vol(curr_depth, curr_height, layer_thickness)
    vol_Tot = ceil_vol_Tot + wall_vol_Tot
    curr_room_volume -= vol_Tot
    curr_width -= layer_thickness * 2
    curr_depth -= layer_thickness * 2
    curr_height -= layer_thickness
    num_layer += 1
  end
  num_layer
end

# Prompt user for the room dimensions and layer thickness, and convert the input to floats
width = prompt_user("Enter the width of the room (in feet):").to_f
depth = prompt_user("Enter the depth of the room (in feet):").to_f
height = prompt_user("Enter the height of the room (in feet):").to_f
layer_thickness = prompt_user("Enter the thickness of each layer (in mils):").to_f / 12.0 / 1000.0

# Calculate the number of layers needed to fill the room
num_layers = calculate_num_layers(width, depth, height, layer_thickness)

# Print the result to the console
puts "To completely fill a room with dimensions #{width} x #{depth} x #{height} feet using dried layers of paint, you would need #{num_layers} layers."