FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

RUN  mkdir -p /usr/src/app

WORKDIR /usr/src/app
COPY . /usr/src/app

RUN chown mssql -R /usr/src/app

RUN chmod +x /usr/src/app/run-initialization.sh
RUN chmod +x /usr/src/app/entrypoint.sh

USER mssql

CMD /bin/bash ./entrypoint.sh

