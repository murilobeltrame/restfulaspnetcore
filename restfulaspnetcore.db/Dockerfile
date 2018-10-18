# FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu
# WORKDIR /usr/src/app
# COPY . .
# RUN chmod +x entrypoint.sh && \
#     chmod +x setup.sh
# RUN ls -l
# CMD /bin/bash ./entrypoint.sh
FROM microsoft/mssql-server-linux:latest
# Create app directory
RUN mkdir -p /usr/src/app
COPY . /usr/src/app
RUN chmod +x /usr/src/app/setup.sh
CMD /bin/bash /usr/src/app/entrypoint.sh