FROM openjdk:8

RUN mkdir /mesi.io
WORKDIR /mesi.io

COPY bin/mesi.io.app-0.0.2.jar app.jar

EXPOSE 8080
VOLUME /mesi.io/log

ENTRYPOINT ["java","-Djava.security.egd=file:/dev/./urandom","-jar","/mesi.io/app.jar"]
