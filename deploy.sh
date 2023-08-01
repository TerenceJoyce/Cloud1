!/bin/bash

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