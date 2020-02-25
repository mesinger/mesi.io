FROM openjdk:8

RUN mkdir /mesi.io.clipboard
WORKDIR /mesi.io.clipboard

COPY build/libs/mesi-clipboard-1.0.0.jar app.jar

VOLUME /mesi.io.clipboard/log

ENTRYPOINT ["java","-Djava.security.egd=file:/dev/./urandom","-jar","/mesi.io.clipboard/app.jar"]
