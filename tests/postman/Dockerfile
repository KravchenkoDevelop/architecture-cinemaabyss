FROM node:18-alpine

WORKDIR /app

COPY . .

RUN npm install --strict-ssl=false \
 && npm install -g npm@latest \
 && npm install -g newman \
 && npm install -g newman-reporter-htmlextra

ENV NODE_PATH=/usr/local/lib/node_modules
ENV PATH=$PATH:/usr/local/lib/node_modules/newman/bin

CMD ["newman", "run", "CinemaAbyss.postman_collection.json", \
     "--environment", "CinemaAbyss.postman_environment.json", \
     "--reporters", "cli,htmlextra", \
     "--reporter-htmlextra-export", "newman/report.html"]

