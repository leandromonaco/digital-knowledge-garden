# Docker
docker run  -p 6379:6379 --name hf-redis -d redis

Reference: https://hub.docker.com/_/redis


# Client 
## GUI

winget install -e --id ekvedaras.redis-gui

Source: https://github.com/ekvedaras/redis-gui

## Console

npm install -g redis-cli

rdcli -h your.redis.host -a yourredispassword -p 11111

Source: https://github.com/lujiajing1126/redis-cli
