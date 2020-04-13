FROM openjdk:8

RUN mkdir /mesi.io
WORKDIR /mesi.io

COPY app-0.0.2.jar app.jar

EXPOSE 40200

VOLUME /mesi.io/log

ENTRYPOINT ["java","-Djava.security.egd=file:/dev/./urandom","-jar","/mesi.io/app.jar"]
