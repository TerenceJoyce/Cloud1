!/bin/bash

# Replace these values with your desired image URL and environment variable name
# IMAGE_URL="your-image-url/image:tag"
# ENV_VAR_NAME="SERVICE_IMAGE_URL"

# Check if docker-compose is installed
if ! command -v docker-compose &> /dev/null; then
  echo "docker-compose is not installed. Please install it and try again."
  exit 1
fi

# Create the docker-compose.yml file
cat > compose.yaml << EOF
version: '3'

services:
  udp_listener:
    image: ${IMAGE_URL}
    ports:
      - "12345:12345/udp"
    restart: unless-stopped

EOF

echo "docker-compose.yml file has been generated with the following content:"
cat docker-compose.yml
docker-compose pull
docker-compose up -d