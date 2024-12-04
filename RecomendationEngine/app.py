from flask import Flask, jsonify, request

app = Flask(__name__)

import random
from datetime import datetime

# Define a sample list of recipes
sample_recipes = [
    {
        "Title": "First Recipe",
        "Instructions": "Instructions of first recipe",
        "ImageUrl": "http://example.com/pancakes.jpg",
        "EffectiveDate": datetime.now().isoformat(),
        "RecordSource": "API"
    },
    {
        "Title": "Omelette",
        "Instructions": "Beat eggs and cook in a pan.",
        "ImageUrl": "http://example.com/omelette.jpg",
        "EffectiveDate": datetime.now().isoformat(),
        "RecordSource": "API"
    },
    {
        "Title": "Salad",
        "Instructions": "Chop vegetables and mix.",
        "ImageUrl": "http://example.com/salad.jpg",
        "EffectiveDate": datetime.now().isoformat(),
        "RecordSource": "API"
    },
]

@app.route('/recommendations/<recipe_title>', methods=['GET'])
def get_recommendations(recipe_title):

    sample_recipes[0]["Title"] = recipe_title

    num_recommendations = 3
    recommendations = random.sample(sample_recipes, k=num_recommendations)
    return jsonify(recommendations), 200

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5001)