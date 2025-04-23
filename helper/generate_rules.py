import os
import json
from PIL import Image

TILE_FOLDER = "Mountains"  # folder with PNG tiles
OUTPUT_FILEPATH = "Mountains/generated_rules_rotated_color.json"

def get_edge_colors(image):
    w, h = image.size
    pixels = image.load()

    return {
        "Up": pixels[w // 2, 0],
        "Down": pixels[w // 2, h - 1],
        "Left": pixels[0, h // 2],
        "Right": pixels[w - 1, h // 2],
    }

def rotate_connections(conns, rotation):
    if rotation == 90:
        return {
            "Up": conns["Left"],
            "Right": conns["Up"],
            "Down": conns["Right"],
            "Left": conns["Down"]
        }
    elif rotation == 180:
        return {
            "Up": conns["Down"],
            "Right": conns["Left"],
            "Down": conns["Up"],
            "Left": conns["Right"]
        }
    elif rotation == 270:
        return {
            "Up": conns["Right"],
            "Right": conns["Down"],
            "Down": conns["Left"],
            "Left": conns["Up"]
        }
    return conns

def load_tile_edges_with_rotations():
    tiles = {}

    for filename in os.listdir(TILE_FOLDER):
        if not filename.endswith(".png"):
            continue

        path = os.path.join(TILE_FOLDER, filename)
        base_image = Image.open(path).convert("RGB")
        base_name = os.path.splitext(filename)[0]

        edge_colors = get_edge_colors(base_image)

        for angle in [0, 90, 180, 270]:
            rotated_image = base_image.rotate(-angle, expand=True)
            edge_colors = get_edge_colors(rotated_image)

            conns = {dir: color for dir, color in edge_colors.items()}
            tile_name = f"{base_name}" if angle == 0 else f"{base_name}_{angle}"
            tiles[tile_name] = conns

    return tiles

def generate_rules(tiles):
    rules = []

    for name, conns in tiles.items():
        rule = {
            "TileName": name,
            "Neighbors": [],
        }
        up = []
        down = []
        right = []
        left = []

        for other_name, other_conns in tiles.items():
            if conns["Up"] == other_conns["Down"]:
                up.append(other_name)
            if conns["Down"] == other_conns["Up"]:
                down.append(other_name)
            if conns["Left"] == other_conns["Right"]:
                left.append(other_name)
            if conns["Right"] == other_conns["Left"]:
                right.append(other_name)

        rule["Neighbors"].append(up)
        rule["Neighbors"].append(down)
        rule["Neighbors"].append(left)
        rule["Neighbors"].append(right)
        rules.append(rule)

    return rules

if __name__ == "__main__":
    tile_connections = load_tile_edges_with_rotations()
    rules = generate_rules(tile_connections)

    with open(OUTPUT_FILEPATH, "w") as f:
        json.dump(rules, f, indent=2)