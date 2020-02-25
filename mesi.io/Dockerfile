FROM openjdk:8

RUN mkdir /mesi.io
WORKDIR /mesi.io

COPY build/libs/mesi-io-1.0.0.jar app.jar

EXPOSE 8080
VOLUME /mesi.io/log

ENTRYPOINT ["java","-Djava.security.egd=file:/dev/./urandom","-jar","/mesi.io/app.jar"]
