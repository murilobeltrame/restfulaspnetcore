FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu
WORKDIR /usr/src/app
COPY . .
RUN chmod +x entrypoint.sh && \
    chmod +x setup.sh
RUN ls -l
CMD /bin/bash ./entrypoint.sh