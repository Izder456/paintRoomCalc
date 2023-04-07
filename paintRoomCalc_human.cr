##################################
# Name : paintRoomCalc in crystal
# Author : izder456
# Version : n1.0
# License : WTFPL
#################################

# Define a function to prompt the user for input and return their response
def prompt_user(message)
    puts message
    read_line 
end

# Define a function to calculate the volume taken by one layer of paint on each wall
# (accounting for the one lost edge of volume, assuming each wall is painted in a clockwise order)
def calculate_wall_vol(wall_h, wall_w, layer_thickness)
    # Calculate paintable face area 
    wall_area = wall_h * wall_w
    # Account for lost paintable face area
    wall_area -= wall_h * layer_thickness
    # Calculate painted wall volume
    wall_volume = wall_area * layer_thickness
end

# Define a function to calculate the volume taken by one layer of paint on the ceiling
# (accounting for the four lost edges of volume)
def calculate_ceil_vol(ceil_l, ceil_w, layer_thickness)
    # Calculate paintable face area 
    ceil_area = ceil_l * ceil_w
    # Account for lost paintable face area
    ceil_area -= (2. * (ceil_l * layer_thickness) + 2. * (ceil_w * layer_thickness)) - (layer_thickness ** 2)
    # Calculate painted wall volume
    ceil_volume = ceil_area * layer_thickness
end

# Define a function to calculate the number of layers needed to fill the room
def calculate_num_layers(width, depth, height, layer_thickness)
    # Calculate total volume of the room
    room_volume = width * depth * height
    # Set num_layer to zero
    num_layer = 0
    # Set current paintable dimensions
    curr_width = width
    curr_depth = depth
    curr_height = height
    curr_room_volume = room_volume
    # Iterate layers of paint until volume is zero or negative
    until curr_room_volume <= 0
        # Calculate volume taken by walls
        wall_vol_NS = calculate_wall_vol(curr_width, height, layer_thickness)
        wall_vol_EW = calculate_wall_vol(curr_depth, height, layer_thickness)
        wall_vol_Tot = wall_vol_NS + wall_vol_EW
        # Calculate volume taken by ceiling
        ceil_vol_Tot = calculate_ceil_vol(curr_depth, curr_height, layer_thickness)
        # Add volume taken by walls and ceiling & remove from current room volume
        vol_Tot = ceil_vol_Tot + wall_vol_Tot
        curr_room_volume -= vol_Tot
        # Account for lost paintable area
        curr_width -= layer_thickness * 2
        curr_depth -= layer_thickness * 2
        curr_height -= layer_thickness
        # Add 1 to iterable variable num_layer
        num_layer += 1
    end
    num_layer
end

# Prompt the user for the room dimensions and layer thickness, and convert the input to floats
width = prompt_user("Enter the width of the room (in feet):").to_f
depth = prompt_user("Enter the depth of the room (in feet):").to_f
height = prompt_user("Enter the height of the room (in feet):").to_f
layer_thickness = prompt_user("Enter the thickness of each layer (in mils):").to_f / 12.0 / 1000.0

# Calculate the number of layers needed to fill the room
num_layers = calculate_num_layers(width, depth, height, layer_thickness)

# Print the result to the console
puts "To completeliy fill a room with dimensions #{width} x #{depth} x #{height} feet using ~#{layer_thickness}-inch-thick layers of paint, you would need #{num_layers} layers."
