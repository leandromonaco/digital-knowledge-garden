https://github.com/getredash/
https://hub.docker.com/r/redash/redash/
https://github.com/getredash/redash/blob/master/docker-compose.yml
https://redash.io/help/open-source/setup#-Docker

Create `docker-compose.yml`

```
version: '3'

services:
  server:
    image: redash/redash:latest
    ports:
      - 5000:5000
    environment:
      REDASH_LOG_LEVEL: "INFO"
      REDASH_REDIS_URL: "redis://redis:6379/0"
      REDASH_DATABASE_URL: "postgresql://postgres@postgres/postgres"
      REDASH_RATELIMIT_ENABLED: "false"
      REDASH_MAIL_DEFAULT_SENDER: "redash@example.com"
      REDASH_MAIL_SERVER: "email"
      REDASH_MAIL_PORT: 1025
      REDASH_ENFORCE_CSRF: "true"
      REDASH_GUNICORN_TIMEOUT: 60
    depends_on:
      - postgres
      - redis
      - email
  
  redis:
    image: redis:7-alpine
    restart: unless-stopped

  postgres:
    image: pgautoupgrade/pgautoupgrade:15-alpine3.8
    ports:
      - "5432:5432"
    # The following turns the DB into less durable, but gains significant performance improvements for the tests run (x3
    # improvement on my personal machine). We should consider moving this into a dedicated Docker Compose configuration for
    # tests.
    command: "postgres -c fsync=off -c full_page_writes=off -c synchronous_commit=OFF"
    restart: unless-stopped
    environment:
      POSTGRES_HOST_AUTH_METHOD: "trust"

  email:
      image: maildev/maildev
      ports:
        - "1080:1080"
        - "1025:1025"
      restart: unless-stopped
```

- Run `docker-compose up -d`
- Create tables `docker-compose run --rm server create_db`
- Create database for tests `docker-compose run --rm postgres psql -h postgres -U postgres -c "create database tests"`
- Test setup http://localhost:5000

