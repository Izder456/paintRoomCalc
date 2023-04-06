# Define a function to prompt the user for input and return their response
def prompt_user(message)
  puts message
  read_line 
end

# Define a function to calculate the number of layers needed to fill the room
def calculate_num_layers(width, depth, height, layer_thickness)
  # Calculate the volume of the room (disregarding the floor)
  volume = width * depth * (height - layer_thickness)
  # Round up to the nearest integer to get the number of layers needed
  (volume / layer_thickness).ceil
end

# Prompt the user for the room dimensions and layer thickness, and convert the input to floats
width = prompt_user("Enter the width of the room (in feet):").to_f
depth = prompt_user("Enter the depth of the room (in feet):").to_f
height = prompt_user("Enter the height of the room (in feet):").to_f
layer_thickness = prompt_user("Enter the thickness of each layer (in mils):").to_f / 12000.0

# Calculate the number of layers needed to fill the room
num_layers = calculate_num_layers(width, depth, height, layer_thickness)

layer_thickness_R = (layer_thickness * 1000.0).format(decimal_places: 2)

# Print the result to the console
puts "To completeliy fill a room with dimensions #{width} x #{depth} x #{height} feet using ~#{layer_thickness_R}-inch-thick layers of paint, you would need #{num_layers} layers."
