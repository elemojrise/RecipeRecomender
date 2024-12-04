# Use an official lightweight Python image
FROM python:3.10-slim-buster

# Set the working directory
WORKDIR /app

# Copy the requirements file
COPY requirements.txt .

# Install dependencies
RUN pip install --no-cache-dir -r requirements.txt

# Copy the application code
COPY app.py .

# Expose the port Flask is running on
EXPOSE 5001

# Define environment variable
ENV FLASK_APP=app.py

# Command to run the application
CMD ["flask", "run", "--host=0.0.0.0", "--port=5001"]