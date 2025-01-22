[Recorder](https://docs.getmoto.org/en/latest/docs/configuration/recorder/index.html)
[Run using Docker](http://docs.getmoto.org/en/latest/docs/server_mode.html#run-using-docker)

#Docker container: https://hub.docker.com/r/motoserver/moto

`docker run -p 52009:3000 -e MOTO_COGNITO_IDP_USER_POOL_ID_STRATEGY=HASH -e  MOTO_ENABLE_RECORDING=True motoserver/moto:latest`


#Cognito http://docs.getmoto.org/en/latest/docs/services/cognito-idp.html


**Documentation**
- http://docs.getmoto.org/en/latest/docs/server_mode.html
- https://hub.docker.com/r/motoserver/moto/tags
- http://docs.getmoto.org/en/latest/docs/services/events.html