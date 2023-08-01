!/bin/bash

# Create the docker-compose.yml file
mkdir -p cloud1-dep
cd cloud1-dep
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
cat compose.yaml
docker-compose pull
docker-compose up -d