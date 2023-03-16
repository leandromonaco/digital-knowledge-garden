## Server

- `docker run --name redisserver -p 6379:6379 -v hfredisdata:/var/opt/redis -d redis:latest`
- `docker run --name redisserver -p 6379:6379 -v hfredisdata:/var/opt/redis -d redis:latest --requirepass test`
- `docker run -d --cap-add sys_resource --name rp -p 8443:8443 -p 9443:9443 -p 12000:12000 redislabs/redis`
 
  
## Client

- `docker run -it --rm redis redis-cli --verbose -h host.docker.internal`
- `docker run -it --rm redis redis-cli --verbose -h host.docker.internal --tls --insecure`
  
## Reference

- https://hub.docker.com/_/redis
- https://repost.aws/questions/QUPDj6Oz9uQ8W6bTsOAniNkA/how-to-securely-connect-to-elasti-cache-redis-instances
- https://developer.redis.com/create/docker/redis-on-docker/
